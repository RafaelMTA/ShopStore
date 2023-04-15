using DAL.Data;

namespace DAL.Models
{
    public class UserProduct
    {
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
