using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise_08.Migrations
{
    public partial class AddedAnimalTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal_Type",
                columns: table => new
                {
                    IdAnimalType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal_Type", x => x.IdAnimalType);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal_Type");
        }
    }
}
