using Microsoft.EntityFrameworkCore;
using Store.Domain.Entity;
using Store.Domain.Repository;
using Store.Infrastructure.DBCore;
using System.Linq.Expressions;

namespace Store.Infrastructure.Repository
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(CoreDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
