
using Store.Domain.Repository;

namespace Store.Domain.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }

        public Task Save();
    }
}
