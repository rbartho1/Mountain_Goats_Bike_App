using Mountain_Goats_Bike_App.Models;
using Microsoft.Data.SqlClient;

namespace Mountain_Goats_Bike_App.Data
{
    public class ItemsOrderedData : DataAccess
    {
        public ItemsOrderedData(IConfiguration configuration) : base(configuration)
        { }

        public List<ItemsOrdered> GetItemsOrdered()
        {
            var itemsList = new List<ItemsOrdered>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM [sales].[order_items]";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    int listEntries = 0;
                    while (dataReader.Read() && listEntries < 30)
                    {
                        ItemsOrdered item = new ItemsOrdered
                        {
                            Order_id = (int)dataReader["order_id"],
                            Item_id = (int)dataReader["item_id"],
                            Product_id = (int)dataReader["product_id"],
                            Quantity = (int)dataReader["quantity"],
                            List_price = (decimal)dataReader["list_price"],
                            Discount = (decimal)dataReader["discount"],
                        };
                        itemsList.Add(item);
                        listEntries++;
                    }
                }
            }

            return itemsList;
        }
    }
}
