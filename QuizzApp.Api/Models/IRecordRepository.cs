using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
   public  interface IRecordRepository
    {
        Task<IEnumerable<Record>> GetAllRecords();
        Task<Record> GetRecord(int id);
        Task<Record> AddRecord(Record record);
        Task<Record> DeleteRecord(int recordId);
    }
}
