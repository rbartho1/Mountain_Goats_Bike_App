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

        public IActionResult Index(int? pageNumber)
        {
            int pageSize = 10;
            var product_details = _dataAccess.GetProductDetails();
            return View(PaginatedList<Mountain_Goats_Bike_App.Models.View_product_details>.Create(product_details, pageNumber ?? 1, pageSize));

        }
    }
}
