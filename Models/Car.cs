using System;
using System.Collections.Generic;

namespace RoadReady.Models
{
    public partial class Car
    {
        public Car()
        {
            Reservations = new HashSet<Reservation>();
            Reviews = new HashSet<Review>();
        }

        public int CarId { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public string? Color { get; set; }
        public decimal PricePerDay { get; set; }
        public string AvailabilityStatus { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Reservation>? Reservations { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
