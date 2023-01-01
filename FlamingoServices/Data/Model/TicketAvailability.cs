using System;
using System.Collections.Generic;

namespace FlamingoServices.Data.Models
{
    public partial class TicketAvailability
    {
        public int Slno { get; set; }

        public string FlightId { get; set; } = null!;

        public DateTime DepartureDate { get; set; }

        public int SeatsAvailable { get; set; }

        public virtual FlightDetail Flight { get; set; } = null!;
    }
}
