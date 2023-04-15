using DAL.Ābstraction;
using DAL.Data;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(context);
            Products = new ProductRepository(context);
            Promotions = new PromotionRepository(context);
            ProductPromotions = new ProductPromotionsRepository(context);
            UserProducts = new UserProductRepository(context);
            Carts = new CartRepository(context);
        }
        public ICategoryRepository Categories { get; private set; }

        public IProductRepository Products { get; private set; }

        public IPromotionRepository Promotions { get; private set; }

        public IProductPromotionRepository ProductPromotions { get; private set; }

        public IUserProductRepository UserProducts { get; private set; }
        public ICartRepository Carts { get; private set; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
