using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetManagement.Migrations
{
    public partial class ModifyItemsDateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedTime",
                schema: "Budget",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "AddedTime",
                schema: "Budget",
                table: "Expense");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                schema: "Budget",
                table: "Income",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                schema: "Budget",
                table: "Expense",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                schema: "Budget",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                schema: "Budget",
                table: "Expense");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedTime",
                schema: "Budget",
                table: "Income",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedTime",
                schema: "Budget",
                table: "Expense",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
