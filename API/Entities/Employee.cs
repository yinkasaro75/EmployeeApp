using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Employee
    {
        [Key]
        public int EmplyeeId { get; set; }
        public string EmployeeName { get; set; }

         public string EmployeeAddress { get; set; }
        public string  PhoneNumber { get; set; }

         public string Position { get; set; }
    }
}