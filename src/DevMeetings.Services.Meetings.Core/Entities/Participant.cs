using System;

namespace DevMeetings.Services.Meetings.Core.Entities
{
    public class Participant
    {
        public Participant(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}