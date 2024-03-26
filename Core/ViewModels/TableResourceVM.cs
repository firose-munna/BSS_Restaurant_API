namespace Core.ViewModels
{
    public class TableResourceVM
    {
        public int Id { get; set; }
        public string TableNumber { get; set; }
        public int NumberOfSeats { get; set; }
        public bool? IsOccupied { get; set; }
        public string Image { get; set; }
        public List<EmployeeWithTableIdResourceVM> Employees { get; set; }
    }
}
