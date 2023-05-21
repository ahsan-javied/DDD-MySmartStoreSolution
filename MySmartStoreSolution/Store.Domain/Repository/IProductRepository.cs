
using Store.Domain.Entity;
using static Store.Helper.Enumerations;

namespace Store.Domain.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Tuple<ProductStatus, int>>> GetProductCountByStatuses(List<int> productStatus);
    }
}
