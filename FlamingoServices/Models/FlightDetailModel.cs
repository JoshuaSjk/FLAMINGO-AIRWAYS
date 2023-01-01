using System;
using System.Collections.Generic;

namespace FlamingoServices.Models
{

    public class FlightDetailModel
    {
        public string FlightId { get; set; } 

        public string Aeroplanename { get; set; } 

        public int Capacity { get; set; }

        public bool Cancelled { get; set; }
    }
}

