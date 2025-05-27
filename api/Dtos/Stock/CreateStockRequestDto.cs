using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Stock
{
    public class CreateStockRequestDto
    {
        [Required(ErrorMessage = "Symbol is required.")]
        [MaxLength(10, ErrorMessage = "Symbol cannot exceed 10 characters.")]
        public string Symbol { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company name is required.")]
        [MaxLength(100, ErrorMessage = "Company name cannot exceed 100 characters.")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Purchase is required.")]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }

        [Required(ErrorMessage = "Last dividend is required.")]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required(ErrorMessage = "Industry is required.")]
        [MaxLength(50, ErrorMessage = "Industry cannot exceed 50 characters.")]
        public string Industry { get; set; } = string.Empty;

        [Required(ErrorMessage = "Market cap is required.")]
        [Range(0, 50000000000, ErrorMessage = "Market cap must be a positive number.")]
        public long MarketCap { get; set; }
    }
}