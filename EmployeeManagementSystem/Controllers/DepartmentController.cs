using EmployeeManagementSystem.DTO.Department;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _Department;
        public DepartmentController(IDepartment Department)
        {
            _Department = Department;
        }

        //--------------------------------------Create--------------------------------------
        [HttpPost]
        public async Task<IActionResult> AddData(CreateDepDto createDepDto)
        {
            var result = await _Department.CreateDepart(createDepDto);
            return Ok(result);
        }

        //--------------------------------------Get--------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var result = await _Department.GetAllDepart();
            return Ok(result);
        }

        //--------------------------------------Count Employees--------------------------------------
        [HttpGet("Count Employee")]
        public async Task<IActionResult> CountEmp()
        {
           var data = await _Department.GetAllDepartments();
            return Ok(data);
        }


        //--------------------------------------delete--------------------------------------
        [HttpDelete("{id}")]
        public async Task<IActionResult> deletedata(int id)
        {
            var data = await _Department.DeleteDepart(id);
           


            return Ok(data);


        }



        //--------------------------------------Update--------------------------------------
        [HttpPut]
        public async Task<IActionResult> Updatadata(int id, UpdateDepDto Updepartment)
        {
            var result = await _Department.UpdateDepart(id, Updepartment);
            return Ok(result);


        }
    }
}
