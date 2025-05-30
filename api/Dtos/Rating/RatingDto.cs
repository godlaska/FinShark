using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Rating
{
    public class RatingDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "StockRating is required.")]
        [Range(1.0, 5.0, ErrorMessage = "StockRating must be between 1 and 5, decimals allowed.")]
        public double StockRating { get; set; }
        [Required(ErrorMessage = "StockId is required.")]
        public int StockId { get; set; }
    }
}