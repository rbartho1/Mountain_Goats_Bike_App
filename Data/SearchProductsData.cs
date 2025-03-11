using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Mountain_Goats_Bike_App.Data
{
    public class SearchProductsData : DataAccess
    {
        public SearchProductsData(IConfiguration configuration) : base(configuration)
        { }

        public List<SearchProducts> GetProductDetails(string brand_name, string category_name, string zipcode_number, string product_name)
        {
            var product_deatilsList = new List<SearchProducts>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string statement_product_details_search =
                    "DECLARE @BikeBrand NVARCHAR(255) = NULL;" +
                    "\r\nDECLARE @BikeCategory NVARCHAR(255) = NULL;" +
                    "\r\nDECLARE @BikeName NVARCHAR(255) = NULL;" +
                    "\r\nDECLARE @BikeZipcode NVARCHAR(255) = NULL;" +
                    "\r\nDECLARE @SQL NVARCHAR(4000);" +
                    "\r\nSET @SQL = N'SELECT * FROM view_product_details" +
                    "\r\nWHERE (@BikeBrand IS NULL OR name_of_brand = @BikeBrand) AND" +
                    "\r\n(@BikeCategory IS NULL OR name_of_category = @BikeCategory) AND" +
                    "\r\n(@BikeZipcode IS NULL OR zip_code = @BikeZipcode) AND" +
                    "\r\n(@BikeName IS NULL OR name_of_product LIKE @BikeName)" +
                    "\r\nORDER BY id_of_product;'" +
                    "\r\n\r\nEXEC sp_executesql @SQL, N'@BikeBrand NVARCHAR(255), @BikeCategory NVARCHAR(255), @BikeZipcode NVARCHAR(255), @BikeName NVARCHAR(255)', " +
                    "@BikeBrand = @TheBikeBrand, @BikeCategory = @TheBikeCategory, @BikeZipcode = @TheBikeZipcode, @BikeName = @TheBikeName;";
                using (SqlCommand sqlProductSearchCommand = new SqlCommand(statement_product_details_search, connection))
                {
                    sqlProductSearchCommand.Parameters.AddWithValue("@TheBikeBrand", string.IsNullOrEmpty(brand_name) ? DBNull.Value : brand_name);
                    sqlProductSearchCommand.Parameters.AddWithValue("@TheBikeCategory", string.IsNullOrEmpty(category_name) ? DBNull.Value : category_name);
                    sqlProductSearchCommand.Parameters.AddWithValue("@TheBikeZipcode", string.IsNullOrEmpty(zipcode_number) ? DBNull.Value : zipcode_number);
                    sqlProductSearchCommand.Parameters.AddWithValue("@TheBikeName", string.IsNullOrEmpty(product_name) ? DBNull.Value : "%" + product_name + "%");
                    using (SqlDataReader dataReader = sqlProductSearchCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            SearchProducts product_details = new SearchProducts
                            {
                                Product_name = dataReader["name_of_product"].ToString(),
                                Category_name = dataReader["name_of_category"].ToString(),
                                Brand_name = dataReader["name_of_brand"].ToString(),
                                Price = (decimal)dataReader["list_price"],
                                Store_name = dataReader["store_name"].ToString(),
                                Street = dataReader["street"].ToString(),
                                City = dataReader["city"].ToString(),
                                State = dataReader["state"].ToString(),
                                Zip_code = dataReader["zip_code"].ToString(),
                                Store_phone = dataReader["phone"].ToString(),
                                Quantity = (int)dataReader["quantity"]
                            };
                            product_deatilsList.Add(product_details);
                        }
                    }
                }
            }
            return product_deatilsList;
        }

        public List<String> GetBrandNames()
        {
            var brandsList = new List<String>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT [brands].[brand_name] FROM [production].[brands]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        brandsList.Add(dataReader["brand_name"].ToString());
                    }
                }
            }
            return brandsList;
        }

        public List<String> GetCategoryNames()
        {
            var categoriesList = new List<String>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT [categories].[category_name] FROM [production].[categories]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        categoriesList.Add(dataReader["category_name"].ToString());
                    }
                }
            }
            return categoriesList;
        }

        public List<String> GetZipcodes()
        {
            var zipCodesList = new List<String>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT [stores].[zip_code] FROM [sales].[stores]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        zipCodesList.Add(dataReader["zip_code"].ToString());
                    }
                }
            }
            return zipCodesList;
        }
    }
}
