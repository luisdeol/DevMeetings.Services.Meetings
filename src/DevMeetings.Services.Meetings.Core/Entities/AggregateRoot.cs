using System;
using System.Collections.Generic;
using DevMeetings.Services.Meetings.Core.Events;

namespace DevMeetings.Services.Meetings.Core.Entities
{
    public class AggregateRoot
    {
        private List<IDomainEvent> _events = new List<IDomainEvent>();

        public Guid Id { get; protected set; }
        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event) {
            if (_events == null) {
                _events = new List<IDomainEvent>();
            }

            _events.Add(@event);
        }
    }
}