using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Category : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The maximum character is 50")]
        public string Name { get; set; }
        [StringLength(255, ErrorMessage = "The maximum character is 50")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
