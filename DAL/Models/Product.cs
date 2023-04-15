using DAL.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace DAL.Models
{
    [DataContract(Name = "product", Namespace = "")]
    [XmlType(TypeName = "product", Namespace = "")]
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(50, ErrorMessage = "The maximum character is 50")]
        [DataMember(Name = "name")]
        [XmlElement(ElementName = "name", Namespace = "")]
        public string Name { get; set; }
        [StringLength(255, ErrorMessage = "The maximum character is 255")]
        [DataType(DataType.MultilineText)]
        [DataMember(Name = "description")]
        [XmlElement(ElementName = "description", Namespace = "")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, 999999.99)]
        [DataType(DataType.Currency)]
        [DataMember(Name = "price")]
        [XmlElement(ElementName = "price", Namespace = "")]
        public double Price { get; set; }
        [DataType(DataType.ImageUrl)]
        [DataMember(Name = "imageurl")]
        [XmlElement(ElementName = "imageurl", Namespace = "")]
        public string ImageURL { get; set; }
        [DisplayName("Category")]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        [Range(0.01, 999999.99)]
        [DataType(DataType.Currency)]
        [Display(Name = "Final Price")]
        public double FinalPrice {
            get
            {
                if (Promotions == null) return Price;

                foreach (var item in Promotions)
                {
                    if (item.Start >= DateTime.Now && item.End <= DateTime.Now) return Price * item.Discount;
                }

                return Price;
            } 
        }
        [ScaffoldColumn(false)]
        public IEnumerable<Promotion>? Promotions { get; set; }
        [ScaffoldColumn(false)]
        public IEnumerable<ApplicationUser>? Users { get; set; }
    }
}