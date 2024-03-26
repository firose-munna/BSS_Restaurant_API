using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int? FoodId { get; set; }
        public int? FoodPackageId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public Order Order { get; set; }
        public Food Food { get; set; }
        public FoodPackage FoodPackage { get; set; }

    }
}
