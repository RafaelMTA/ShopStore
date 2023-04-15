using DAL.Ābstraction;
using DAL.Models;
using System.Linq.Expressions;

namespace BAL.Abstraction
{
    public interface IService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicte);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicte, Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicte, Expression<Func<T, object>>[] includes, int recordsPerPage, int pageNumber);
        Task<T> GetById(Guid id, Expression<Func<T, object>>[]? includes = null);
        Task Create(T entity);
        Task Update(Guid id, T entity);
        Task Remove(Guid id);
    }
}
