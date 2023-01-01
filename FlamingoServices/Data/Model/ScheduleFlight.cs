using System;
using System.Collections.Generic;

namespace FlamingoServices.Data.Models
{

    public partial class ScheduleFlight
    {
        public int FlightSchId { get; set; }

        public string? FlightId { get; set; }

        public int OrginAirportId { get; set; }

        public string Origin { get; set; } = null!;

        public string DepartureDay { get; set; } = null!;

        public TimeSpan DepartureTime { get; set; }

        public string Destination { get; set; } = null!;

        public TimeSpan ArrivalTime { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Price { get; set; }

        public bool Cancelled { get; set; }

        public virtual FlightDetail? Flight { get; set; }

        public virtual Airport OrginAirport { get; set; } = null!;
    }
}

