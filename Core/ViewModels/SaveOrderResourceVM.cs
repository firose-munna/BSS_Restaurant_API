using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewModels
{
    public class SaveOrderResourceVM
    {
        public int TableId { get; set; }
        public string OrderNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string PhoneNumber { get; set; }
        public List<SaveOrderItemResourceVM> Items { get; set; }
    }
}
