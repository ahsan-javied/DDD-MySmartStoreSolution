using Microsoft.EntityFrameworkCore;
using Store.Domain.Entity;
using Store.Domain.Repository;
using Store.Infrastructure.DBCore;
using System.Linq.Expressions;
using static Store.Helper.Enumerations;

namespace Store.Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CoreDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Tuple<ProductStatus, int>>> GetProductCountByStatuses(List<int> productStatus)
        {
            var productCounts = await _context.Products
                .Where(a => !a.IsDeleted && productStatus.Contains(a.Status))
                .GroupBy(p => p.Status)
                .Select(g => new 
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .AsNoTracking().ToListAsync();

            List<Tuple<ProductStatus, int>> counts = productCounts
                .Select(pc => new Tuple<ProductStatus, int>((ProductStatus)pc.Status, pc.Count))
                .ToList();

            return counts;
        }
    }
}
