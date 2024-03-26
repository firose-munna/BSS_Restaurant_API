using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewModels
{
    public class GetFoodDataVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string DiscountType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPrice { get; set; }
        public string Image { get; set; }
    }
}
