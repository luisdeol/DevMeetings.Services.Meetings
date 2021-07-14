using System;
using System.Collections.Generic;
using DevMeetings.Services.Meetings.Core.Events;
using DevMeetings.Services.Meetings.Core.ValueObjects;

namespace DevMeetings.Services.Meetings.Core.Entities
{
    public class Meeting : AggregateRoot
    {
        public Meeting(string title, string description, Location location, string category)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
            Location = location;
            Category = category;
            Participants = new List<Participant>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Location Location { get; private set; }
        public List<Participant> Participants { get; private set; }
        public string Category { get; private set; }

        public static Meeting Create(string title, string description, string category, Location location) {
            // Fazer validação

            var meeting = new Meeting(title, description, location, category);
            
            meeting.AddEvent(new MeetingCreated(meeting.Id, meeting.Title, meeting.Location));

            return meeting;
        }

        public void UpdateInfo(string description, Location location) {
            // Fazer validação

            Description = description;
            Location = location;

            AddEvent(new MeetingLocationUpdated(Id));
        }

        public void Register(Guid id, string fullName, string email) {
            // Fazer validação
            // Se ficar muito complexo, considere mover para um serviço de domínio

            var participant = new Participant(id, fullName, email);

            Participants.Add(participant);

            AddEvent(new ParticipantRegistered(participant.Id, participant.FullName, participant.Email));
        }
    }
}