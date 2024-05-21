using Microsoft.AspNetCore.Mvc;
using WebAppPOE.Models;

namespace WebAppPOE.Controllers
{
    public class User : Controller
    {
        public UserTable usertbl = new UserTable();

        [HttpPost]
        public ActionResult AboutUs(UserTable Users)
        {
            var result = usertbl.insert_User(Users);//insert data into the user table
            return RedirectToAction("Privacy", "Home");// redirect the user to the privacy page
        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            return View(usertbl);//return the view
        }
    }
}
