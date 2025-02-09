using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffData _dataAccess;

        public StaffController(StaffData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var staffs = _dataAccess.GetStaff();
            return View(staffs);
        }
    }
}
