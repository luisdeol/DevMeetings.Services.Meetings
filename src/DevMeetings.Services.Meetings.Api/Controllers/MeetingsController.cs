using System;
using System.Threading.Tasks;
using DevMeetings.Services.Meetings.Application.Dtos.InputModels;
using DevMeetings.Services.Meetings.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevMeetings.Services.Meetings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        public MeetingsController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var result = await _meetingService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) {
            var result = await _meetingService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMeetingInputModel inputModel) {
            var id = await _meetingService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPost("{id}/participants")]
        public async Task<IActionResult> PostParticipant([FromBody] RegisterParticipantInputModel inputModel) {
            await _meetingService.RegisterParticipant(inputModel);

            return NoContent();
        }
    }
}