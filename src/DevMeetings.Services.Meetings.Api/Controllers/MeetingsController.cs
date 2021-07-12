using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevMeetings.Services.Meetings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string category) {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post() {
            return CreatedAtAction(nameof(GetById), new { id = Guid.NewGuid()}, null);
        }

        [HttpPost("{id}/participants")]
        public async Task<IActionResult> PostParticipant() {
            return NoContent();
        }
    }
}