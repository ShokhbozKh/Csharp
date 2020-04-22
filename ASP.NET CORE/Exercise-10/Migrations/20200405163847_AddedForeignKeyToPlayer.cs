using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise_10.Migrations
{
    public partial class AddedForeignKeyToPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamIdTeam",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamIdTeam",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TeamIdTeam",
                table: "Players");

            migrationBuilder.CreateIndex(
                name: "IX_Players_IdTeam",
                table: "Players",
                column: "IdTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_IdTeam",
                table: "Players",
                column: "IdTeam",
                principalTable: "Teams",
                principalColumn: "IdTeam",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_IdTeam",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_IdTeam",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "TeamIdTeam",
                table: "Players",
                type: "int",
                nullable: true);

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
    }
}
