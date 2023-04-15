using DAL.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class UserProduct : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
