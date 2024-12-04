using System;
using System.Collections.Generic;

namespace RoadReady.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? ReservationId { get; set; }
        public int? UserId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentMethod { get; set; }
        public string Status { get; set; } = null!;

        public virtual Reservation? Reservation { get; set; }
        public virtual User? User { get; set; }
    }
}
