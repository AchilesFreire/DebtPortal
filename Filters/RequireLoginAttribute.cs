
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DebtPortal.Filters
{
    public class RequireLoginAttribute : ActionFilterAttribute
    {
        private const string SessionUserKey = "User";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var userJson = httpContext.Session.GetString(SessionUserKey);
            if (string.IsNullOrEmpty(userJson))
            {
                // Redireciona para Account/Login
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}