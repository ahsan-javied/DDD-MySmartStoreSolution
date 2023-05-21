using Store.Domain.Entity;
using Store.Domain.Service;
using Store.Domain.UOW;
using System.Linq;
using static Store.Helper.Enumerations;

namespace Store.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _unitOfWork.ProductRepository.GetSingleBy(a => !a.IsDeleted && a.Id == id);
        }

        public async Task CreateProduct(Product product)
        {
            await _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.Save();
        }

        public async Task<List<Tuple<ProductStatus, int>>> GetProductCountByStatus(List<int> productStatus)
        {
            return await _unitOfWork.ProductRepository.GetProductCountByStatuses(productStatus);
        }

        public async Task<bool> ChangeProductStatus(Guid productId, ProductStatus newStatus)
        {
            var product = await GetById(productId);
            if (product != null)
            {
                product.Status = (int)newStatus;
                product.UpdatedBy = 1;
                product.UpdatedDate = DateTime.UtcNow;

                _unitOfWork.ProductRepository.Edit(product);
                await _unitOfWork.Save();
                return true;
            }
            return false;
        }

    }
}
