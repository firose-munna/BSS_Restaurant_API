using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewModels
{
    public class OrderItemResourceVM
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public FoodResourceVM Food { get; set; }
    }
}
