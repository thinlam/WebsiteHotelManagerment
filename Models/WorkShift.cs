namespace WebsiteHotelManagerment.Models
{
    public class WorkShift
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public DateTime ShiftDate { get; set; }
        public string ShiftTime { get; set; } // Ví dụ: "Sáng", "Chiều", "Tối"
    }
}