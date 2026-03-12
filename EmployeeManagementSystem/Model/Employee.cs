using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string email { get; set; }
        public int salary { get; set; }
        public DateTime JoinDate { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        public Address Address { get; set; }

    }
}
