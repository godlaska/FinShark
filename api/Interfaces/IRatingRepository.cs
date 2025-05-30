using api.Models;

namespace api.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetAllAsync(); // Get all ratings
        Task<Rating?> GetByIdAsync(int id); // Get rating by Id
        Task<Rating> CreateAsync(Rating rating); // Create a new rating
        Task<Rating?> UpdateAsync(int id, Rating rating); // Update an existing rating
        Task<Rating?> DeleteAsync(int id); // Delete a rating by Id
        Task<bool> RatingExists(int id); // Check if a rating exists by Id
    }
}