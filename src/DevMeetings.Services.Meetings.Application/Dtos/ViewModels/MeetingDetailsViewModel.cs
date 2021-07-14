using System;
using System.Collections.Generic;
using System.Linq;
using DevMeetings.Services.Meetings.Core.Entities;

namespace DevMeetings.Services.Meetings.Application.Dtos.ViewModels
{
    public class MeetingDetailsViewModel
    {
        public MeetingDetailsViewModel(Guid id, string title, string description, LocationViewModel location, List<ParticipantViewModel> participants, string category)
        {
            Id = id;
            Title = title;
            Description = description;
            Location = location;
            Participants = participants;
            Category = category;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public LocationViewModel Location { get; set; }
        public List<ParticipantViewModel> Participants { get; private set; }
        public string Category { get; private set; }

        public static MeetingDetailsViewModel FromEntity(Meeting meeting) {
            return new MeetingDetailsViewModel(
                meeting.Id,
                meeting.Title,
                meeting.Description,
                LocationViewModel.FromUrlAndDescription(meeting.Location.Url, meeting.Location.Description),
                meeting.Participants?.Select(p => ParticipantViewModel.FromFullName(p.FullName)).ToList(),
                meeting.Category
            );
        }
    }

    public class LocationViewModel {
        public LocationViewModel(string url, string description)
        {
            Url = url;
            Description = description;
        }

        public string Url { get; private set; }
        public string Description { get; private set; }

        public static LocationViewModel FromUrlAndDescription(string url, string description) {
            return new LocationViewModel(url, description);
        }
    }

    public class ParticipantViewModel{
        private ParticipantViewModel(string fullName) {
            FullName = fullName;
        }

        public string FullName { get; private set; }

        public static ParticipantViewModel FromFullName(string fullName) {
            return new ParticipantViewModel(fullName);
        }
    }
}