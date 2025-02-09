using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class ProductsData : DataAccess
    {
        public ProductsData(IConfiguration configuration) : base(configuration)
        { }

        public List<Products> GetProducts()
        {
            var productsList = new List<Products>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [production].[products]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    int listEntries = 0;
                    while (dataReader.Read() && listEntries < 30)
                    {
                        Products product = new Products
                        {
                            Product_id = (int)dataReader["product_id"],
                            Product_name = dataReader["product_name"].ToString(),
                            Brand_id = (int)dataReader["brand_id"],
                            Category_id = (int)dataReader["category_id"],
                            Model_year = (short)dataReader["model_year"],
                            List_price = (decimal)dataReader["list_price"]
                        };
                        productsList.Add(product);
                        listEntries++;
                    }
                }
            }

            return productsList;
        }
    }
}
