using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Models
{
    public class Employe
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName 
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [Display(Name = "Department Name")]
        
       
         //public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public bool Admin { get; set; }
    }
}
