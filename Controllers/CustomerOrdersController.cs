using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class CustomerOrdersController : Controller
    {
        private readonly CustomerOrdersData _dataAccess;

        public CustomerOrdersController(CustomerOrdersData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index(int id)
        {
            var customer_orders = _dataAccess.GetCustomerOrders(id);
            return View(customer_orders);
        }
    }
}
