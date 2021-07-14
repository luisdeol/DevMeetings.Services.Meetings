using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevMeetings.Services.Meetings.Core.Entities;

namespace DevMeetings.Services.Meetings.Core.Repositories
{
    public interface IMeetingRepository
    {
        Task<Meeting> GetByIdAsync(Guid id);
        Task<List<Meeting>> GetAllAsync();
        Task AddAsync(Meeting meeting);
        Task UpdateAsync(Meeting meeting);
    }
}