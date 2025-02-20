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

        public IActionResult Index(int? pageNumber)
        {
            int pageSize = 10;
            
            var customers = _dataAccess.GetCustomers();

            return View(PaginatedList<Mountain_Goats_Bike_App.Models.Customers>.Create(customers, pageNumber ?? 1, pageSize));
        }

        public IActionResult Details(int id)
        {
            var customer_details = _dataAccess.GetCustomerDetails(id);
            return View(customer_details);
        }
    }
}
