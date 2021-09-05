using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TASK.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bottles_bought", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cartons",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carton_category = table.Column<string>(nullable: false),
                    Buying_price = table.Column<decimal>(nullable: false),
                    Selling_price = table.Column<decimal>(nullable: false),
                    No_of_bottle = table.Column<int>(nullable: false),
                    bottle_per_carton = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cartons_sold",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carton_category = table.Column<string>(nullable: false),
                    Cartons_sold_ = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartons_sold", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expense = table.Column<string>(nullable: false),
                    Ammount = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "System_Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_names = table.Column<string>(nullable: false),
                    Staff_no = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Roles = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bottles_bought");

            migrationBuilder.DropTable(
                name: "Cartons");

            migrationBuilder.DropTable(
                name: "Cartons_sold");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "System_Users");
        }
    }
}
