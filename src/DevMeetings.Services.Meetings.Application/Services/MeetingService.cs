using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevMeetings.Services.Meetings.Application.Dtos.InputModels;
using DevMeetings.Services.Meetings.Application.Dtos.ViewModels;
using DevMeetings.Services.Meetings.Core.Entities;
using DevMeetings.Services.Meetings.Core.Repositories;
using DevMeetings.Services.Meetings.Infrastructure.MessageBus;

namespace DevMeetings.Services.Meetings.Application.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMessageBusClient _messageBus;
        public MeetingService(IMeetingRepository meetingRepository, IMessageBusClient messageBus)
        {
            _meetingRepository = meetingRepository;
            _messageBus = messageBus;
        }

        public async Task<Guid> Create(CreateMeetingInputModel inputModel)
        {
            var meeting = Meeting.Create(
                inputModel.Title,
                inputModel.Description,
                inputModel.Category,
                inputModel.Location.ToValueObject()
            );

            await _meetingRepository.AddAsync(meeting);

            return meeting.Id;
        }

        public async Task<List<MeetingViewModel>> GetAll()
        {
            var meetings = await _meetingRepository.GetAllAsync();

            var meetingsViewModel = meetings
                .Select(m => new MeetingViewModel(m.Id, m.Title, m.Category))
                .ToList();

            return meetingsViewModel;
        }

        public async Task<MeetingDetailsViewModel> GetById(Guid id)
        {
            var meeting = await _meetingRepository.GetByIdAsync(id);

            if (meeting == null)
                return null;

            var meetingDetailsViewModel = MeetingDetailsViewModel.FromEntity(meeting);

            return meetingDetailsViewModel;
        }

        public async Task RegisterParticipant(RegisterParticipantInputModel inputModel)
        {
            var meeting = await _meetingRepository.GetByIdAsync(inputModel.IdMeeting);

            meeting.Register(inputModel.IdParticipant, inputModel.FullName, inputModel.Email);

            await _meetingRepository.UpdateAsync(meeting);

            // UserCreated = user-created
            foreach (var @event in meeting.Events) {
                var routingKey = @event.GetType().Name.ToDashCase();

                _messageBus.Publish(@event, routingKey, "meeting-service");

                // Event Mapper para abstrair as mensagens que realmente precisem
                // ser publicadas
            }
        }

        public async Task Update(UpdateMeetingInputModel inputModel)
        {
            var meeting = await _meetingRepository.GetByIdAsync(inputModel.Id);

            meeting.UpdateInfo(inputModel.Description, inputModel.Location.ToValueObject());

            await _meetingRepository.UpdateAsync(meeting);
        }
    }
}