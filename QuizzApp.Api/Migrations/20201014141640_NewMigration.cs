using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizzApp.Api.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mood",
                table: "Answers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "QuizAnswersList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(nullable: true),
                    QuizzQizId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAnswersList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizAnswersList_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "AnswerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizAnswersList_Quizzes_QuizzQizId",
                        column: x => x.QuizzQizId,
                        principalTable: "Quizzes",
                        principalColumn: "QizId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1,
                column: "AnswerDate",
                value: new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2,
                column: "AnswerDate",
                value: new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3,
                columns: new[] { "AnswerDate", "Mood" },
                values: new object[] { new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4,
                columns: new[] { "AnswerDate", "Mood" },
                values: new object[] { new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QizId",
                keyValue: 1,
                column: "QuizType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QizId",
                keyValue: 2,
                column: "QuizType",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QizId",
                keyValue: 3,
                column: "QuizType",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QizId",
                keyValue: 4,
                column: "QuizType",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswersList_AnswerId",
                table: "QuizAnswersList",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswersList_QuizzQizId",
                table: "QuizAnswersList",
                column: "QuizzQizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizAnswersList");

            migrationBuilder.DropColumn(
                name: "Mood",
                table: "Answers");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1,
                column: "AnswerDate",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2,
                column: "AnswerDate",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3,
                column: "AnswerDate",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4,
                column: "AnswerDate",
                value: new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QizId",
                keyValue: 1,
                column: "QuizType",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QizId",
                keyValue: 2,
                column: "QuizType",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QizId",
                keyValue: 3,
                column: "QuizType",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "QizId",
                keyValue: 4,
                column: "QuizType",
                value: 1);
        }
    }
}
