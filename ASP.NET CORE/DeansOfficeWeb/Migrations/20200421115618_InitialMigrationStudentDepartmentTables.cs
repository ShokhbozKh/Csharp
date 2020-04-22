using Microsoft.EntityFrameworkCore.Migrations;

namespace DeansOfficeWeb.Migrations
{
    public partial class InitialMigrationStudentDepartmentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "School");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "School",
                columns: table => new
                {
                    IdStudy = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.IdStudy);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "School",
                columns: table => new
                {
                    IdStudent = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    IndexNumber = table.Column<string>(maxLength: 6, nullable: true),
                    IdStudy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Student_Department_IdStudy",
                        column: x => x.IdStudy,
                        principalSchema: "School",
                        principalTable: "Department",
                        principalColumn: "IdStudy",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_IdStudy",
                schema: "School",
                table: "Student",
                column: "IdStudy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student",
                schema: "School");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "School");
        }
    }
}
