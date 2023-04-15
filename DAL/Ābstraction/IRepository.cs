using DAL.Models;
using System.Linq.Expressions;

namespace DAL.Ābstraction
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        void Update(Guid id, T entity);
        Task Delete(Guid id);
        Task<T> GetById(Guid id, Expression<Func<T, object>>[]? includes);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includes, int recordsPerPage, int pageNumber);
        Task Save();
    }
}
