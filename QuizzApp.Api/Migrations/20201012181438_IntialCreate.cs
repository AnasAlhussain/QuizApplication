using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizzApp.Api.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerDate = table.Column<DateTime>(nullable: false),
                    QuizId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepName = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true),
                    Admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "QuizEmployeeLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(nullable: false),
                    EmployeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizEmployeeLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    QizId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    QuizType = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.QizId);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(nullable: false),
                    EmployeId = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AnswerDate", "EmployeeId", "QuizId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, 4 },
                    { 3, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, 2 },
                    { 4, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), 3, 3 },
                    { 2, new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Local), 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptId", "DepName", "EmployeeId" },
                values: new object[,]
                {
                    { 1, "Developing", 1 },
                    { 2, "Support", 2 },
                    { 3, "HR", 3 },
                    { 4, "Economy", 4 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Admin", "DepartmentId", "Email", "FirstName", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 4, true, 3, "andrs@hot.com", "Anders", "Anderson", "Images / test.test.png" },
                    { 3, false, 1, "viktor@hot.com", "Viktor", "Viktor", "Images / test.test.png" },
                    { 1, false, 1, "ana@hot.com", "Anas", "Alhu", "Images / test.test.png" },
                    { 2, true, 2, "Mike@hot.com", "Mike", "Mike", "Images / test.test.png" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "QizId", "AnswerId", "Description", "QuizType", "Title" },
                values: new object[,]
                {
                    { 4, 1, "To Ask", 1, "How are you ?" },
                    { 1, 2, "To Ask", 3, " How are you ?" },
                    { 2, 3, "Somthing", 7, " What you will do today ?" },
                    { 3, 4, "To Ask", 5, " Which day is your birthday ?" }
                });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "RecordId", "AnswerId", "EmployeId", "QuizId" },
                values: new object[] { 1, 2, 3, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "QuizEmployeeLists");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
