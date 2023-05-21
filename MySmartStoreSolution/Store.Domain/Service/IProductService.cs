
using Store.Domain.Entity;
using static Store.Helper.Enumerations;

namespace Store.Domain.Service
{
    public interface IProductService
    {
        Task<Product> GetById(Guid id);
        Task CreateProduct(Product product);
        //void UpdateProduct(Product product);
        //void DeleteProduct(Guid id);
        Task<List<Tuple<ProductStatus, int>>> GetProductCountByStatus(List<int> productStatus);
        Task<bool> ChangeProductStatus(Guid productId, ProductStatus newStatus);
    }
}
