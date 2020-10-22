using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.WEB.Services
{
    public interface IRecordService
    {
        Task<Record> AddNewRecord(Record newRecord);
        Task<IEnumerable<Record>> GetRecords();

    }
}
