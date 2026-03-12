using EmployeeManagementSystem.DTO.Employeedto;

namespace EmployeeManagementSystem.Repository.Interface
{
    public interface IEmployees
    {
        Task<CreateEmpDto> CreateAsync(CreateEmpDto createEmpDto , int id);
        Task<EmployeeDto> UpdateEmp(int id, UpdateEmployeeDto updateEmployeeDto);
        Task<List<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetById(int id);
        Task<EmployeeDto> GetByName(string name);
        Task<EmployeeDto> GetByDepartmen(int id);
        Task<bool> DeleteEm(int id);
        Task<List<SortedEmpDto>> SortedName();
        Task<List<EmployeeDto>> Pagination(int pageNumber, int pageSize);
        

    }
}
