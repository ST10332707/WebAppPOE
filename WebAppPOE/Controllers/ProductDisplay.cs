using Microsoft.AspNetCore.Mvc;
using WebAppPOE.Models;

namespace WebAppPOE.Controllers
{
    public class ProductDisplay : Controller
    {
        //Get data from the selectProducts and post them in the view
        [HttpGet]
        public IActionResult MyWork(int id, string name, decimal price, string category, bool availability)
        {
            var products = Product_Display.SelectProducts();
            return View(products);
        }
    }
}
