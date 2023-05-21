
using Store.Domain.Entity;

namespace Store.Domain.Service
{
    public interface ICustomerService
    {
        Task CreateCustomer(Customer customer);
    }
}
