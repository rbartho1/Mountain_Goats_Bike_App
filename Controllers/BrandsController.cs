using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class brandsController : Controller
    {
        private readonly BrandsData _dataAccess;

        public brandsController(BrandsData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var Brands = _dataAccess.GetBrands();
            return View(Brands);
        }
    }
}
