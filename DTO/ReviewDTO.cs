using RoadReady.Models;

namespace RoadReady.DTO
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public int? CarId { get; set; }
        public int? Rating { get; set; }
        public string? Comments { get; set; }

        public Car? Car { get; set; }
        public virtual User? User { get; set; }
    }
}
