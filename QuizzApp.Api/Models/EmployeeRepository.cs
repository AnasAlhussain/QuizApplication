using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Employe> AddEmployee(Employe employee)
        {
            var newEmploye = await appDbContext.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return newEmploye.Entity;
        }

        public async Task<Employe>  DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<Employe> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<Employe>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
            
        }

        public async Task<Employe> UpdateEmployee(Employe employee)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.PhotoPath = employee.PhotoPath;
                result.Admin = employee.Admin;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
