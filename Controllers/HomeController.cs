using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Brands()
        {
            List<Brands> brandList = new List<Brands>();
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM [production].[brands]";
                    SqlCommand command = new SqlCommand(sql, connection);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Brands brands = new Brands
                            {
                                Brand_id = Convert.ToInt32(dataReader["brand_id"]),
                                Brand_name = Convert.ToString(dataReader["brand_name"])
                            };
                            brandList.Add(brands);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"error happened" + ex);
                }
                finally
                {
                    connection.Close();
                }
            }
            _logger.LogInformation($"Retrieved {brandList.Count} brands from the database.");
            _logger.LogInformation($"Retrieved {brandList} brands from the database.");

            return View(brandList);
        }
    }
}


