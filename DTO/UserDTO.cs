using RoadReady.Models;

namespace RoadReady.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Role { get; set; } = null!;

        public virtual ICollection<Reservation>? Reservations { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
