using Microsoft.EntityFrameworkCore;
using Store.Domain.Entity;
using Store.Domain.Repository;
using Store.Infrastructure.DBCore;
using System.Linq.Expressions;

namespace Store.Infrastructure.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(CoreDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
