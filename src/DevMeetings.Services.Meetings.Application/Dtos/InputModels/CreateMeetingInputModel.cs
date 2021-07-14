using System;
using DevMeetings.Services.Meetings.Core.ValueObjects;

namespace DevMeetings.Services.Meetings.Application.Dtos.InputModels
{
    public class CreateMeetingInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public LocationInputModel Location { get; set; }
        public string Category { get; set; }
    }

    public class LocationInputModel {
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime StartsAt { get; set; }

        public Location ToValueObject() {
            return new Location(Url, Description, StartsAt);
        }
    }
}