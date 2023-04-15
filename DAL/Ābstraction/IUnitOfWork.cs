using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Ābstraction
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IPromotionRepository Promotions { get; }
        IProductPromotionRepository ProductPromotions { get; }
        IUserProductRepository UserProducts { get; }
        ICartRepository Carts { get; }
        Task Save();
    }
}
