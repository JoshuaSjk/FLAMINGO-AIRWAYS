using System;
using System.Collections.Generic;

namespace FlamingoServices.Data.Models
{

    public partial class Booking
    {
        public long BookingId { get; set; }

        public string Userid { get; set; } = null!;

        public virtual ICollection<Passenger> Passengers { get; } = new List<Passenger>();

        public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

        public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();

        public virtual User User { get; set; } = null!;
    }
}

