using HR.Api.Models;
using HR.Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenericCRUDService<EmployeeModel> _employeeSvc;
        public EmployeeController(IGenericCRUDService<EmployeeModel> employeeSvc)
        {
            _employeeSvc = employeeSvc;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employeeSvc.GetAll());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Employee with the given id: {id} is not found!");
            else if (id < 0)
                return BadRequest("Wrong data!");

            return Ok( await _employeeSvc.Get(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] EmployeeModel employee)
        {
            return Ok(await _employeeSvc.Create(employee));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] EmployeeModel employee)
        {
            var updatedEmployee = await _employeeSvc.Update(id, employee);
            return Ok(updatedEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteEmployee  = await _employeeSvc.Delete(id);
            if (deleteEmployee)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
