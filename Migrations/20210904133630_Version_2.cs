using Microsoft.EntityFrameworkCore.Migrations;

namespace TASK.Migrations
{
    public partial class Version_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartons",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carton_category = table.Column<string>(nullable: false),
                    Buying_price = table.Column<string>(nullable: false),
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
                    Date = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartons_sold", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expense = table.Column<string>(nullable: false),
                    Ammount = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartons");

            migrationBuilder.DropTable(
                name: "Cartons_sold");

            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
