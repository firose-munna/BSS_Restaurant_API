using Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewModels
{
    public class OrderResourceVM
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderTime { get; set; }
        public TableResourceVM Table { get; set; }
        public List<OrderItemResourceVM> OrderItems { get; set; }
    }
}
