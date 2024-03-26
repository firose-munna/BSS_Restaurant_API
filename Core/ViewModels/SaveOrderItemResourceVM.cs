using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewModels
{
    public class SaveOrderItemResourceVM
    {
        public int FoodId { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
    }
}
