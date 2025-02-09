namespace Mountain_Goats_Bike_App.Models
{
    public class Products
    {

        public required int Product_id { get; set; }

        public required string Product_name { get; set; }

        public required int Brand_id { get; set; }

        public required int Category_id { get; set; }

        public required int Model_year { get; set; }

        public required decimal List_price { get; set; }

    }
}
