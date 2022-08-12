﻿using ContactMicroservice.Entities;
using ContactMicroservice.Managers;
using Microsoft.AspNetCore.Mvc;


namespace ContactMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactManager _manager;
        public ContactController(IContactManager manager)
        {
            _manager = manager;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _manager.GetAll();
            return Ok(contacts);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] Contact contact)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _manager.SaveAsync(contact);
            return Ok(contact);
        }

        [HttpDelete("Remove")]
        public async void Remove(Guid uuid)
        {
            await _manager.RemoveAsync(uuid);
        }
    }
}