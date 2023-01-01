using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlamingoServices.Data.Models
{
    public partial class User
    {
        [Key]
        public string Userid { get; set; }

        public string Password { get; set; } = null!;

        public DateTime DoB { get; set; }

        public string Fname { get; set; } = null!;

        public string Lname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public decimal Phone { get; set; }

        public string Token { get; set; } = null!;

        public string Role { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
    }
}

