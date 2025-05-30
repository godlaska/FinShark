using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDBContext _context;
        public RatingRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Rating> CreateAsync(Rating rating)
        {
            throw new NotImplementedException();
        }

        public Task<Rating?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Rating>> GetAllAsync()
        {
            return await _context.Ratings.ToListAsync();
        }

        public Task<Rating?> GetByIdAsync(int id)
        {
            return _context.Ratings.FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<bool> RatingExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Rating?> UpdateAsync(int id, Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}