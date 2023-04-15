using DAL.Ābstraction;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserProductRepository : Repository<UserProduct>, IUserProductRepository
    {
        private readonly ApplicationDbContext _context;
        public UserProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<object> GetTopProducts()
        {
            return _context.UserProducts
                 .GroupBy(p => p.Product.Name)
                    .Select(g => new { Name = g.Key, Count = g.Count() })
                    .OrderByDescending(g => g.Count)
                    .Take(10)
                    .ToList();
        }
    }
}
