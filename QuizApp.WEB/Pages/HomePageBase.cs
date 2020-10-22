using Microsoft.AspNetCore.Components;
using QuizApp.Models;
using QuizApp.WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.WEB.Pages
{
    public class HomePageBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public IEnumerable<Department>  departs { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();
        public string DepartmentID { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Employe employee { get; set; } = new Employe();

        protected override async Task OnInitializedAsync()
        {
            

            Departments = (await DepartmentService.GetAllDepatrment()).ToList();
            DepartmentID = employee.DepartmentId.ToString();

           
            
            employee = new Employe
            {
                FirstName = "",
                LastName ="",
                DepartmentId = 1,


            };
        }

        protected async Task HandleValidSubmit()
        {
            Employe result = null;
            
            {

            }
            
            result = await EmployeeService.CreateEmployee(employee);

            
            
            if (result != null)
            {
                NavigationManager.NavigateTo("/Quiz");
            }
            
        }

    }
}
