using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppPOE.Models;

namespace WebAppPOE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        //Display product stored in the database
        public IActionResult Index()//Add index view
        {
            // Get all products from the database
            List<Product_Table> products = Product_Table.GetAllProducts();

            // Get userID from session
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");

            // Pass products and userID to the view
            ViewData["Products"] = products;
            ViewData["UserID"] = userID;
            return View();
        }

        //Add Mywork view
        public IActionResult MyWork()
        {
            return View();
        }

        //add about us view
        public IActionResult AboutUs()
        {
            return View();
        }

        //add contact view
        public IActionResult Contact()
        {
            return View();
        }

        //Add privacy view
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
