using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManagement.Migrations
{
    public partial class AddedIncomeAndExpenseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Expense");

            migrationBuilder.EnsureSchema(
                name: "Income");

            migrationBuilder.CreateTable(
                name: "Expense",
                schema: "Expense",
                columns: table => new
                {
                    IdExpense = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    TotalSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.IdExpense);
                    table.ForeignKey(
                        name: "FK_Expense_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Budget",
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Income",
                schema: "Income",
                columns: table => new
                {
                    IdIncome = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: false),
                    TotalSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Income", x => x.IdIncome);
                    table.ForeignKey(
                        name: "FK_Income_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Budget",
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CategoryId",
                schema: "Expense",
                table: "Expense",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Income_CategoryId",
                schema: "Income",
                table: "Income",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense",
                schema: "Expense");

            migrationBuilder.DropTable(
                name: "Income",
                schema: "Income");
        }
    }
}
