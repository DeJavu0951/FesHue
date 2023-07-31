using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fes.Migrations
{
    public partial class Db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Event");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
