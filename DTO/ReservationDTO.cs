using RoadReady.Models;

namespace RoadReady.DTO
{
    public class ReservationDTO
    {
        public int ReservationId { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DropoffDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = null!;

        public virtual Car? Car { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
