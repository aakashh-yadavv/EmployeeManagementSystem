using AutoMapper;
using EmployeeManagementSystem.DATA;
using EmployeeManagementSystem.DTO.Address;
using EmployeeManagementSystem.Mapper;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repository.Implement
{
    public class AddressService : IAddress
    {

        private readonly EmployeeDbContext _employeeDbContext;
        private readonly IMapper _mapper;
        public AddressService(EmployeeDbContext employeeDbContext, IMapper mapper)
        {
            _employeeDbContext = employeeDbContext;
            _mapper = mapper;
        }


        //--------------------------------------update--------------------------------------

        public async Task<UpdateAddress> UpdateAddress(UpdateAddress updateAddress, int id)
        {
           var result = await _employeeDbContext.Addresses.FirstOrDefaultAsync(z=>z.EmployeeId == id);
            if (result == null)
            {
                return null;
            }
            result.State = updateAddress.State;
            result.City = updateAddress.City;
            result.Country = updateAddress.Country;
            _employeeDbContext.Addresses.Update(result);
            await _employeeDbContext.SaveChangesAsync();
            return _mapper.Map<UpdateAddress>(result);
        }
    }
}
