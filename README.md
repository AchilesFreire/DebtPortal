

I need to report some difficulties using the Web API proposed in the challenge:

The authentication process (validate) does not work for the credentials provided (john.doe@email.com, Password123!).

I added these credentials hardcoded in the Account controller (Lines 46 to 48) to avoid jeopardizing the project and to proceed with the delivery.

After running the project, please provide these credentials:

- john.doe@email.com

- Password123!

Any other credentials will cause problems in the system, as I cannot correctly obtain data from the Dashboard for other untested credentials.

I am available to clarify any doubts and questions.

Thats a good sequence to test de project:


- Execute the project
- Enter random login and password, and observe the error message:
  Error: InvalidCredentials (Invalid email or password)
- Enter the fixed login and password (john.doe@email.com, Password123!)
- Observe the opening of the dashboard
- Click on the "Update Address" option
- Change the data and save
- Return to the Dashboard,
- Observe the changed data in the Address field
- Click on Change Email:
- Enter a new address
- In addition to the confirmation and password
- Click on "Update Email Address"
- Return to the dashboard
- Verify that the email was saved
- Click on Logout
- Click on register here
- Fill in all the fields
- Verify that the API is returning an error, preventing the creation of new accounts:
  Server returned an error: ValidationFailed (The provided information does not match our records)
