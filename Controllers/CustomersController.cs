using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomersData _dataAccess;

        public CustomersController(CustomersData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var customers = _dataAccess.GetCustomers();
            return View(customers);
        }
    }
}
