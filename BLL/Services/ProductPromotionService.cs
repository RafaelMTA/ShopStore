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
    public class ProductPromotionService : IProductPromotionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductPromotionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(ProductPromotion entity)
        {
            await _unitOfWork.ProductPromotions.Create(entity);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<ProductPromotion>> GetAll()
        {
            return await _unitOfWork.ProductPromotions.GetAll();
        }

        public async Task<IEnumerable<ProductPromotion>> GetAll(Expression<Func<ProductPromotion, bool>> predicte)
        {
            return await _unitOfWork.ProductPromotions.GetAll(predicte);
        }

        public async Task<IEnumerable<ProductPromotion>> GetAll(Expression<Func<ProductPromotion, object>>[] includes)
        {
            return await _unitOfWork.ProductPromotions.GetAll(includes);
        }

        public async Task<IEnumerable<ProductPromotion>> GetAll(Expression<Func<ProductPromotion, bool>> predicte, Expression<Func<ProductPromotion, object>>[] includes)
        {
            return await _unitOfWork.ProductPromotions.GetAll(predicte, includes);
        }
        public async Task<IEnumerable<ProductPromotion>> GetAll(Expression<Func<ProductPromotion, bool>> predicte, Expression<Func<ProductPromotion, object>>[] includes, int recordsPerPage, int pageNumber)
        {
            return await _unitOfWork.ProductPromotions.GetAll(predicte, includes, recordsPerPage, pageNumber);
        }

        public async Task<ProductPromotion> GetById(Guid id, Expression<Func<ProductPromotion, object>>[]? includes = null)
        {
            return await _unitOfWork.ProductPromotions.GetById(id, includes);
        }

        public async Task Remove(Guid id)
        {
            await _unitOfWork.ProductPromotions.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task Update(Guid id, ProductPromotion entity)
        {
            _unitOfWork.ProductPromotions.Update(id, entity);
            await _unitOfWork.Save();
        }
    }
}
