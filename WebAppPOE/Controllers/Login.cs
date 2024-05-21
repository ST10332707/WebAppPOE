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

        [HttpPost]
        public ActionResult Privacy(string email, string name)
        {
            var loginModel = new Login_Model();
            int userID = loginModel.SelectUser(email, name);
            if (userID != -1)
            {
                // Store userID in session
                HttpContext.Session.SetInt32("UserID", userID);

                // User found, proceed with login logic
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // User not found
                return View("LoginFailed");
            }
        }
    }
}
