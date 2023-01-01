using System;
using System.Collections.Generic;

namespace FlamingoServices.Models
{

    public class TicketModel
    {
        public string Pnrnumber { get; set; }

        public long BookingId { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string FlightId { get; set; }

        public string PassengerName { get; set; }

        public int Age { get; set; }

        public int PassengerId { get; set; }

        public string Gender { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public bool Cancelled { get; set; }
    }
}

