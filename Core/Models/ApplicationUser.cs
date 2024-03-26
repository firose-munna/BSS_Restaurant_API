using Microsoft.AspNetCore.Identity;

namespace Core.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
      
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SpouseName { get; set; }
        public string NID { get; set; }
        public DateTime DOB { get; set; }
        public int GenderId { get; set; }
        public string Image { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Order> OrdersForEmployee { get; set; }
        public ICollection<Order> OrdersForCustomer { get; set; }
    }
}
