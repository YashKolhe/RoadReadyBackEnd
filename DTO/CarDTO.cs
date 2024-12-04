using RoadReady.Models;

namespace RoadReady.DTO
{
    public class CarDTO
    {
        public int CarId { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Color { get; set; }
        public decimal PricePerDay { get; set; }
        public string AvailabilityStatus { get; set; } = null!;
        public string? Description { get; set; }
        public virtual ICollection<Reservation>? Reservations { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
