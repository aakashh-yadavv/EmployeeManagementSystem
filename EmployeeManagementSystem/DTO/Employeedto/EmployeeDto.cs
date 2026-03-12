using EmployeeManagementSystem.DTO.Address;

using EmployeeManagementSystem.Model;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTO.Employeedto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string email { get; set; }
        public int salary { get; set; }
        public DateTime JoinDate { get; set; }
        public int DepartmentId { get; set; }
        public AddressDto Address { get; set; }

     
        
    }
}
