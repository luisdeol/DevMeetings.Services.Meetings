using System;

namespace DevMeetings.Services.Meetings.Core.Events
{
    public class ParticipantRegistered : IDomainEvent
    {
        public ParticipantRegistered(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        public Guid Id { get; }
        public string FullName { get; }
        public string Email { get; }
    }
}