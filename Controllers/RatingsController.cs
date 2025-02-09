using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class RatingsController : Controller
    {
        private readonly RatingsData _dataAccess;

        public RatingsController(RatingsData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var products = _dataAccess.GetRatings();
            return View(products);
        }
    }
}
