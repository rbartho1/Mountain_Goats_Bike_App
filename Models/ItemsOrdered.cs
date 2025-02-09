namespace Mountain_Goats_Bike_App.Models
{
    public class ItemsOrdered
    {

        public required int Order_id { get; set; }

        public required int Item_id { get; set; }

        public required int Product_id { get; set; }

        public required int Quantity { get; set; }

        public required decimal List_price { get; set; }

        public required decimal Discount { get; set; }

    }
}
