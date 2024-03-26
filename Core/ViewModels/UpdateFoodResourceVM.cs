using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewModels
{
    public class UpdateFoodResourceVM
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public DiscountType DiscountType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPrice { get; set; }
    }
}
