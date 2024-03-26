using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public virtual ICollection<FoodPackage> FoodPackages { get; set; }
    }
}
