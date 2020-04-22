using Microsoft.EntityFrameworkCore.Migrations;

namespace Exercise_08.Migrations
{
    public partial class AddedTableAnimalClinic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalClinics",
                columns: table => new
                {
                    IdAnimalClinic = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    IdOwner = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalClinics", x => x.IdAnimalClinic);
                    table.ForeignKey(
                        name: "FK_AnimalClinics_Owners_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Owners",
                        principalColumn: "IdOwner",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalClinics_IdOwner",
                table: "AnimalClinics",
                column: "IdOwner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalClinics");
        }
    }
}
