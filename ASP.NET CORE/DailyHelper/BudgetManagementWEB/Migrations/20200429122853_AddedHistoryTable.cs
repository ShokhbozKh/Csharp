using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManagement.Migrations
{
    public partial class AddedHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "History",
                schema: "Budget",
                columns: table => new
                {
                    IdHistory = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    TotalSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ItemType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.IdHistory);
                    table.ForeignKey(
                        name: "FK_History_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Budget",
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_CategoryId",
                schema: "Budget",
                table: "History",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History",
                schema: "Budget");
        }
    }
}
