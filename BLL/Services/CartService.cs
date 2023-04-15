using BAL.Abstraction;
using DAL.Ābstraction;
using DAL.Models;
using System.Linq.Expressions;

namespace BAL.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(Cart entity)
        {
            await _unitOfWork.Carts.Create(entity);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await _unitOfWork.Carts.GetAll();
        }

        public async Task<IEnumerable<Cart>> GetAll(Expression<Func<Cart, bool>> predicte)
        {
            return await _unitOfWork.Carts.GetAll(predicte);
        }

        public async Task<IEnumerable<Cart>> GetAll(Expression<Func<Cart, object>>[] includes)
        {
            return await _unitOfWork.Carts.GetAll(includes);
        }

        public async Task<IEnumerable<Cart>> GetAll(Expression<Func<Cart, bool>> predicte, Expression<Func<Cart, object>>[] includes)
        {
            return await _unitOfWork.Carts.GetAll(predicte, includes);
        }

        public async Task<IEnumerable<Cart>> GetAll(Expression<Func<Cart, bool>> predicte, Expression<Func<Cart, object>>[] includes, int recordsPerPage, int pageNumber)
        {
            return await _unitOfWork.Carts.GetAll(predicte, includes, recordsPerPage, pageNumber);
        }

        public async Task<Cart> GetById(Guid id, Expression<Func<Cart, object>>[]? includes = null)
        {
            return await _unitOfWork.Carts.GetById(id, includes);
        }

        public async Task Remove(Guid id)
        {
            await _unitOfWork.Carts.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task Update(Guid id, Cart entity)
        {
            _unitOfWork.Carts.Update(id, entity);
            await _unitOfWork.Save();
        }
    }
}
