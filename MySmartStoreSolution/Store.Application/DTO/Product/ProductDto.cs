using System.ComponentModel.DataAnnotations;

namespace Store.Application.DTO.Product
{
    public class ProductDto
    {
        public Guid? Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Barcode { get; set; }
        public string Description { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        public int WeightedOrNonWeighted { get; set; }
        public int Status { get; set; }
        
        [Required]
        public int Quantity { get; set; }
    }
}
