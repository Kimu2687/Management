using Microsoft.EntityFrameworkCore.Migrations;

namespace TASK.Migrations
{
    public partial class Version_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "System_Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Full_names = table.Column<string>(nullable: false),
                    Staff_no = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: false),
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
                name: "System_Users");
        }
    }
}
