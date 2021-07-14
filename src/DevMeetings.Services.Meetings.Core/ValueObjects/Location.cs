using System;

namespace DevMeetings.Services.Meetings.Core.ValueObjects
{
    public class Location
    {
        public Location(string url, string description, DateTime startsAt)
        {
            Url = url;
            Description = description;
            StartsAt = startsAt;
        }

        public string Url { get; private set; }
        public string Description { get; private set; }
        public DateTime StartsAt { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   Url == location.Url &&
                   Description == location.Description &&
                   StartsAt == location.StartsAt;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Url, Description, StartsAt);
        }
    }
}