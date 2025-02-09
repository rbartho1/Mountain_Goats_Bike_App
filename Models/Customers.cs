namespace Mountain_Goats_Bike_App.Models
{
    public class Customers
    {

        public int Customer_id { get; set; }

        public required String First_name { get; set; }

        public required String Last_name { get; set; }

        public String Phone_number { get; set; }

        public required String Email { get; set; }

        public String Street_address { get; set; }

        public String City_name { get; set; }

        public String State { get; set; }

        public String Zip_code { get; set; }

    }
}
