using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fes.Migrations
{
    public partial class Addtb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TicketId",
                table: "Schedule",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Ticket_TicketId",
                table: "Schedule",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Ticket_TicketId",
                table: "Schedule");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_TicketId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Schedule");
        }
    }
}
