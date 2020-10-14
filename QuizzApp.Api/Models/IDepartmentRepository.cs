using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> AddDepartment(Department department);
        Task<Department> DeleteDepartment(int id);
        Task<Department> GetDepartment(int id);


    }
}
