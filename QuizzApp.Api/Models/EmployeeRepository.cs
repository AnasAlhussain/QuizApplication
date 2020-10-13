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

        public void DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Employe> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<Employe>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
            
        }

        public Task<Employe> UpdateEmployee(Employe employee)
        {
            throw new NotImplementedException();
        }
    }
}
