using DAL.Data;

namespace DAL.Models
{
    public class Cart : BaseEntity
    {
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
        public ApplicationUser? User { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
    }
}
