using System;

namespace DevMeetings.Services.Meetings.Core.Events
{
    public class MeetingLocationUpdated : IDomainEvent
    {
        public MeetingLocationUpdated(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}