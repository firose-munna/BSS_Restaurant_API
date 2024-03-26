using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DiscountType DiscountType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPrice { get; set; }
        public string Image { get; set; }

        public virtual ICollection<FoodPackage> FoodPackages { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
