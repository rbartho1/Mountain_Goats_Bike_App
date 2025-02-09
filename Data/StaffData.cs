using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class StaffData : DataAccess
    {
        public StaffData(IConfiguration configuration) : base(configuration)
        { }

        public List<Staffs> GetStaff()
        {
            var staffList = new List<Staffs>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [sales].[staffs]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    int listEntries = 0;
                    while (dataReader.Read() && listEntries < 30)
                    {
                        Staffs employee = new Staffs
                        {
                            Staff_id = (int)dataReader["staff_id"],
                            First_name = dataReader["first_name"].ToString(),
                            Last_name = dataReader["last_name"].ToString(),
                            Email = dataReader["email"].ToString(),
                            Phone_number = dataReader["phone"].ToString(),
                            Active = (byte)dataReader["active"],
                            Store_id = (int)dataReader["store_id"],
                            Manager_id = dataReader["manager_id"] as int?
                        };
                        staffList.Add(employee);
                        listEntries++;
                    }
                }
            }

            return staffList;
        }
    }
}

