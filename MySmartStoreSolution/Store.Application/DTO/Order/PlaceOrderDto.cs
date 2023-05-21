using System.ComponentModel.DataAnnotations;

namespace Store.Application.DTO.Order
{
    public class PlaceOrderDto
    {
        [Required]
        public Int64 CustomerId { get; set; }
        
        [Required]
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
