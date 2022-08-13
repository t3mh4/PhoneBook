using ContactMicroservice.Entities;
using ContactMicroservice.Managers;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Dtos;

namespace ContactMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoManager _manager;
        public ContactInfoController(IContactInfoManager manager)
        {
            _manager = manager;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] ContactInfoDto contactInfoDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _manager.SaveAsync(contactInfoDto);
            return Ok(contactInfoDto);
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

        [HttpGet("GetLocationReport")]
        public async Task<IActionResult> GetLocationReport()
        {
            return Ok(await _manager.GetLocationReport());
        }


    }
}
