using System;
using System.Collections.Generic;

namespace FlamingoServices.Models
{

    public class FlightScheduleModel
    {
        public int FlightSchId { get; set; }

        public string? FlightId { get; set; }

        public int OrginAirportId { get; set; }

        public string Origin { get; set; }

        public string DepartureDay { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public string Destination { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Price { get; set; }

        public bool Cancelled { get; set; }
    }
}

