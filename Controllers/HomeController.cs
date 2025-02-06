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
        public IActionResult Categories()
        {
            List<Categories> categoryList = new List<Categories>();
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM [production].[categories]";
                    SqlCommand command = new SqlCommand(sql, connection);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Categories categories = new Categories
                            {
                                Category_id = Convert.ToInt32(dataReader["category_id"]),
                                Category_name = Convert.ToString(dataReader["category_name"])
                            };
                            categoryList.Add(categories);
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
            _logger.LogInformation($"Retrieved {categoryList.Count} categories from the database.");
            _logger.LogInformation($"Retrieved {categoryList} categories from the database.");

            return View(categoryList);
        }

        public IActionResult Inventory()
        {
            List<Inventory> inventoryList = new List<Inventory>();
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM [production].[stocks]";
                    SqlCommand command = new SqlCommand(sql, connection);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Inventory inventory = new Inventory
                            {
                                Store_id = Convert.ToInt32(dataReader["store_id"]),
                                Product_id = Convert.ToInt32(dataReader["product_id"]),
                                Quantity = Convert.ToInt32(dataReader["quantity"])
                            };
                            inventoryList.Add(inventory);
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
            _logger.LogInformation($"Retrieved {inventoryList.Count} inventory items from the database.");
            _logger.LogInformation($"Retrieved {inventoryList} inventory items from the database.");

            return View(inventoryList);
        }

        public IActionResult Products()
        {
            List<Products> productsList = new List<Products>();
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM [production].[products]";
                    SqlCommand command = new SqlCommand(sql, connection);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Products products = new Products
                            {
                                Product_id = Convert.ToInt32(dataReader["product_id"]),
                                Product_name = Convert.ToString(dataReader["product_name"]),
                                Brand_id = Convert.ToInt32(dataReader["brand_id"]),
                                Category_id = Convert.ToInt32(dataReader["category_id"]),
                                Model_year = Convert.ToInt32(dataReader["model_year"]),
                                List_price = Convert.ToDecimal(dataReader["list_price"])
                            };
                            productsList.Add(products);
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
            _logger.LogInformation($"Retrieved {productsList.Count} brands from the database.");
            _logger.LogInformation($"Retrieved {productsList} brands from the database.");

            return View(productsList);
        }

        public IActionResult Ratings()
        {
            List<Ratings> ratingsList = new List<Ratings>();
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM [sales].[order_satisfaction]";
                    SqlCommand command = new SqlCommand(sql, connection);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Ratings ratings = new Ratings
                            {
                                Satisfaction_id = Convert.ToInt32(dataReader["sat_id"]),
                                Satisfaction_level = Convert.ToInt32(dataReader["satisfaction_level"]),
                                Order_number = Convert.ToInt32(dataReader["order"])
                            };
                            ratingsList.Add(ratings);
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
            _logger.LogInformation($"Retrieved {ratingsList.Count} brands from the database.");
            _logger.LogInformation($"Retrieved {ratingsList} brands from the database.");

            return View(ratingsList);
        }

    }
}


