namespace Mountain_Goats_Bike_App.Models
{
    public class CustomerOrders
    {

        public required int Order_id { get; set; }

        public required int Item_id { get; set; }

        public required String Item_name { get; set; }

        public required int Quantity { get; set; }

        public required decimal Unit_price { get; set; }

        public required DateOnly Order_date { get; set; }

        public required decimal Total_order_price { get; set; }

        public required String First_name { get; set; }

        public required String Last_name { get; set; }
    }
}
