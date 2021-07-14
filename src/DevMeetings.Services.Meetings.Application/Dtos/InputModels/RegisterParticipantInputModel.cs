using System;

namespace DevMeetings.Services.Meetings.Application.Dtos.InputModels
{
    public class RegisterParticipantInputModel
    {
        public Guid IdParticipant { get; set; }
        public Guid IdMeeting { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}