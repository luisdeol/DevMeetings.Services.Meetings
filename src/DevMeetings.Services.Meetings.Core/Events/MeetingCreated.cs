using System;
using DevMeetings.Services.Meetings.Core.ValueObjects;

namespace DevMeetings.Services.Meetings.Core.Events
{
    public class MeetingCreated : IDomainEvent
    {
        public MeetingCreated(Guid id, string title, Location location)
        {
            Id = id;
            Title = title;
            Location = location;
        }

        public Guid Id { get; }
        public string Title { get; }
        public Location Location { get; }
    }
}