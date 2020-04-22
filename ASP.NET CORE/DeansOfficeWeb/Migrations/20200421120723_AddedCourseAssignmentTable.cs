using Microsoft.EntityFrameworkCore.Migrations;

namespace DeansOfficeWeb.Migrations
{
    public partial class AddedCourseAssignmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course_Assignment",
                schema: "School",
                columns: table => new
                {
                    CourseAssignments = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Assignment", x => x.CourseAssignments);
                    table.ForeignKey(
                        name: "FK_Course_Assignment_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalSchema: "School",
                        principalTable: "Instructor",
                        principalColumn: "IdInstructor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Assignment_Course_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "School",
                        principalTable: "Course",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Assignment_InstructorId",
                schema: "School",
                table: "Course_Assignment",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Assignment_SubjectId",
                schema: "School",
                table: "Course_Assignment",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course_Assignment",
                schema: "School");
        }
    }
}
