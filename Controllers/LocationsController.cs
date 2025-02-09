using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class LocationsController : Controller
    {
        private readonly LocationsData _dataAccess;

        public LocationsController(LocationsData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var stores = _dataAccess.GetStores();
            return View(stores);
        }
    }
}
