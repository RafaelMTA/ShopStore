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
    public class PromotionService : IPromotionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PromotionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(Promotion entity)
        {
            await _unitOfWork.Promotions.Create(entity);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<Promotion>> GetAll()
        {
            return await _unitOfWork.Promotions.GetAll();
        }

        public async Task<IEnumerable<Promotion>> GetAll(Expression<Func<Promotion, bool>> predicte)
        {
            return await _unitOfWork.Promotions.GetAll(predicte);
        }

        public async Task<IEnumerable<Promotion>> GetAll(Expression<Func<Promotion, object>>[] includes)
        {
            return await _unitOfWork.Promotions.GetAll(includes);
        }

        public async Task<IEnumerable<Promotion>> GetAll(Expression<Func<Promotion, bool>> predicte, Expression<Func<Promotion, object>>[] includes)
        {
            return await _unitOfWork.Promotions.GetAll(predicte, includes);
        }
        public async Task<IEnumerable<Promotion>> GetAll(Expression<Func<Promotion, bool>> predicte, Expression<Func<Promotion, object>>[] includes, int recordsPerPage, int pageNumber)
        {
            return await _unitOfWork.Promotions.GetAll(predicte, includes, recordsPerPage, pageNumber);
        }

        public async Task<Promotion> GetById(Guid id, Expression<Func<Promotion, object>>[]? includes = null)
        {
            return await _unitOfWork.Promotions.GetById(id, includes);
        }

        public async Task Remove(Guid id)
        {
            await _unitOfWork.Promotions.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task Update(Guid id, Promotion entity)
        {
            _unitOfWork.Promotions.Update(id, entity);
            await _unitOfWork.Save();
        }
    }
}
