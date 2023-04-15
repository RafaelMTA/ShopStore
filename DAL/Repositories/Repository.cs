using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DAL.Models;
using System;

namespace DAL.Ābstraction
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task Create(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public virtual async void Update(Guid id, T entity)
        {
            if(id != entity.Id) throw new ArgumentNullException("id");

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Summary
        public virtual async Task Delete(Guid id)
        {
            var result = await _context.Set<T>().FindAsync(id);

            if (result == null) throw new Exception(); //No Entity found

            try
            {
                _context.Set<T>().Remove(result);
            }
            catch
            {
                throw new Exception(); //Error on context remove entity
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = _context.Set<T>();

                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                return await query.ToListAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate, Expression<Func<T, object>>[] includes)
        {
            try
            {
                var query = _context.Set<T>().Where(predicate);
                foreach (Expression<Func<T, object>> i in includes)
                {
                    query = query.Include(i);
                }
                return await query.ToListAsync();
            }
            catch
            {
                throw new Exception();
            }
        }
        public virtual async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[]? includes, int recordsPerPage, int pageNumber)
        {
            try
            {
                var query = _context.Set<T>().Where(predicate);
                foreach (Expression<Func<T, object>> i in includes)
                {
                    query = query.Include(i);
                }
                return await query.Skip((pageNumber - 1)  * recordsPerPage).Take(recordsPerPage).ToListAsync();
            }
            catch
            {
                throw new Exception();
            }

        }
        public virtual async Task<T> GetById(Guid id, Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> query = _context.Set<T>();

            // Apply the includes to the query
            if(includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }          

            return query.FirstOrDefault(x => x.Id == id);

            //var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            //if (result == null) throw new Exception();

            //foreach (Expression<Func<T, object>> i in includes)
            //{
            //    result = result.Include(i);
            //}

            //try
            //{
            //    return result;
            //}
            //catch
            //{
            //    throw new Exception();
            //}
        }
  
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
