using System;
using System.Collections.Generic;

namespace FlamingoServices.Data.Models
{

    public partial class Ticket
    {
        public string Pnrnumber { get; set; } = null!;

        public long BookingId { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public TimeSpan ArrivalTime { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string FlightId { get; set; } = null!;

        public string PassengerName { get; set; } = null!;

        public int Age { get; set; }

        public int PassengerId { get; set; }

        public string Gender { get; set; } = null!;

        public string Origin { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public bool Cancelled { get; set; }

        public virtual Booking Booking { get; set; } = null!;

        public virtual FlightDetail Flight { get; set; } = null!;

        public virtual Passenger Passenger { get; set; } = null!;
    }
}

