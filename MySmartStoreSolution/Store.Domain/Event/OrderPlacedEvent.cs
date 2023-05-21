
namespace Store.Domain.Event
{
    public class OrderPlacedEvent
    {
        public Guid OrderId { get; }
        public DateTime PlacedAt { get; }

        public OrderPlacedEvent(Guid orderId, DateTime placedAt)
        {
            OrderId = orderId;
            PlacedAt = placedAt;
        }
    }
}
