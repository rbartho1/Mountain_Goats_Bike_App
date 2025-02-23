using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomersData _dataAccess;
        private readonly CustomerOrdersData _customerOrdersDataAccess;

        public CustomersController(CustomersData dataAccess, CustomerOrdersData customerOrdersDataAccess)
        {
            _dataAccess = dataAccess;
            _customerOrdersDataAccess = customerOrdersDataAccess;
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

        public IActionResult CustomerOrders(int id)
        {
            var customer_orders = _customerOrdersDataAccess.GetCustomerOrders(id);
            return View("CustomerOrders/CustomerOrders", customer_orders);
        }
    }
}
