using RoadReady.Models;
using RoadReady.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using RoadReady.Exceptions;
using Microsoft.EntityFrameworkCore;
using RoadReady.Data;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace RoadReady.Controllers
{
    [EnableCors("Policy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IReviewService _reviewService;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(ApplicationDbContext context,IReviewService reviewService, ILogger<ReviewController> logger)
        {
            _context = context;
            _reviewService = reviewService;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                _logger.LogInformation("Retrieving all reviews.");
                var reviews = _reviewService.GetAllReviews();
                return Ok(reviews);
            }
            catch(ReviewNotFoundException)
            {
                _logger.LogError("Failed to retrieve all reviews.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetReviewById(int id)
        {
            try
            {
                var review = _reviewService.GetReviewById(id);
                if (review == null)
                {
                    _logger.LogWarning($"Review with ID: {id} not found.");
                    return NotFound("Review not found");
                }
                return Ok(review);
            }
            catch(ReviewNotFoundException)
            {
                _logger.LogError($"Failed to retrieve review with ID: {id}");
                return StatusCode(500, "Internal server error");
            }
        }
        [AllowAnonymous]
        [HttpGet("user/{userId}")]
        public IActionResult GetReviewByUserId(int userId)
        {
            try
            {
                var review = _reviewService.GetReviewByUserId(userId);
                if (review == null)
                {
                    _logger.LogWarning($"Review with ID: {userId} not found.");
                    return NotFound("Review not found");
                }
                return Ok(review);
            }
            catch (ReviewNotFoundException)
            {
                _logger.LogError($"Failed to retrieve review with ID: {userId}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("car/{carId}")]
        public async Task<IActionResult> GetReviewsByCarId(int carId)
        {
            // Check if the car exists
            var car = await _context.Cars.FindAsync(carId);
            if (car == null)
            {
                return NotFound(new { message = "Car not found." });
            }

            // Retrieve reviews for the given car
            var reviews = await _context.Reviews
                                        .Where(r => r.CarId == carId)
                                        .Include(r => r.Car) 
                                        .ToListAsync();

            if (reviews == null || reviews.Count == 0)
            {
                return NotFound(new { message = "No reviews found for this car." });
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,  // Preserve object references to handle circular references
                WriteIndented = true // Optional: makes the output JSON more readable (pretty print)
            };

            // Serialize the reviews with circular reference handling
            var json = JsonSerializer.Serialize(reviews, options);

            // Return the reviews as JSON
            return Content(json, "application/json");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(Review review)
        {
            try
            {
                _logger.LogInformation("Creating new review.");
                var result = _reviewService.AddReview(review);
                return CreatedAtAction(nameof(GetReviewById), new { id = result }, review);
            }
            catch (Exception)
            {
                _logger.LogError("Failed to create new review.");
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult Put(Review review)
        {
            try
            {
                var result = _reviewService.UpdateReview(review);
                if (result == "Review not found")
                {
                    _logger.LogWarning("Review not found.");
                    return NotFound(result); 
                }

                return Ok(result);
            }
            catch (ReviewNotFoundException)
            {
                return NotFound("Review not found.");
            }
            catch (Exception)
            {
                _logger.LogError("Failed to update review");
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting car review with ID: {id}");
                var result = _reviewService.DeleteReview(id);
                if (result == "Review not found")
                    return NotFound(result);

                return Ok(result);
            }
            catch (Exception)
            {
                _logger.LogError($"Failed to delete review with ID: {id}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
