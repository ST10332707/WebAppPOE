using Microsoft.AspNetCore.Mvc;
using WebAppPOE.Models;

namespace WebAppPOE.Controllers
{
    public class ProductController : Controller
    {
        public Product_Table prodtable = new Product_Table();

        [HttpPost]
        public ActionResult MyWork(Product_Table products)
        {
            var result2 = prodtable.insert_product(products);//insert products into database
            return RedirectToAction("Index", "Home");//Redirect the user back to the home page 
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(prodtable);
        }
    }
}
