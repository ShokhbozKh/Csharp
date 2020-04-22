using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise_08.Migrations
{
    public partial class AddedFkToAnimalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "IdOwner",
                table: "Animals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_IdOwner",
                table: "Animals",
                column: "IdOwner");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Owners_IdOwner",
                table: "Animals",
                column: "IdOwner",
                principalTable: "Owners",
                principalColumn: "IdOwner",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Owners_IdOwner",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_IdOwner",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "IdOwner",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Animals",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
