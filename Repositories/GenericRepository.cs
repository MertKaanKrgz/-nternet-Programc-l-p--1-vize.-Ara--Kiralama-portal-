using CarRentalPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarRentalPortal.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _appDbcontext;
        internal DbSet<T> dbSet;  
        public GenericRepository(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext; 
            this.dbSet = _appDbcontext.Set<T>();
            _appDbcontext.Cars.Include(k => k.CarType).Include(k => k.CarTypeId);

            //Bundan sonra _appDbContext--->dbSet olarak kullanılacak.
            //dbSet = _appDbcontext.CarTypes
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);  
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> filtre, string? includeProps = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filtre);

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> query = dbSet;

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach(var includeProp in includeProps.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.ToList();
        }
    }
}