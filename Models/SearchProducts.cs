namespace Mountain_Goats_Bike_App.Models
{
    public class SearchProducts
    {

        public required String Product_name { get; set; }

        public required String Category_name { get; set; }

        public required String Brand_name { get; set; }

        public required decimal Price { get; set; }

        public required String Store_name { get; set; }

        public required String Street { get; set; }

        public required String City { get; set; }

        public required String State { get; set; }

        public required String Zip_code { get; set; }

        public String Store_phone { get; set; }

        public required int Quantity { get; set; }
    }
}
