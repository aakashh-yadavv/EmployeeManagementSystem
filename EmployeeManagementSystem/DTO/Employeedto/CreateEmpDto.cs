using EmployeeManagementSystem.DTO.Address;

namespace EmployeeManagementSystem.DTO.Employeedto
{
    public class CreateEmpDto
    {
        public string EmpName { get; set; }
        public string email { get; set; }
        public int salary { get; set; }
        public AddressDto Address { get; set; } 
    }
}
