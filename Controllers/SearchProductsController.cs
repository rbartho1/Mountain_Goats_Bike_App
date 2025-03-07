using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;
using Mountain_Goats_Bike_App.Data;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class SearchProductsController : Controller
    {
        private readonly SearchProductsData _dataAccess;

        public SearchProductsController(SearchProductsData dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index(int? pageNumber, string brand_name, string category_name, string zipcode_number, string product_name)
        {
            int pageSize = 10;

            var allBrandNames = _dataAccess.GetBrandNames();
            var allCategoryNames = _dataAccess.GetCategoryNames();
            var allZipCodes =  _dataAccess.GetZipcodes();

            var product_details = _dataAccess.GetProductDetails(brand_name, category_name, zipcode_number, product_name);

            ViewData["AllBrandNames"] = allBrandNames;
            ViewData["AllCategoryNames"] = allCategoryNames;
            ViewData["AllZipCodes"] = allZipCodes;
            return View(PaginatedList<Mountain_Goats_Bike_App.Models.SearchProducts>.Create(product_details, pageNumber ?? 1, pageSize));

        }

        public IActionResult BrandNameList()
        {
            return View();
        }
    }
}
