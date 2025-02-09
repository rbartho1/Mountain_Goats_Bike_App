using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class RatingsData : DataAccess
    {
        public RatingsData(IConfiguration configuration) : base(configuration)
        { }

        public List<Ratings> GetRatings()
        {
            var ratingsList = new List<Ratings>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [sales].[order_satisfaction]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    int listEntries = 0;
                    while (dataReader.Read() && listEntries < 30)
                    {
                        Ratings rating = new Ratings
                        {
                            Satisfaction_id = (int)dataReader["sat_id"],
                            Satisfaction_level = (int)dataReader["satisfaction_level"],
                            Order_number = (int)dataReader["order"]
                        };
                        ratingsList.Add(rating);
                        listEntries++;
                    }
                }
            }

            return ratingsList;
        }
    }
}
