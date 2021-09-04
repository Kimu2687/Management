using Microsoft.EntityFrameworkCore.Migrations;

namespace TASK.Migrations
{
    public partial class Version_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Buying_price",
                table: "Cartons",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Bottles_bought",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carton_category = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Initial_stock = table.Column<int>(nullable: false),
                    Final_stock = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bottles_bought", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Industry_employees = table.Column<string>(nullable: false),
                    Supply_employees = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bottles_bought");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Buying_price",
                table: "Cartons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
