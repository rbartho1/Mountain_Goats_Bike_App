using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class CategoriesData:DataAccess
    {
        public CategoriesData(IConfiguration configuration) : base(configuration)
        { }

        public List<Categories> GetCategories() { 
            var categoryList = new List<Categories>();
            using (var connection = new SqlConnection(_connectionString))
            {
                    connection.Open();
                    string sql = "SELECT * FROM [production].[categories]";
                    SqlCommand command = new SqlCommand(sql, connection);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        int listEntries = 0;
                        while (dataReader.Read() && listEntries < 30)
                        {
                            Categories categories = new Categories
                            {
                                Category_id = (int)dataReader["category_id"],
                                Category_name = dataReader["category_name"].ToString()
                            };
                            categoryList.Add(categories);
                            listEntries++;
                        }
                    }
                }

            return categoryList;
        }
    }
}
