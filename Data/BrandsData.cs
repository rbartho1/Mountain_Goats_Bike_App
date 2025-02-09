using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class BrandsData : DataAccess
    {
        public BrandsData(IConfiguration configuration) : base(configuration)
        { }

        public List<Brands> GetBrands()
        {
            var brandsList = new List<Brands>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [production].[brands]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    int listEntries = 0;
                    while (dataReader.Read() && listEntries < 30)
                    {
                        Brands brand = new Brands
                        {
                            Brand_id = (int)dataReader["brand_id"],
                            Brand_name = dataReader["brand_name"].ToString()
                        };
                        brandsList.Add(brand);
                        listEntries++;
                    }
                }
            }

            return brandsList;
        }
    }
}
