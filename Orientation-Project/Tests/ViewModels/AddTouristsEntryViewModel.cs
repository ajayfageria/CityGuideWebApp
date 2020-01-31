using System;

namespace Tests.ViewModels
{
    public class AddTouristsEntryViewModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Altitude { get; set; }

        public string Information { get; set; }

        public string NearestMetro { get; set; }

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }

        public int TicketPrice { get; set; }
        public bool HasWifi { get; set; }
        public bool HasPark { get; set; }
        public bool HasSwimmingPool { get; set; }
        public bool HasParking { get; set; }
        public bool HasElevator { get; set; }
        public bool HasMedical { get; set; }
        public bool HasTrekking { get; set; }
    }
}
