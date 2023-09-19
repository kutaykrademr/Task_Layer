using System.Linq.Expressions;
using Task.Core.Entities;

namespace Task.Core.DataAccess
{
    public interface IEntityRepository<T> where T : IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
