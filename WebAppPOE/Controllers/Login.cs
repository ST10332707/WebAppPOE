using Microsoft.AspNetCore.Mvc;
using WebAppPOE.Models;

namespace WebAppPOE.Controllers
{
    public class Login : Controller
    {

        private readonly Login_Model login;

        public Login()
        {
            login = new Login_Model();
        }

        //post or get user id in home page when user has logged in successfully and check if the user account exists
        [HttpPost]
        public ActionResult Privacy(string email, string name)
        {
            var loginModel = new Login_Model();
            int userID = loginModel.SelectUser(email, name);
            if (userID != -1)//if statement, to check if user account exists
            {
                // Store userID in session
                HttpContext.Session.SetInt32("UserID", userID);

                // User account is valid, proceed with login logic
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // User account does not exist, error
                return View("LoginFailed");
            }
        }
    }
}
