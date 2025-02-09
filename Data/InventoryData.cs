using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class InventoryData : DataAccess
    {
        public InventoryData(IConfiguration configuration) : base(configuration)
        { }

        public List<Inventory> GetInventory()
        {
            var inventoryList = new List<Inventory>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [production].[stocks]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    int listEntries = 0;
                    while (dataReader.Read() && listEntries < 30)
                    {
                        Inventory inventory = new Inventory
                        {
                            Store_id = (int)dataReader["store_id"],
                            Product_id = (int)dataReader["product_id"],
                            Quantity = dataReader["quantity"] as int?
                        };
                        inventoryList.Add(inventory);
                        listEntries++;
                    }
                }
            }

            return inventoryList;
        }
    }
}
