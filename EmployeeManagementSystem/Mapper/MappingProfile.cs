using AutoMapper;
using System.Runtime;
using AutoMapper;
using EmployeeManagementSystem.DTO.Employeedto;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.DTO.Department;
using EmployeeManagementSystem.DTO.Address;

namespace EmployeeManagementSystem.Mapper
{
   

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Department, DepartmetnDto>();
            CreateMap<DepartmetnDto, Department>();
            CreateMap<UpdateDepDto ,Department>().ReverseMap();
            CreateMap<CreateDepDto ,Department>().ReverseMap();
            
            


            CreateMap<Employee, EmployeeDto>();
               
            CreateMap<EmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();
            CreateMap<CreateEmpDto , Employee>().ReverseMap();
            CreateMap<SortedEmpDto, Employee>().ReverseMap();




            
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<UpdateAddress, Address>().ReverseMap();
            
        }
    }
}
