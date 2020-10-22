using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizApp.WEB.Services
{
    public class DepatmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepatmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Department>> GetAllDepatrment()
        {
            return await httpClient.GetJsonAsync<Department[]>("api/departments");
        }
    }
}
