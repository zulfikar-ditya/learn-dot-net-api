using System.Linq.Expressions;

namespace Interfaces.Repositories
{
    public interface RepositoryInterface<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> filter);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteIn(IEnumerable<T> entities);

        void Save(T entity);
    }
}