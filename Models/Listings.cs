using System.ComponentModel.DataAnnotations;

namespace RealEstateListingApi.Models
{
    public class Listing
    {
        [StringLength(36)]
        public string Id { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }
    }
}