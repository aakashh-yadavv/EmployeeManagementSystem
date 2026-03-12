using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Model
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
