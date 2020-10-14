using Microsoft.EntityFrameworkCore;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzApp.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Employe> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuizzAnswer> QuizAnswersList { get; set; }
        public DbSet<QuizEmployeeList> QuizEmployeeLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Quiz Table
            modelBuilder.Entity<Quiz>().HasData
                (new Quiz { QizId = 1, Title = " How are you ?", Description="To Ask", QuizType= QuizTypes.RedYellowGreen_WhithText, AnswerId=2 });
            modelBuilder.Entity<Quiz>().HasData
                (new Quiz { QizId = 2, Title = " What you will do today ?", Description = "Somthing", QuizType = QuizTypes.Alternativ, AnswerId = 3 });
            modelBuilder.Entity<Quiz>().HasData
                (new Quiz { QizId = 3, Title = " Which day is your birthday ?", Description = "To Ask", QuizType = QuizTypes.Date, AnswerId = 4 });
            modelBuilder.Entity<Quiz>().HasData
                (new Quiz { QizId = 4, Title = "How are you ?", Description = "To Ask", QuizType = QuizTypes.Yes_No, AnswerId = 1 });

            //Seed Employee Table 
            modelBuilder.Entity<Employe>().HasData(new Employe
            {
                 EmployeeId=1,
                 FirstName="Anas",
                 LastName="Alhu",
                 DepartmentId=1,
                 Email="ana@hot.com",
                 PhotoPath= "Images / test.test.png",
                 Admin=false,
            });
            modelBuilder.Entity<Employe>().HasData(new Employe
            {
                EmployeeId = 2,
                FirstName = "Mike",
                LastName = "Mike",
                DepartmentId = 2,
                Email = "Mike@hot.com",
                PhotoPath = "Images / test.test.png",
                Admin = true,
            });
            modelBuilder.Entity<Employe>().HasData(new Employe
            {
                EmployeeId = 3,
                FirstName = "Viktor",
                LastName = "Viktor",
                DepartmentId = 1,
                Email = "viktor@hot.com",
                PhotoPath = "Images / test.test.png",
                Admin = false,
            });
            modelBuilder.Entity<Employe>().HasData(new Employe
            {
                EmployeeId = 4,
                FirstName = "Anders",
                LastName = "Anderson",
                DepartmentId = 3,
                Email = "andrs@hot.com",
                PhotoPath = "Images / test.test.png",
                Admin = true,
            });

            //Seed Department Table 
            modelBuilder.Entity<Department>().HasData(new Department
            {
                 DeptId=1,
                 DepName="Developing",
                 EmployeeId=1,

            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                DeptId = 2,
                DepName = "Support",
                EmployeeId = 2,

            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                DeptId = 3,
                DepName = "HR",
                EmployeeId = 3,

            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                DeptId = 4,
                DepName = "Economy",
                EmployeeId = 4,

            });

            //Seed Answer
            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                 AnswerId=1,
                 EmployeeId=2,
                 QuizId=4,
                 AnswerDate=DateTime.Today,
                 Mood=Moods.Green
            });
            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 3,
                EmployeeId = 1,
                QuizId = 2,
                AnswerDate = DateTime.Today,
                Mood=Moods.Yellow
            });
            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 4,
                EmployeeId = 3,
                QuizId = 3,
                AnswerDate = DateTime.Today,
                Mood=Moods.Red
            });
            modelBuilder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 2,
                EmployeeId = 3,
                QuizId = 1,
                AnswerDate = DateTime.Today,
                Mood=Moods.Green
            });

            //Seed Record 
            modelBuilder.Entity<Record>().HasData(new Record
            {
                 RecordId=1,
                 AnswerId=2,
                 EmployeId=3,
            });


            

        }
    }
}
