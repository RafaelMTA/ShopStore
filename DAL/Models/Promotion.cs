using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Promotion : BaseEntity
    {
        [Required]
        [Range(0.01, 99.99)]
        public double Discount { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get
            {
                return Discount.ToString()+"%" + " - " + Start.ToString("dd-MM-yyyy") + " : " + End.ToString("dd-MM-yyyy");
            } }

        [ScaffoldColumn(false)]
        public IEnumerable<Product>? Products { get; set; }
  
    }
}
