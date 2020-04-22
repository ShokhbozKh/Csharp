using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeansOfficeWeb.Migrations
{
    public partial class AddedInstructorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Instructor");

            migrationBuilder.CreateTable(
                name: "Instructor",
                schema: "Instructor",
                columns: table => new
                {
                    IdInstructor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.IdInstructor);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instructor",
                schema: "Instructor");
        }
    }
}
