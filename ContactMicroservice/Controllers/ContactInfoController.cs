using ContactMicroservice.Entities;
using ContactMicroservice.Managers;
using Microsoft.AspNetCore.Mvc;

namespace ContactMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoManager _manager;
        public ContactInfoController(IContactInfoManager manager)
        {
            _manager=manager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactInfo contactInfo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _manager.SaveAsync(contactInfo);
            return Ok(contactInfo);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(Guid uuid)
        {
            return Ok(await _manager.RemoveAsync(uuid));
        }

        [HttpGet("GetAllByContactUUID")]
        public async Task<IActionResult> GetAllByContactUUID(Guid contactUUID)
        {
            return Ok(await _manager.GetAllByContactUUID(contactUUID));
        }

        // GET api/<ContactInfoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactInfoController>
        

        // DELETE api/<ContactInfoController>/5
       
    }
}
