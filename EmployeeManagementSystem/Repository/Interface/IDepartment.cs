using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.DTO.Department;

namespace EmployeeManagementSystem.Repository.Interface
{
    public interface IDepartment
    {
        Task<List<DepartmetnDto>> GetAllDepart();
        Task<List<ResponseDepDto>> GetAllDepartments();
        Task<CreateDepDto> CreateDepart(CreateDepDto createDepDto);
        Task<UpdateDepDto> UpdateDepart(int id, UpdateDepDto Updepartment);
        Task<string>DeleteDepart(int id);
       
    
    }
}
