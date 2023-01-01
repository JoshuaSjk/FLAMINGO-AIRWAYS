using System;
using System.Collections.Generic;

namespace FlamingoServices.Data.Models
{

    public partial class Passenger
    {
        public int PassengerId { get; set; }

        public string PassengerName { get; set; } = null!;

        public int Age { get; set; }

        public string Gender { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public long BookingId { get; set; }

        public bool Cancelled { get; set; }

        public virtual Booking Booking { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
    }
}

