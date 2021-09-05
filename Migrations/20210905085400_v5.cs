using Microsoft.EntityFrameworkCore.Migrations;

namespace TASK.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monthly_sales",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Electricity_bill = table.Column<decimal>(nullable: false),
                    Revenue = table.Column<decimal>(nullable: false),
                    Transport = table.Column<decimal>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    Buying_expenses = table.Column<decimal>(nullable: false),
                    Gross_income = table.Column<decimal>(nullable: false),
                    Date = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monthly_sales", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monthly_sales");
        }
    }
}
