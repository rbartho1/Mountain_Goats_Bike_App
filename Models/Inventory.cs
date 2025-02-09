namespace Mountain_Goats_Bike_App.Models
{
    public class Inventory
    {

        public required int Store_id { get; set; }


        public required int Product_id { get; set; }

        public int? Quantity { get; set; }

    }
}
