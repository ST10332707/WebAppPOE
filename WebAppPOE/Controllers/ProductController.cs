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
            var result2 = prodtable.insert_product(products);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(prodtable);
        }
    }
}
