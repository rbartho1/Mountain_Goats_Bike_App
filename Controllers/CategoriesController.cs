using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesData _dataAccess;

        public CategoriesController(CategoriesData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var categories = _dataAccess.GetCategories();
            return View(categories);
        }
    }
}


