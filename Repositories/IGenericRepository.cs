using System.Linq.Expressions;

namespace CarRentalPortal.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //T --> CarType
        IEnumerable<T> GetAll(string? includeProps = null);
        T Get(Expression<Func<T, bool>> filtre, string? includeProps = null);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities); 
    }
}
