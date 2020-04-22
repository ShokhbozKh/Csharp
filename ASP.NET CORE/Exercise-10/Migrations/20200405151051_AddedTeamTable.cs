using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise_10.Migrations
{
    public partial class AddedTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTeam",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamIdTeam",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.IdTeam);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamIdTeam",
                table: "Players",
                column: "TeamIdTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamIdTeam",
                table: "Players",
                column: "TeamIdTeam",
                principalTable: "Teams",
                principalColumn: "IdTeam",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamIdTeam",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamIdTeam",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IdTeam",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamIdTeam",
                table: "Players");
        }
    }
}
