using DAL.Data;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Product : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The maximum character is 50")]
        public string Name { get; set; }
        [StringLength(255, ErrorMessage = "The maximum character is 255")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageURL { get; set; }
        public Category Category { get; set; }

        public IEnumerable<Promotion>? Promotions { get; set; }
        public IEnumerable<ApplicationUser>? Users { get; set; }
        public IEnumerable<ProductPromotion>? ProductPromotions { get; set; }
        public IEnumerable<UserProduct>? UserProducts { get; set; }
    }
}