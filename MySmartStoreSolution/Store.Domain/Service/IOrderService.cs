
using Store.Domain.Entity;

namespace Store.Domain.Service
{
    public interface IOrderService
    {
        Task<Order> PlaceOrder(Int64 customerId, List<OrderItem> items);
        //void ShipOrder(Guid orderId);
        //void CancelOrder(Guid orderId);
    }
}
