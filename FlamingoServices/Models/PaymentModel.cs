using System;
using System.Collections.Generic;

namespace FlamingoServices.Models
{

    public class PaymentModel
    {
        public int PaymentId { get; set; }

        public string PaymentMode { get; set; }

        public string CardNumber { get; set; }

        public string CardName { get; set; }

        public decimal Price { get; set; }

        public decimal TotalAmount { get; set; }

        public long BookingId { get; set; }
    }
}

