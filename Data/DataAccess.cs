﻿namespace Mountain_Goats_Bike_App.Data
{
    public class DataAccess
    {
        protected readonly string _connectionString;

        public DataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be established");
        }
    }
}
