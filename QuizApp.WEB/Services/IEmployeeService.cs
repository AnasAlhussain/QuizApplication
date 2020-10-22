using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.WEB.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employe>> GetAllEmployees();
        Task<Employe> CreateEmployee(Employe newEmployee);
        Task<Employe> GetEmployeeById(int id);
    }
}
