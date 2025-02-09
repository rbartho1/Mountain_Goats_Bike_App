namespace Mountain_Goats_Bike_App.Models
{
    public class Staffs
    {

        public required int Staff_id { get; set; }

        public required String First_name { get; set; }

        public required String Last_name { get; set; }

        public required String Email { get; set; }

        public String Phone_number { get; set; }

        public required int Active { get; set; }

        public required int Store_id { get; set; }

        public int? Manager_id { get; set; }

    }
}
