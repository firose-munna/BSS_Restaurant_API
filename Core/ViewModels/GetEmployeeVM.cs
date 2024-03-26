using System.ComponentModel.DataAnnotations.Schema;

namespace Core.ViewModels
{
    public class GetEmployeeVM
    {
        public Guid Id { get; set; }
        public string Designation { get; set; }
        public string JoinDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? AmountSold { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
    }
}
