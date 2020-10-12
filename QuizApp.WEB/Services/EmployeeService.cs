using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizApp.WEB.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
        public async Task<IEnumerable<Employe>> GetAllEmployees()
        {
            return await httpClient.GetJsonAsync<Employe[]>("api/employees");
        }
        
    }
}
