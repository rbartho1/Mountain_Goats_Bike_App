namespace Mountain_Goats_Bike_App.Models
{
    public class Orders
    {

        public required int Order_id { get; set; }

        public int? Customer_id { get; set; }

        public required int Order_status { get; set; }

        public required DateOnly Order_date { get; set; }

        public required DateOnly Required_date { get; set; }

        public DateOnly? Shipped_date { get; set; }

        public required int Store_id { get; set; }

        public required int Staff_id { get; set; }

    }
}
