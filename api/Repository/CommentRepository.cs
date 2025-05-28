using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        // Constructor
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.Include(a => a.AppUser).ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment comment)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);  // id?
            if (existingComment == null)
            {
                return null; // Comment not found
            }

            existingComment.Title = comment.Title;
            existingComment.Content = comment.Content;

            await _context.SaveChangesAsync();
            return existingComment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (commentModel == null)
            {
                return null; // Comment not found
            }

            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel; // Return the deleted comment
        }
    }
}