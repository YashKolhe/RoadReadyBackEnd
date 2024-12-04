using System;
using System.Collections.Generic;

namespace RoadReady.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            Payments = new HashSet<Payment>();
        }

        public int ReservationId { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DropoffDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Car? Car { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
