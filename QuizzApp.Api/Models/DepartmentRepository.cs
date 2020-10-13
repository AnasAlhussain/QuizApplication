using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Department> AddDepartment(Department department)
        {
            var newDepartment = await appDbContext.Departments.AddAsync(department);
            await appDbContext.SaveChangesAsync();
            return newDepartment.Entity;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            var result = await appDbContext.Departments.FirstOrDefaultAsync(d => d.DeptId == id);
            if (result != null)
            {
                appDbContext.Departments.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }

       
    }
}
