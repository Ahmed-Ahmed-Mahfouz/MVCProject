using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult All()
        {
            ProductBL bl = new ProductBL();
            List<Product> ProductsModel = bl.GetAll();
            return View("ShowAll",ProductsModel);
            
        }
        public IActionResult Details(int id)
        {
            ProductBL bl = new ProductBL();
            Product ProductModel = bl.GetByID(id);
            return View("Details",ProductModel);
        }
    }
}
