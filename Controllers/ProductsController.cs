using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsData _dataAccess;

        public ProductsController(ProductsData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var products = _dataAccess.GetProducts();
            return View(products);
        }
    }
}
