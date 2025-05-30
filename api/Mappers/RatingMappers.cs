using api.DTOs.Rating;
using api.Models;

namespace api.Mappers
{
    public static class RatingMappers
    {
        public static RatingDto ToRatingDto(this Rating rating)
        {
            return new RatingDto
            {
                Id = rating.Id,
                StockRating = (double)rating.StockRating,
                StockId = rating.StockId
            };
        }

        public static Rating ToRatingFromCreate(this CreateRatingDto ratingDto, int stockId)
        {
            // Maps the CreateRatingDto to the Rating model
            return new Rating
            {
                StockRating = ratingDto.StockRating,
                StockId = stockId
            };
        }
    }
}