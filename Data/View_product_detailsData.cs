using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace Mountain_Goats_Bike_App.Data
{
    public class View_product_detailsData : DataAccess
    {
        public View_product_detailsData(IConfiguration configuration) : base(configuration)
        { }

        public List<View_product_details> GetProductDetails()
        {
            var product_deatilsList = new List<View_product_details>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT [products].[product_name] AS name_of_product, " +
                    "[categories].[category_name] AS name_of_category, " +
                    "[brands].[brand_name] AS name_of_brand, [list_price], " +
                    "\n\t[store_name], [street], [city], [state], [zip_code], [phone], [quantity]" +
                    "\nFROM [BikeStores].[production].[products]" +
                    "\r\nJOIN [BikeStores].[production].[brands]" +
                    "\r\n\tON [products].[brand_id] = [brands].[brand_id]" +
                    "\r\nJOIN [BikeStores].[production].[categories]" +
                    "\r\n\tON [products].[category_id] = [categories].[category_id]" +
                    "\r\nJOIN [BikeStores].[production].[stocks]" +
                    "\r\n\tON [products].[product_id] = [stocks].[product_id]" +
                    "\r\nJOIN [BikeStores].[sales].[stores]" +
                    "\r\n\tON [stocks].[store_id] = [stores].[store_id]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        View_product_details product_details = new View_product_details
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

            return product_deatilsList;
        }
    }
}
