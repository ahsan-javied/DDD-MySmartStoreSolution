
namespace Store.Domain.Entity
{
    public class Order : Base
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Int64 CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }
        public int Status { get; set; }
    }
}
