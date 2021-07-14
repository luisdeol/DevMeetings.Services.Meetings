using System;

namespace DevMeetings.Services.Meetings.Application.Dtos.ViewModels
{
    public class MeetingViewModel
    {
        public MeetingViewModel(Guid id, string title, string category)
        {
            Id = id;
            Title = title;
            Category = category;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Category { get; private set; }
    }
}