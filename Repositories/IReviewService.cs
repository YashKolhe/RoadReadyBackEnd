using RoadReady.Models;

namespace RoadReady.Repositories
{
    public interface IReviewService
    {
        List<Review> GetAllReviews();
        Review GetReviewById(int id);
        Review GetReviewByUserId(int userId);
        int AddReview(Review review);
        string UpdateReview(Review review);
        string DeleteReview(int id);
    }
}
