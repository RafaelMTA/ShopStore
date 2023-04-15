using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ProductPromotion : BaseEntity
    {
        [Display(Name = "Product")]
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        [Display(Name = "Promotion")]
        public Guid PromotionId { get; set; }
        public Promotion? Promotion { get; set; }

        [Range(0.01, 999999.99)]
        [DataType(DataType.Currency)]
        [DisplayName("Final Price")]
        public double FinalPrice
        {
            get
            {
                if (Product == null) return 0;
                return Promotion == null ? Product.Price : Product.Price * (1 - Promotion.Discount / 100);
            }
        }
    }
}
