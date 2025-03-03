using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class View_product_detailsController : Controller
    {
        private readonly View_product_detailsData _dataAccess;

        public View_product_detailsController(View_product_detailsData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {
            var Product_details = _dataAccess.GetProductDetails();
            return View(Product_details);
        }
    }
}
