using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizApp.WEB.Services
{
    public class RecordService : IRecordService
    {
        private readonly HttpClient httpClient;

        public RecordService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Record> AddNewRecord(Record newRecord)
        {
            return await httpClient.PostJsonAsync<Record>("api/records", newRecord);
        }

        public async Task<IEnumerable<Record>> GetRecords()
        {
            return await httpClient.GetJsonAsync<Record[]>("api/records");
        }
    }
}
