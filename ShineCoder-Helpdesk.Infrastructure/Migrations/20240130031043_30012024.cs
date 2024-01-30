using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShineCoder_Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _30012024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Tickets_TicketId",
                schema: "Dbo",
                table: "Attachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                schema: "Dbo",
                table: "Attachments");

            migrationBuilder.RenameTable(
                name: "Attachments",
                schema: "Dbo",
                newName: "Ticket_Attachments",
                newSchema: "Dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_TicketId",
                schema: "Dbo",
                table: "Ticket_Attachments",
                newName: "IX_Ticket_Attachments_TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket_Attachments",
                schema: "Dbo",
                table: "Ticket_Attachments",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9471));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(8870));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(8891));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(8896));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(8898));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9438));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 8, 40, 42, 940, DateTimeKind.Local).AddTicks(9441));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8e308dad-4157-43b7-bd2f-4ade2da5537d", "6f5318ff-95be-426b-90a1-67809d423c46" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Attachments_Tickets_TicketId",
                schema: "Dbo",
                table: "Ticket_Attachments",
                column: "TicketId",
                principalSchema: "Dbo",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Attachments_Tickets_TicketId",
                schema: "Dbo",
                table: "Ticket_Attachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket_Attachments",
                schema: "Dbo",
                table: "Ticket_Attachments");

            migrationBuilder.RenameTable(
                name: "Ticket_Attachments",
                schema: "Dbo",
                newName: "Attachments",
                newSchema: "Dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Attachments_TicketId",
                schema: "Dbo",
                table: "Attachments",
                newName: "IX_Attachments_TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachments",
                schema: "Dbo",
                table: "Attachments",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2267));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2185));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2189));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(1910));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(1925));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(1927));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(1929));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(1931));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2223));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 28, 11, 30, 27, 949, DateTimeKind.Local).AddTicks(2239));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a26e445d-522a-4d23-9a5b-3dbbb56fb9c6", "1a920491-7d9a-4b8a-9b83-69690dea9a90" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Tickets_TicketId",
                schema: "Dbo",
                table: "Attachments",
                column: "TicketId",
                principalSchema: "Dbo",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
