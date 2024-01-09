using System.Linq.Expressions;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using PokemonReview.Data;

namespace Repositories
{
    public class Repository<T> : RepositoryInterface<T> where T : class
    {
        private readonly DataContext _dataContext;

        internal DbSet<T> _dbSet;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> queryable = _dbSet;

            return queryable.ToList();
        }
        
        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> queryable = _dbSet;

            return queryable.Where(filter).FirstOrDefault();
        }


        public void Create(T entity)
        {
            _dataContext.Add(entity);
        }

        public void Update(T entity)
        {
            _dataContext.Update(entity);
        }

        public void Delete(T entity)
        {
            _dataContext.Remove(entity);
        }

        public void DeleteIn(IEnumerable<T> entities)
        {
            _dataContext.RemoveRange(entities);
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        public bool IsExist(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> queryable = _dbSet;

            return queryable.Any(filter);
        }
    }
}