using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Ratings")]
    public class Rating
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        public decimal StockRating { get; set; }
        public int StockId { get; set; }
    }
}