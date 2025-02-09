using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersData _dataAccess;

        public OrdersController(OrdersData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var orders = _dataAccess.GetOrders();
            return View(orders);
        }
    }
}
