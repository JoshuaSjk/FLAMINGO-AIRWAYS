using System;
using System.Collections.Generic;

namespace FlamingoServices.Data.Models
{

    public partial class Payment
    {
        public int PaymentId { get; set; }

        public string PaymentMode { get; set; } = null!;

        public string CardNumber { get; set; } = null!;

        public string CardName { get; set; } = null!;

        public decimal Price { get; set; }

        public decimal TotalAmount { get; set; }

        public long BookingId { get; set; }

        public virtual Booking Booking { get; set; } = null!;
    }
}

