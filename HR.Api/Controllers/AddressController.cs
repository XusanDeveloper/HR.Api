using HR.Api.Models;
using HR.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IGenericCRUDService<AddressModel> _addressSvc;
        public AddressController(IGenericCRUDService<AddressModel> addressSvc)
        {
            _addressSvc = addressSvc;
        }

        // GET: api/<addressController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _addressSvc.GetAll());
        }

        // GET api/<addressController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound($"Address with the given id: {id} is not found!");
            else if (id < 0)
                return BadRequest("Wrong data!");

            return Ok(await _addressSvc.Get(id));
        }

        // POST api/<addressController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AddressModel address)
        {
            return Ok(await _addressSvc.Create(address));
        }

        // PUT api/<addressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] AddressModel address)
        {
            var updatedaddress = await _addressSvc.Update(id, address);
            return Ok(updatedaddress);
        }

        // DELETE api/<addressController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteaddress = await _addressSvc.Delete(id);
            if (deleteaddress)
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
