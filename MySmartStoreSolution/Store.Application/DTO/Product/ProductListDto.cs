using System.ComponentModel.DataAnnotations;

namespace Store.Application.DTO.Product
{
    public class ProductStatusListDto
    {
        [Required]
        public List<int> ProductStatus { get; set; }
    }
}
