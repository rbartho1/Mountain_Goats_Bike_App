
using Mountain_Goats_Bike_App.Data;
using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

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

                string exec_cust_order_proc =
                    "EXEC proc_cust_order_details '2016-01-01', '2017-12-31', " + id;
                    SqlCommand sqlProductSearchCommand = new SqlCommand(exec_cust_order_proc, connection);
                    using (SqlDataReader dataReader = sqlProductSearchCommand.ExecuteReader())
                    {
                        {
                            while (dataReader.Read())
                            {
                                CustomerOrders customerOrder = new CustomerOrders
                                {
                                    Order_id = (int)dataReader["order_id_number"],
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
            }
            return customerOrdersList;
        }
    }
}
