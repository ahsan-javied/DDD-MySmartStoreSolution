using Microsoft.EntityFrameworkCore;
using Store.Domain.Repository;
using Store.Infrastructure.DBCore;

namespace Store.Infrastructure.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public CoreDBContext _context;
        public GenericRepository(CoreDBContext context)
        {
            this._context = context;
            this._context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public virtual List<T> GetAll()
        {
            List<T> collection = _context.Set<T>().ToList();
            return collection;
        }

        public async Task<List<T>> GetBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            List<T> collection = await _context.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
            return collection;
        }

        public async Task<T> GetSingleBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            T entity = await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
            return entity;
        }

        public T GetSingleNonTrackingBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            T entity = _context.Set<T>().Where(predicate).AsNoTracking().FirstOrDefault();
            return entity;
        }

        public virtual List<T> GetAllNonTracking()
        {

            List<T> collection = _context.Set<T>().AsNoTracking().ToList();
            return collection;
        }

        public List<T> GetNonTrackingBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            List<T> collection = _context.Set<T>().Where(predicate).AsNoTracking().ToList();
            return collection;
        }

        public async Task<int> GetCount(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().CountAsync(predicate);
        }


        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public virtual void DetachAll(List<T> entities)
        {
            if (entities != null)
            {
                foreach (var changeEntry in entities)
                {
                    _context.Entry(changeEntry).State = EntityState.Detached;
                }
            }
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
