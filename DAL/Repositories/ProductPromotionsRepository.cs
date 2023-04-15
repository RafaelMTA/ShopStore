using DAL.Ābstraction;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductPromotionsRepository : Repository<ProductPromotion>, IProductPromotionRepository
    {
        public ProductPromotionsRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
