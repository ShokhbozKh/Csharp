using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeansOfficeWeb.Migrations
{
    public partial class AddedEnrollmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Instructor",
                schema: "Instructor",
                newName: "Instructor",
                newSchema: "School");

            migrationBuilder.CreateTable(
                name: "Enrollment",
                schema: "School",
                columns: table => new
                {
                    IdEnrollment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(nullable: true),
                    SubjectType = table.Column<string>(maxLength: 100, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(nullable: false),
                    IdSubject = table.Column<int>(nullable: false),
                    IdStudent = table.Column<int>(nullable: false),
                    IdInstructor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.IdEnrollment);
                    table.ForeignKey(
                        name: "FK_Enrollment_Instructor_IdInstructor",
                        column: x => x.IdInstructor,
                        principalSchema: "School",
                        principalTable: "Instructor",
                        principalColumn: "IdInstructor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_IdStudent",
                        column: x => x.IdStudent,
                        principalSchema: "School",
                        principalTable: "Student",
                        principalColumn: "IdStudent",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_IdSubject",
                        column: x => x.IdSubject,
                        principalSchema: "School",
                        principalTable: "Course",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_IdInstructor",
                schema: "School",
                table: "Enrollment",
                column: "IdInstructor");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_IdStudent",
                schema: "School",
                table: "Enrollment",
                column: "IdStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_IdSubject",
                schema: "School",
                table: "Enrollment",
                column: "IdSubject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment",
                schema: "School");

            migrationBuilder.EnsureSchema(
                name: "Instructor");

            migrationBuilder.RenameTable(
                name: "Instructor",
                schema: "School",
                newName: "Instructor",
                newSchema: "Instructor");
        }
    }
}
