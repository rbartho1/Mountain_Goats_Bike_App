using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class CustomersData : DataAccess
    {
        public CustomersData(IConfiguration configuration) : base(configuration)
        { }

        public List<Customers> GetCustomers()
        {
            var customersList = new List<Customers>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [sales].[customers]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Customers customer = new Customers
                        {
                            Customer_id = (int)dataReader["customer_id"],
                            First_name = dataReader["first_name"].ToString(),
                            Last_name = dataReader["last_name"].ToString(),
                            Phone_number = dataReader["phone"].ToString(),
                            Email = dataReader["email"].ToString(),
                            Street_address = dataReader["street"].ToString(),
                            City_name = dataReader["city"].ToString(),
                            State = dataReader["state"].ToString(),
                            Zip_code = dataReader["zip_code"].ToString()
                        }; 
                        customersList.Add(customer);
                    }
                }
            }

            return customersList;
        }

        public Customers GetCustomerDetails(int id)
        {
            Customers customer = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [sales].[customers]" +
                    "WHERE [customer_id] = @ID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        customer = new Customers
                        {
                            Customer_id = (int)dataReader["customer_id"],
                            First_name = dataReader["first_name"].ToString(),
                            Last_name = dataReader["last_name"].ToString(),
                            Phone_number = dataReader["phone"].ToString(),
                            Email = dataReader["email"].ToString(),
                            Street_address = dataReader["street"].ToString(),
                            City_name = dataReader["city"].ToString(),
                            State = dataReader["state"].ToString(),
                            Zip_code = dataReader["zip_code"].ToString()
                        };
                    }
                }
            }
            return customer;
        }
    }
}
