
using Store.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace Store.Application.DTO.Order
{
    public class OrderItemDto
    {
        public Guid? Id { get; set; }
        
        [Required]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        public decimal UnitPrice { get; set; }
    }
}
