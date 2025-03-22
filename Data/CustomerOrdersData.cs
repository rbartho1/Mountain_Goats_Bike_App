using Mountain_Goats_Bike_App.Data;
using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

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
                "EXEC proc_cust_order_details '2016-01-01', '2017-12-31', @ID = @TheID";
                using (SqlCommand sqlCustomerOrdersCommand = new SqlCommand(exec_cust_order_proc, connection))
                {
                    sqlCustomerOrdersCommand.Parameters.AddWithValue("@TheID", id);
                    using (SqlDataReader dataReader = sqlCustomerOrdersCommand.ExecuteReader())
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
            }
            return customerOrdersList;
        }

        public void NewOrder(int id, int store_id, int staff_id, int item_1_id, int item_2_id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string exec_audit_test_proc = "" +
                        "EXEC AuditTestProcedure @TheCustomerID, @TheStoreID, @TheStaffID, @TheFirstItem, @TheSecondItem, @TheFirstQuantity, @TheSecondQuantity, @TheListedPrice1, @TheListedPrice2, @TheFirstDiscount, @TheSecondDiscount;";
                    using (SqlCommand sqlAuditTestCommand = new SqlCommand(exec_audit_test_proc, connection))
                    {

                        sqlAuditTestCommand.Transaction = transaction;

                        sqlAuditTestCommand.Parameters.AddWithValue("@TheCustomerID", id);
                        sqlAuditTestCommand.Parameters.AddWithValue("@TheStoreID", store_id);
                        sqlAuditTestCommand.Parameters.AddWithValue("@TheStaffID", staff_id);
                        sqlAuditTestCommand.Parameters.AddWithValue("@TheFirstItem", item_1_id);
                        sqlAuditTestCommand.Parameters.AddWithValue("@TheSecondItem", item_2_id);
                        sqlAuditTestCommand.Parameters.AddWithValue("@TheFirstQuantity", 1);
                        sqlAuditTestCommand.Parameters.AddWithValue("@TheSecondQuantity", 2);
                        sqlAuditTestCommand.Parameters.AddWithValue("@TheListedPrice1", 3499.99);
                        sqlAuditTestCommand.Parameters.AddWithValue("@TheListedPrice2", 1549.00);
                        sqlAuditTestCommand.Parameters.AddWithValue("@TheFirstDiscount", 0.07);
                        sqlAuditTestCommand.Parameters.AddWithValue("@TheSecondDiscount", 0.05);
                        sqlAuditTestCommand.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }

                catch (Exception errorMessage)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
