using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class ItemsOrderedController : Controller
    {
        private readonly ItemsOrderedData _dataAccess;

        public ItemsOrderedController(ItemsOrderedData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var items = _dataAccess.GetItemsOrdered();
            return View(items);
        }
    }
}
