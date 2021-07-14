using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevMeetings.Services.Meetings.Core.Entities;
using DevMeetings.Services.Meetings.Core.Repositories;
using MongoDB.Driver;

namespace DevMeetings.Services.Meetings.Infrastructure.Persistence.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly IMongoCollection<Meeting> _collection;
        public MeetingRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Meeting>("meetings");
        }

        public async Task AddAsync(Meeting meeting)
        {
            await _collection.InsertOneAsync(meeting);
        }

        public async Task<List<Meeting>> GetAllAsync()
        {
            return await _collection.Find(c => true).ToListAsync();
        }

        public async Task<Meeting> GetByIdAsync(Guid id)
        {
            return await _collection.Find(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Meeting meeting)
        {
            await _collection.ReplaceOneAsync(c => c.Id == meeting.Id, meeting);
        }
    }
}