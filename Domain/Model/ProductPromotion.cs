using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class ProductPromotion
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid PromotionId { get; set; }
        public Promotion? Promotion { get; set; }
    }
}
