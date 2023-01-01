using System;
using System.Collections.Generic;

namespace FlamingoServices.Data.Models
{

    public partial class FlightDetail
    {
        public string FlightId { get; set; } = null!;

        public string Aeroplanename { get; set; } = null!;

        public int Capacity { get; set; }

        public bool Cancelled { get; set; }

        public virtual ICollection<ScheduleFlight> ScheduleFlights { get; } = new List<ScheduleFlight>();

        public virtual ICollection<TicketAvailability> TicketAvailabilities { get; } = new List<TicketAvailability>();

        public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
    }
}

