using BAL.Abstraction;
using DAL.Ābstraction;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class UserProductService : IUserProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(UserProduct entity)
        {
            await _unitOfWork.UserProducts.Create(entity);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<UserProduct>> GetAll()
        {
            return await _unitOfWork.UserProducts.GetAll();
        }

        public async Task<IEnumerable<UserProduct>> GetAll(Expression<Func<UserProduct, bool>> predicte)
        {
            return await _unitOfWork.UserProducts.GetAll(predicte);
        }

        public async Task<IEnumerable<UserProduct>> GetAll(Expression<Func<UserProduct, object>>[] includes)
        {
            return await _unitOfWork.UserProducts.GetAll(includes);
        }

        public async Task<IEnumerable<UserProduct>> GetAll(Expression<Func<UserProduct, bool>> predicte, Expression<Func<UserProduct, object>>[] includes)
        {
            return await _unitOfWork.UserProducts.GetAll(predicte, includes);
        }

        public async Task<IEnumerable<UserProduct>> GetAll(Expression<Func<UserProduct, bool>> predicte, Expression<Func<UserProduct, object>>[] includes, int recordsPerPage, int pageNumber)
        {
            return await _unitOfWork.UserProducts.GetAll(predicte, includes, recordsPerPage, pageNumber);
        }

        public async Task<UserProduct> GetById(Guid id, Expression<Func<UserProduct, object>>[]? includes = null)
        {
            return await _unitOfWork.UserProducts.GetById(id, includes);
        }

        public IEnumerable<object> GetTopProducts()
        {
            return _unitOfWork.UserProducts.GetTopProducts();
        }

        public async Task Remove(Guid id)
        {
            await _unitOfWork.UserProducts.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task Update(Guid id, UserProduct entity)
        {
            _unitOfWork.UserProducts.Update(id, entity);
            await _unitOfWork.Save();
        }
    }
}

