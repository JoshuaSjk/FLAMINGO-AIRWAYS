using System;
using System.Collections.Generic;

namespace FlamingoServices.Models
{
    public class TicketAvailabilityModel
    {
        public int Slno { get; set; }

        public string FlightId { get; set; }

        public DateTime DepartureDate { get; set; }

        public int SeatsAvailable { get; set; }
    }
}
