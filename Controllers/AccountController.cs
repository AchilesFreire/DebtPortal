using DebtPortal.Models;
using DebtPortal.Services;
using DebtPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DebtPortal.Filters;

namespace DebtPortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IDebtCollectionApiClient _apiClient;
        private const string SessionUserKey = "User";
        private const string AccountUserKey = "Account";
        private const string SessionAccountIdKey = "AccountId";

        public AccountController(IDebtCollectionApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Login Is not working, 
                var (userDto, apiCallError) = await _apiClient.LoginAsync(model?.Email??"", model?.Password??"");

                if (apiCallError!=null)
                {
                    ModelState.AddModelError("LoginError", $" Error: {apiCallError.Error} ({apiCallError.Message}) ");
                }

                if (model.Email.Equals("john.doe@email.com",StringComparison.InvariantCultureIgnoreCase) 
                        && 
                    (model.Password.Equals("Password123!", StringComparison.InvariantCultureIgnoreCase)))
                {

                    //To continue creating this project, the result is mocked here
                    var result2 = await _apiClient.AccountInfoAsync("ACC001");

                    if (result2 != null)
                    {
                        HttpContext.Session.SetString(AccountUserKey, JsonConvert.SerializeObject(result2));

                        HttpContext.Session.SetString(SessionAccountIdKey, result2?.AccountId ?? "");

                        var Mockdto = new UserDto
                        {
                            AccountId = result2?.AccountId,
                            Email = model.Email,
                            DateOfBirth = DateTime.Now.AddYears(-50),
                            Postcode = "42709-450"
                        };

                        HttpContext.Session.SetString(SessionUserKey, JsonConvert.SerializeObject(Mockdto));

                        return RedirectToAction("Dashboard");
                    }
                    else
                        ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }
        #endregion

        #region Register

        [HttpGet]
        public ActionResult Register()
        {

            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDto
                {
                    AccountId = model.AccountId,
                    DateOfBirth = model.DateOfBirth,
                    Postcode = model.Postcode,
                    Email = model.Email,
                    Password = model.Password
                };

                var (registerOk, apiCallError) = await _apiClient.RegisterUserAsync(userDto);
                if (registerOk.Value)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("AddressError", $" Server returned an error : {apiCallError?.Error} ({apiCallError?.Message}) ");
                }
            }
            return View(model);
        }
        #endregion

        #region Dashboard

        [RequireLogin]
        public ActionResult Dashboard()
        {
            var (accountInfoViewModel, _) = GetSessionAccountInfo();

            if (accountInfoViewModel != null)
            {
                return View(accountInfoViewModel);
            }

            return View(new AccountInfoViewModel());
        }
        #endregion

        #region UpdateAddress
        [HttpGet]
        [RequireLogin]
        public IActionResult UpdateAddress()
        {
            var (accountInfoViewModel, _) = GetSessionAccountInfo();
            return View(accountInfoViewModel?.DebtorInfo?.Address);
        }

        [HttpPost]
        [RequireLogin]
        public async Task<IActionResult> UpdateAddress(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var accountId = HttpContext.Session.GetString(SessionAccountIdKey);
                if (string.IsNullOrEmpty(accountId))
                {
                    return RedirectToAction("Login");
                }
                var addressDto = new AddressDto
                {
                    AddressLine1 = model.AddressLine1,
                    AddressLine2 = model.AddressLine2,
                    City = model.City,
                    PostCode = model.PostCode,
                    Country = model.Country
                };

                var (updateOk, apiCallError) = await _apiClient.UpdateAddressAsync(accountId, addressDto);
                if (updateOk.Value)
                {
                    await RefreshSessionAccountInfo();
                    RedirectToAction("Account","DashBoard");
                }
                else
                {
                    ModelState.AddModelError("AddressError", $" Server returned an error : {apiCallError?.Error} ({apiCallError?.Message}) ");
                }
            }
            return View(model);
        }
        #endregion

        #region UpdateEmail
        [HttpGet]
        [RequireLogin]
        public IActionResult UpdateEmail()
        {
            var (accountInfoViewModel, _) = GetSessionAccountInfo();

            if (accountInfoViewModel!=null)
            {
                return View(new UpdateEmailViewModel()
                { 
                    Email = accountInfoViewModel?.DebtorInfo?.Email,
                    EmailConfirmation = "",
                    Password = "",
                    ConfirmEmailChange = true
                });
            }
            return View(new UpdateEmailViewModel());
        }

        [HttpPost]
        [RequireLogin]
        public async Task<IActionResult> UpdateEmail(UpdateEmailViewModel model)
        {
            if (ModelState.IsValid)
            {

                if(!model.Email.Equals(model.EmailConfirmation) )
                {
                    ModelState.AddModelError("AddressError", "Email confirmation does'nt match ");
                    return View(model);
                }
                var accountId = HttpContext.Session.GetString(SessionAccountIdKey);


                var updateContactDto = new UpdateEmailDto
                {
                    Email = model.Email
                };

                var (updateOk, apiCallError) = await _apiClient.UpdateEmailAsync(accountId??"", updateContactDto);
                if (updateOk.Value)
                {
                    await RefreshSessionAccountInfo();
                    TempData["SuccessMessage"] = " Address updated successfully ";
                }
                else
                {
                    ModelState.AddModelError("AddressError", $" Server returned an error : {apiCallError?.Error} ({apiCallError?.Message}) ");
                }
            }
            return View(model);
        }
        #endregion

        private async Task RefreshSessionAccountInfo()
        {
            var accountId = HttpContext.Session.GetString(SessionAccountIdKey);
            var result2 = await _apiClient.AccountInfoAsync(accountId??"");
            HttpContext.Session.SetString(AccountUserKey, JsonConvert.SerializeObject(result2));

        }
        private (AccountInfoViewModel,AccountInfoDto) GetSessionAccountInfo()
        {
            var content = HttpContext.Session.GetString(AccountUserKey);
            if (content == null) return (null , null);

            var account = JsonConvert.DeserializeObject<AccountInfoDto>(content ?? "");
            var accountInfoViewModel = AccountInfoViewModel.FromDto(account);

            return (accountInfoViewModel, account);
        }

    }
}
