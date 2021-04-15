using Microsoft.EntityFrameworkCore.Migrations;

namespace DeansOffice.Migrations
{
    public partial class AddStudentnumberToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentNumber",
                table: "Student",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "Student");
        }
    }
}
