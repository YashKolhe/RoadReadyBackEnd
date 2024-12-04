using RoadReady.Data;
using RoadReady.Models;

namespace RoadReady.Repositories
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Review> GetAllReviews()
        {
            try
            {
                return _context.Reviews.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Review GetReviewById(int id)
        {
            try
            {
                return _context.Reviews.Find(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Review GetReviewByUserId(int userId)
        {
            try
            {
                return _context.Reviews.Find(userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int AddReview(Review review)
        {
            try
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return review.ReviewId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string UpdateReview(Review review)
        {
            try
            {
                var existingReview = _context.Reviews.Find(review.ReviewId);
                if (existingReview == null) return "Review not found";

                existingReview.Rating = review.Rating;
                existingReview.Comments = review.Comments;

                _context.SaveChanges();
                return "Review updated successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string DeleteReview(int id)
        {
            try
            {
                var existingReview = _context.Reviews.Find(id);
                if (existingReview == null) return "Review not found";

                _context.Reviews.Remove(existingReview);
                _context.SaveChanges();
                return "Review deleted successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
