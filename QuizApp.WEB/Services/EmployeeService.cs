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

        public async Task<Employe> CreateEmployee(Employe newEmployee)
        {
            return await httpClient.PostJsonAsync<Employe>("api/employees", newEmployee);
            
        }

        public async Task<IEnumerable<Employe>> GetAllEmployees()
        {
            return await httpClient.GetJsonAsync<Employe[]>("api/employees");
        }

        public async Task<Employe> GetEmployeeById(int id)
        {
            return await httpClient.GetJsonAsync<Employe>($"api/employees/{id}");
        }
    }
}
