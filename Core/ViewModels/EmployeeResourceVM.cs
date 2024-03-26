using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewModels
{
    public class EmployeeResourceVM
    {
        public Guid Id { get; set; }
        public string Designation { get; set; }
        public DateTime JoinDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AmountSold { get; set; }
        public ApplicationUser User { get; set; }
    }
}
