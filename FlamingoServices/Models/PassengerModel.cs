using System;
using System.Collections.Generic;

namespace FlamingoServices.Models
{

    public class PassengerModel
    {
        public int PassengerId { get; set; }

        public string PassengerName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public DateTime DateOfBirth { get; set; }

        public long BookingId { get; set; }

        public bool Cancelled { get; set; }
    }
}

