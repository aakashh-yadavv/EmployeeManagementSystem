using AutoMapper;
using EmployeeManagementSystem.DATA;
using EmployeeManagementSystem.DTO;
using EmployeeManagementSystem.DTO.Department;
using EmployeeManagementSystem.DTO.Employeedto;
using EmployeeManagementSystem.Mapper;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.ServiceClass
{
    public class DepServiceClass : IDepartment
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IMapper _mapper;
        public DepServiceClass(EmployeeDbContext employeeDbContext, IMapper mapper)
        {
            _employeeDbContext = employeeDbContext;
            _mapper = mapper;
        }

        //--------------------------------------Create Department--------------------------------------
        public async Task<CreateDepDto> CreateDepart(CreateDepDto createDepDto)
        {
            var Result = _mapper.Map<Department>(createDepDto);
            await _employeeDbContext.AddAsync(Result);
            await _employeeDbContext.SaveChangesAsync();

            return createDepDto;
        }



        //--------------------------------------GEt all Department--------------------------------------
        public async Task<List<DepartmetnDto>> GetAllDepart()
        {
            var result = await _employeeDbContext.Departments
               .ToListAsync();
            return _mapper.Map<List<DepartmetnDto>>(result);
        }


        //--------------------------------------Delete Department by ID--------------------------------------
        public async Task<string> DeleteDepart(int id)
        {
            var empExist = await _employeeDbContext.Employees.AnyAsync(m => m.DepartmentId == id);
            if (empExist)
            {
                return "Cannot delete department because employee exist";
            }
            var dept = await _employeeDbContext.Departments.FindAsync(id);
            if (dept == null)
            {
                return "Ddepartment not found";
            }
            _employeeDbContext.Departments.Remove(dept);
            await _employeeDbContext.SaveChangesAsync();

            return "Department Delete successfully";

        }


        //--------------------------------------Get By Id--------------------------------------
        public async Task<DepartmetnDto> GetById(int id)
        {
            var result = await _employeeDbContext.Departments.Include(m => m.Employees).ThenInclude(m => m.Address)
                 .FirstOrDefaultAsync(m => m.ID == id);
            if (result == null)
            {
                return null;

            }
            return _mapper.Map<DepartmetnDto>(result);
        }




        //--------------------------------------Update Department--------------------------------------
        public async Task<UpdateDepDto> UpdateDepart(int id, UpdateDepDto Updepartment)
        {
            var result = await _employeeDbContext.Departments
                 .FirstOrDefaultAsync(m => m.ID == id);
            result.Name = Updepartment.Name;
            result.Description = Updepartment.Description;
            _employeeDbContext.Departments.Update(result);
            await _employeeDbContext.SaveChangesAsync();
            return _mapper.Map<UpdateDepDto>(result);
        }



        //--------------------------------------Employee Count-------------------------------------- 
        public async Task<List<ResponseDepDto>> GetAllDepartments()
        {
            var data = await _employeeDbContext.Departments
                 .Select(m => new ResponseDepDto
                 {
                     ID = m.ID,
                     Name = m.Name,
                     EmployeeCount = m.Employees.Count
                 })
                 .ToListAsync();
            return data;
        }


    }
}
