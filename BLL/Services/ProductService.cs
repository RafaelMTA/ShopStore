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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(Product entity)
        {
            await _unitOfWork.Products.Create(entity);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.Products.GetAll();
        }

        public async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>> predicte)
        {
            return await _unitOfWork.Products.GetAll(predicte);
        }

        public async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, object>>[] includes)
        {
            return await _unitOfWork.Products.GetAll(includes);
        }

        public async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>> predicte, Expression<Func<Product, object>>[] includes)
        {
            return await _unitOfWork.Products.GetAll(predicte, includes);
        }

        public async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>> predicte, Expression<Func<Product, object>>[] includes, int recordsPerPage, int pageNumber)
        {
            return await _unitOfWork.Products.GetAll(predicte, includes, recordsPerPage, pageNumber);
        }

        public async Task<Product> GetById(Guid id, Expression<Func<Product, object>>[]? includes = null)
        {
            return await _unitOfWork.Products.GetById(id, includes);
        }

        public async Task Remove(Guid id)
        {
            await _unitOfWork.Products.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task Update(Guid id, Product entity)
        {
            _unitOfWork.Products.Update(id, entity);
            await _unitOfWork.Save();
        }
    }
}
