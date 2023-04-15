using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Promotion : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Range(0.01, 99.99)]
        public double Discount { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<ProductPromotion>? ProductPromotions { get; set; }
    }
}
