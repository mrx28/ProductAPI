using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Dto
{
    public class ProductDto
    {
        [Required]
        [MaxLength(25)]
        public string? Code { get; set; }
        [Required]
        [MaxLength(250)]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
