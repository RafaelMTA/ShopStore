using DAL.Models;

namespace ShopStore.ViewModel
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<UserProduct> UserProducts { get; set; }
        public IEnumerable<ProductPromotion> ProductPromotions { get; set; }
    }
}
