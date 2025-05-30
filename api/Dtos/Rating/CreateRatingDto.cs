using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Rating
{
    public class CreateRatingDto
    {
        [Range(1.0, 5.0, ErrorMessage = "Rating must be between 1 and 5.")]
        public decimal StockRating { get; set; }
    }
}