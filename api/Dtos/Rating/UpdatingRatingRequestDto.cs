namespace api.DTOs.Rating
{
    public class UpdatingRatingRequestDto
    {
        public int StockId { get; set; }
        public double StockRating { get; set; }
    }
}