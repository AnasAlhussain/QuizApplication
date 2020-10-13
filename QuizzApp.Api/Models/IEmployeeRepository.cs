using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
   public  interface IEmployeeRepository
    {
        Task<IEnumerable<Employe>> GetEmployees();
        Task<Employe> GetEmployee(int employeeId);
        Task<Employe> AddEmployee(Employe employee);
        Task<Employe> UpdateEmployee(Employe employee);
        Task<Employe> DeleteEmployee(int employeeId);
    }
}
