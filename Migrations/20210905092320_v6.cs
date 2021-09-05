using Microsoft.EntityFrameworkCore.Migrations;

namespace TASK.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Monthly_sales",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Profit",
                table: "Monthly_sales",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "water_bill",
                table: "Monthly_sales",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profit",
                table: "Monthly_sales");

            migrationBuilder.DropColumn(
                name: "water_bill",
                table: "Monthly_sales");

            migrationBuilder.AlterColumn<decimal>(
                name: "Date",
                table: "Monthly_sales",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
