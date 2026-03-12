using AutoMapper;
using EmployeeManagementSystem.DATA;
using EmployeeManagementSystem.DTO.Employeedto;
using EmployeeManagementSystem.Mapper;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagementSystem.Repository.Implement
{
    public class EmpService : IEmployees
    {
        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IMapper _mapper;
        public EmpService(EmployeeDbContext employeeDbContext, IMapper mapper)
        {
            _employeeDbContext = employeeDbContext;
            _mapper = mapper;
        }


        //--------------------------------------Create Employees--------------------------------------
        public async Task<CreateEmpDto> CreateAsync(CreateEmpDto createEmpDto , int id)
        {
            var result = _mapper.Map<Employee>(createEmpDto);
         var departmetn= await _employeeDbContext.Departments.FirstOrDefaultAsync(m => m.ID == id);
            if(departmetn == null)
            {
                return null;
            }
            result.DepartmentId = id;
            await _employeeDbContext.AddAsync(result);
            await _employeeDbContext.SaveChangesAsync();
            
            return _mapper.Map<CreateEmpDto>(result);
        }


        //--------------------------------------Delete Employees--------------------------------------
        public async Task<bool> DeleteEm(int id)
        {
            var result = await _employeeDbContext.Employees.Include(m => m.Address)
                 .FirstOrDefaultAsync(m => m.Id == id);
            if (result == null)
            {
                return false;
            }

            _employeeDbContext.Employees.Remove(result);
            await _employeeDbContext.SaveChangesAsync();
            return true;
        }


        //--------------------------------------Get EMployee-----------------------------------------------
        public async Task<List<EmployeeDto>> GetAll()
        {
           var result =await _employeeDbContext.Employees.Include(m=>m.Address).ToListAsync();
            return _mapper.Map<List<EmployeeDto>>(result);
        }

       
        //-----------------------------------------Get by Id------------------------------------------
        public async Task<EmployeeDto> GetById(int id)
        {
            var empll = await _employeeDbContext.Employees.Include(a => a.Address).FirstOrDefaultAsync(m => m.Id == id);
            if(empll == null)
            {
                return null;

            }
            return _mapper.Map<EmployeeDto>(empll);
          
        }


        //-----------------------------------------Get By Name------------------------------------------
        public async Task<EmployeeDto> GetByName(string name)
        {
           var md = await _employeeDbContext.Employees.Include(m=>m.Address)
                .FirstOrDefaultAsync(a=>a.EmpName.ToLower()== name.ToLower());
            if (md == null)
            {
                return null;
            }
            return _mapper.Map<EmployeeDto>(md);
        }


        //------------------------------------Update Employees------------------------------------------
        public async Task<EmployeeDto> UpdateEmp(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var result = await _employeeDbContext.Employees
                 .FirstOrDefaultAsync(m => m.Id == id);
            if (result == null)
            {
                return null;
            }
            result.EmpName = updateEmployeeDto.EmpName;
            result.salary = updateEmployeeDto.salary;
            result.email = updateEmployeeDto.email;
            _employeeDbContext.Employees.Update(result);
            await _employeeDbContext.SaveChangesAsync();
            return _mapper.Map<EmployeeDto>(result);

        }


        //---------------------------------------Get by Department ID-------------------------------
        public async Task<EmployeeDto> GetByDepartmen(int id)
        {

            var dep = await _employeeDbContext.Employees.Include(m => m.Address)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if(dep == null)
            {
                return null;
            }
            return _mapper.Map<EmployeeDto>(dep);
        }


        //-----------------------------------Sort By name----------------------------------------- 
        public async Task<List<SortedEmpDto>> SortedName()
        {
           var sortname = await _employeeDbContext.Employees.OrderBy(a=>a.EmpName).ToListAsync();
            return _mapper.Map<List<SortedEmpDto>>(sortname);
        }


        //---------------------------Pagination Default set on 1 to 5-------------------------------
        public async Task<List<EmployeeDto>> Pagination(int pageNumber, int pageSize)
        {
            var emp = await _employeeDbContext.Employees
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return _mapper.Map<List<EmployeeDto>>(emp);
        }
    }
}
