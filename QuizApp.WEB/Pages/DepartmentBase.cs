using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.WEB.Pages
{
    public class DepartmentBase : ComponentBase
    {
        public IEnumerable<Department> Departments { get; set; }

        protected override Task OnInitializedAsync()
        {
            GetDepartments();
            return base.OnInitializedAsync();
        }

        private void GetDepartments()
        {
            Department D1 = new Department
            {
             DeptId = 1,
             DepName = "Salling",
             EmployeeId =2,
            };

            Department D2 = new Department
            {
                DeptId = 2,
                DepName = "Salling",
                EmployeeId = 3,
            };
            Department D3 = new Department
            {
                DeptId = 3,
                DepName = "Developing",
                EmployeeId = 4,
            };
            Departments = new List<Department> { D1, D2,D3 };
        }

    }
}
