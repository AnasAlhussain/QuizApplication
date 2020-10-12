using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using QuizApp.WEB.Services;

namespace QuizApp.WEB.Pages
{
    public class EmployeeListBase : ComponentBase
    {

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employe> Employees { get; set; }


        protected override async Task OnInitializedAsync()
        {
            //Employees =(await EmployeeService.GetAllEmployees()).ToList(); 
           await Task.Run(GetEmployees);
           // return base.OnInitializedAsync();
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
                Email="anders@hot.com",
                PhotoPath = "Images/test.test.png"
            };
            Employe e2 = new Employe
            {
                EmployeeId = 2,
                FirstName = "Alex",
                LastName = "Axelson",
                Admin = true,
                DepartmentId = 2,
                Email = "anders@hot.com",
                PhotoPath = "Images/test.test.png"
            };
            Employees = new List<Employe> { e1, e2 };
        }
        
    }
}
