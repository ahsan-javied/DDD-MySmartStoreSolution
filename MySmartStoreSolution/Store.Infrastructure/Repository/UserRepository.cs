using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Store.Domain.Entity;
using Store.Domain.Repository;
using Store.Infrastructure.DBCore;
using System.Linq.Expressions;

namespace Store.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CoreDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
