using System;

namespace DevMeetings.Services.Meetings.Application.Dtos.InputModels
{
    public class UpdateMeetingInputModel
    {
        public Guid Id { get; set; }
        public LocationInputModel Location { get; set; }
        public string Description { get; set; }
    }
}