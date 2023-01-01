using System;
using System.Collections.Generic;

namespace FlamingoServices.Data.Models
{
    public partial class Airport
    {
        public int AirportId { get; set; }

        public string AirportName { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string Terminal { get; set; } = null!;

        public virtual ICollection<ScheduleFlight> ScheduleFlights { get; } = new List<ScheduleFlight>();
    }
}

