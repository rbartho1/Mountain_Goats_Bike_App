using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class LocationsData : DataAccess
    {
        public LocationsData(IConfiguration configuration) : base(configuration)
        { }

        public List<Stores> GetStores()
        {
            var storesList = new List<Stores>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [sales].[stores]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    int listEntries = 0;
                    while (dataReader.Read() && listEntries < 30)
                    {
                        Stores store = new Stores
                        {
                            Store_id = (int)dataReader["store_id"],
                            Store_name = dataReader["store_name"].ToString(),
                            Phone_number = dataReader["phone"].ToString(),
                            Email = dataReader["email"].ToString(),
                            Street_address = dataReader["street"].ToString(),
                            City_name = dataReader["city"].ToString(),
                            State = dataReader["state"].ToString(),
                            Zip_code = dataReader["zip_code"].ToString()
                        };
                        storesList.Add(store);
                        listEntries++;
                    }
                }
            }

            return storesList;
        }
    }
}

