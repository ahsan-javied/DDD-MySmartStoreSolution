
namespace Store.Domain.Entity
{
    public class Product : Base
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int WeightedOrNonWeighted { get; set; }
        public int Status { get; set; }
        public int Quantity { get; set; }
    }
}
