using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
    interface IRecordRepository
    {
        Task<IEnumerable<Record>> GetAllRecords();
        Task<Record> AddRecord(Record record);
        Task<Record> DeleteRecord(int recordId);
    }
}
