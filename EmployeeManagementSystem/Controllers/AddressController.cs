using EmployeeManagementSystem.DTO.Address;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddress _Address;
        public AddressController(IAddress Address)
        {
             _Address = Address;
        }
     

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateAddress updateAddress, int id)
        {
            var result = await _Address.UpdateAddress(updateAddress, id);
            return Ok(result);
        }
    }
}
