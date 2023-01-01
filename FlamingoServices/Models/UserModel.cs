using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlamingoServices.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime DoB { get; set; }

        public string Firstname { get; set; } 

        public string Lastname { get; set; }

        public string Email { get; set; }

        public decimal Phone { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }
    }
}

