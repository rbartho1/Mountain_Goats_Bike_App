using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class OrdersData : DataAccess
    {
        public OrdersData(IConfiguration configuration) : base(configuration)
        { }

        public List<Orders> GetOrders()
        {
            var orderList = new List<Orders>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [sales].[orders]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    int listEntries = 0;
                    while (dataReader.Read() && listEntries < 30)
                    {
                        Orders order = new Orders
                        {
                            Order_id = (int)dataReader["order_id"],
                            Customer_id = dataReader["customer_id"] as int?,
                            Order_status = (byte)dataReader["order_status"],
                            Order_date = DateOnly.FromDateTime((DateTime)dataReader["order_date"]),
                            Required_date = DateOnly.FromDateTime((DateTime)dataReader["required_date"]),
                            Shipped_date = DateOnly.FromDateTime((DateTime)dataReader["shipped_date"]),
                            Store_id = (int)dataReader["store_id"],
                            Staff_id = (int)dataReader["staff_id"]
                        };
                        orderList.Add(order);
                        listEntries++;
                    }
                }
            }

            return orderList;
        }
    }
}
