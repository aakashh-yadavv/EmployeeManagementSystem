using EmployeeManagementSystem.DTO.Employeedto;
using EmployeeManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployees _employeess;
        public EmployeeController(IEmployees employeess)
        {
            _employeess = employeess;
        }

        //--------------------------------------Create --------------------------------------
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateEmp(CreateEmpDto createEmpDto, int id)
        {
            var result = await _employeess.CreateAsync(createEmpDto, id);
            if (result==null)
            {
                return NotFound("Id is not found ");
            }
            return Ok (result);
        }

        //--------------------------------------Get Emp --------------------------------------
        [HttpGet("Emp Get")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeess.GetAll();
            return Ok(result);
        }

        //--------------------------------------Get By Id --------------------------------------
        [HttpGet("GetById/{id}")]

        public async Task<IActionResult> GetEmpById(int id)
        {
            var emp = await _employeess.GetById(id);
            if (emp == null)
            {
                return NotFound("Id Not Found");
            }
            return Ok(emp);
        }


        //--------------------------------------Sort by Name --------------------------------------
        [HttpGet("Name Sorted")]
        public async Task<IActionResult> Sortedname()
        {
            var sortname = await _employeess.SortedName();
            return Ok (sortname);
        }


        //--------------------------------------Get by Name--------------------------------------
        [HttpGet("GetByName/{name}")]

       public async Task<IActionResult> GetByName(string name)
        {
            var am = await _employeess.GetByName(name);
            if(am == null)
            {
                return NotFound("Name Not Found ");
            }
            return Ok(am);
        }


        //--------------------------------------Get By DepId--------------------------------------
        [HttpGet("GetByDepId/{id}")]
        public async Task<IActionResult> GetBYDepId(int id)
        {
            var result = await _employeess.GetByDepartmen(id);
            if(result == null)
            {
                return NotFound("Department ID not found");
            }
            return Ok(result);
        }


        //--------------------------------------Delete--------------------------------------
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            var result = await _employeess.DeleteEm(id);
            if (!result)
            {
                return NotFound("Id Not Found");
            }
            return Ok(result);
        }


        //--------------------------------------Update--------------------------------------
        [HttpPut("{id}")]
         public async Task<IActionResult> Updateemp(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var result = await _employeess.UpdateEmp(id, updateEmployeeDto);
            return Ok(result);
        }


        //--------------------------------------pagination--------------------------------------
        [HttpGet("pagination")]
        public async Task<IActionResult> Pagination(int pageNumber =1, int pageSize=5)
        {
            var pag = await _employeess.Pagination(pageNumber, pageSize);
            return Ok(pag);
        }

    }
}
