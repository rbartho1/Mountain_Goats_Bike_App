using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryData _dataAccess;

        public InventoryController(InventoryData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var inventory = _dataAccess.GetInventory();
            return View(inventory);
        }
    }
}
