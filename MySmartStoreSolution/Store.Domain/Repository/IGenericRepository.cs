using System.Linq.Expressions;

namespace Store.Domain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAllNonTracking();
        Task<List<T>> GetBy(Expression<Func<T, bool>> predicate);
        List<T> GetNonTrackingBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task<T> GetSingleBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        T GetSingleNonTrackingBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task<int> GetCount(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Detach(T entity);
        void DetachAll(List<T> entities);
        void Save();
    }
}