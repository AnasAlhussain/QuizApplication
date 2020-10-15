using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
    public class RcordRepository : IRecordRepository
    {
        private readonly AppDbContext appDbContext;

        public RcordRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Record> AddRecord(Record record)
        {
            var newRecord = await appDbContext.Records.AddAsync(record);
            await appDbContext.SaveChangesAsync();
            return newRecord.Entity;

        }

        public async Task<Record> DeleteRecord(int recordId)
        {
            var result = await appDbContext.Records.FirstOrDefaultAsync(r => r.RecordId == recordId);
            if (result != null)
            {
                appDbContext.Records.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<IEnumerable<Record>> GetAllRecords()
        {
            return await appDbContext.Records.ToListAsync();
        }

        public async Task<Record> GetRecord(int id)
        {
            return await appDbContext.Records.FirstOrDefaultAsync(r => r.RecordId == id);
        }
    }
}
