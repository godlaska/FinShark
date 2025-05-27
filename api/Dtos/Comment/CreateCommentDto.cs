using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Comment
{
    public class CreateCommentDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters long.")]
        [MaxLength(280, ErrorMessage = "Title cannot exceed 280 characters.")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Content is required.")]
        [MinLength(5, ErrorMessage = "Content must be at least 5 characters long.")]
        [MaxLength(280, ErrorMessage = "Content cannot exceed 280 characters.")]
        public string Content { get; set; } = string.Empty;
    }
}