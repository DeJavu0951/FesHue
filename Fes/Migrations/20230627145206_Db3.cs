using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fes.Migrations
{
    public partial class Db3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Schedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Event",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TicketId",
                table: "Schedule",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_ScheduleId",
                table: "Event",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Schedule_ScheduleId",
                table: "Event",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Ticket_TicketId",
                table: "Schedule",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Schedule_ScheduleId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Ticket_TicketId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_TicketId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Event_ScheduleId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Event");
        }
    }
}
