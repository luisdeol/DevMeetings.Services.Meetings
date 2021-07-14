using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevMeetings.Services.Meetings.Application.Dtos.InputModels;
using DevMeetings.Services.Meetings.Application.Dtos.ViewModels;

namespace DevMeetings.Services.Meetings.Application.Services
{
    public interface IMeetingService
    {
        Task<Guid> Create(CreateMeetingInputModel inputModel);
        Task Update(UpdateMeetingInputModel inputModel);
        Task<MeetingDetailsViewModel> GetById(Guid id);
        Task<List<MeetingViewModel>> GetAll();
        Task RegisterParticipant(RegisterParticipantInputModel inputModel);
    }
}