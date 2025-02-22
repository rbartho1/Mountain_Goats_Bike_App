
using Mountain_Goats_Bike_App.Data;
using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class CustomerOrdersData : DataAccess
    {
        public CustomerOrdersData(IConfiguration configuration) : base(configuration)
        { }
        public List<CustomerOrders> GetCustomerOrders(int id)
        {
            var customerOrdersList = new List<CustomerOrders>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT [order_items].[order_id] AS order_id_number" +
                    ",[item_id]" +
                    ",[product_name]" +
                    ",[orders].[order_date] AS date_ordered" +
                    ",SUM(CONVERT(DECIMAL(10, 2), ROUND((1 - [discount]) *" +
                    "([quantity] * [order_items].[list_price]), 2))) OVER (PARTITION BY [order_items].[order_id]) AS total_order_price" +
                    ",[order_items].[list_price] AS unit_price" +
                    ",[quantity], [first_name], [last_name]" +
                    "FROM [BikeStores].[sales].[order_items]" +
                    "JOIN [BikeStores].[sales].[orders]" +
                    "ON [order_items].[order_id] = [orders].[order_id]" +
                    "JOIN [BikeStores].[production].[products]" +
                    "ON [order_items].[product_id] = [products].[product_id]" +
                    "JOIN [BikeStores].[sales].[customers]" +
                    "ON [orders].[customer_id] = [customers].[customer_id]" +
                    "WHERE [orders].[customer_id] = @ID " +
                    "AND [orders].[order_date] IN(SELECT TOP 3[orders].[order_date]" +
                    "FROM [BikeStores].[sales].[orders] " +
                    "WHERE [orders].[customer_id] = @ID " +
                    "ORDER BY [orders].[order_date] DESC) " +
                    "ORDER BY total_order_price DESC;";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        CustomerOrders customerOrder = new CustomerOrders
                        {   Order_id = (int)dataReader["order_id_number"],
                            Unit_price = (decimal)dataReader["unit_price"],
                            Item_id = (int)dataReader["item_id"],
                            Quantity = (int)dataReader["quantity"],
                            Order_date = DateOnly.FromDateTime((DateTime)dataReader["date_ordered"]),
                            Item_name = dataReader["product_name"].ToString(),
                            Total_order_price = (decimal)dataReader["total_order_price"],
                            First_name = dataReader["first_name"].ToString(),
                            Last_name = dataReader["last_name"].ToString(),
                        };
                        customerOrdersList.Add(customerOrder);
                    }
                }
            }
            return customerOrdersList;
        }
    }
}
