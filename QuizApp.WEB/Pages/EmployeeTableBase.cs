using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.WEB.Pages
{
    public class EmployeeTableBase : ComponentBase
    {
        public IEnumerable<Employe> Employees { get; set; }

       
        protected override async Task OnInitializedAsync()
        {
            
            await Task.Run(GetEmployees);
            
        }


        private void GetEmployees()
        {
            Employe e1 = new Employe
            {
                EmployeeId = 1,
                FirstName = "Ander",
                LastName = "Anderson",
                Admin = true,
                DepartmentId = 1,
                Email = "anders@hot.com",
                PhotoPath = "Images/test.test.png"
            };
            Employe e2 = new Employe
            {
                EmployeeId = 2,
                FirstName = "Alex",
                LastName = "Axelson",
                Admin = false,
                DepartmentId = 2,
                Email = "alex@hot.com",
                PhotoPath = "Images/test.test.png"
            };
            Employe e3 = new Employe
            {
                EmployeeId = 2,
                FirstName = "Mado",
                LastName = "Modin",
                Admin = true,
                DepartmentId = 2,
                Email = "mado@hot.com",
                PhotoPath = "Images/test.test.png"
            };
            Employees = new List<Employe> { e1, e2,e3 };
        }

    }
}
