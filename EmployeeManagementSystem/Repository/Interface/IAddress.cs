using EmployeeManagementSystem.DTO.Address;

namespace EmployeeManagementSystem.Repository.Interface
{
    public interface IAddress
    {
     
    
     
        Task<UpdateAddress> UpdateAddress(UpdateAddress updateAddress,int id);
       
    }
}
