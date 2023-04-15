using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ābstraction
{
    public interface IUserProductRepository : IRepository<UserProduct>
    {
        IEnumerable<object> GetTopProducts();
    }
}
