using RoadReady.Models;

namespace RoadReady.DTO
{
    public class PaymentDTO
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
