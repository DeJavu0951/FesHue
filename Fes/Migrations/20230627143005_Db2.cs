using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fes.Migrations
{
    public partial class Db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Schedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Event",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Ticket_TicketId",
                table: "Schedule",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
