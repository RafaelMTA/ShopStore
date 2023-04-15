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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Create(Category entity)
        {
            await _unitOfWork.Categories.Create(entity);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.Categories.GetAll();
        }

        public async Task<IEnumerable<Category>> GetAll(Expression<Func<Category, bool>> predicte)
        {
            return await _unitOfWork.Categories.GetAll(predicte);
        }

        public async Task<IEnumerable<Category>> GetAll(Expression<Func<Category, object>>[] includes)
        {
            return await _unitOfWork.Categories.GetAll(includes);
        }

        public async Task<IEnumerable<Category>> GetAll(Expression<Func<Category, bool>> predicte, Expression<Func<Category, object>>[] includes)
        {
            return await _unitOfWork.Categories.GetAll(predicte, includes);
        }

        public async Task<IEnumerable<Category>> GetAll(Expression<Func<Category, bool>> predicte, Expression<Func<Category, object>>[] includes, int recordsPerPage, int pageNumber)
        {
            return await _unitOfWork.Categories.GetAll(predicte, includes, recordsPerPage, pageNumber);
        }

        public async Task<Category> GetById(Guid id, Expression<Func<Category, object>>[]? includes = null)
        {
            return await _unitOfWork.Categories.GetById(id, includes);
        }

        public async Task Remove(Guid id)
        {
            await _unitOfWork.Categories.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task Update(Guid id, Category entity)
        {
            _unitOfWork.Categories.Update(id, entity);
            await _unitOfWork.Save();
        }
    }
}
