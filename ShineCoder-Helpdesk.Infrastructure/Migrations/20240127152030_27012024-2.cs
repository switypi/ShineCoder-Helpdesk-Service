using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShineCoder_Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _270120242 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Attachments_Tickets_TicketId",
                schema: "Dbo",
                table: "Ticket_Attachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket_Attachments",
                schema: "Dbo",
                table: "Ticket_Attachments");

            migrationBuilder.DeleteData(
                schema: "Dbo",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Dbo",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Dbo",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

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
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5508));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5511));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5513));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5308));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5311));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5314));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(4895));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5390));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5397));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 50, 29, 679, DateTimeKind.Local).AddTicks(5400));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "957e5471-a2ee-4670-a7c5-c3540a909dfb", "44d29c23-5f69-496a-b119-63105ee0a556" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Tickets_TicketId",
                schema: "Dbo",
                table: "Attachments",
                column: "TicketId",
                principalSchema: "Dbo",
                principalTable: "Tickets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "Dbo",
                table: "Categories",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedDate", "Description", "IsDefault", "ModifiedDate", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, null, null, "Network", true, null, "Network", null },
                    { 2, true, null, null, "Printer", false, null, "Printer", null },
                    { 3, true, null, null, "Software program", false, null, "Software", null }
                });

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9683));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9687));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9624));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9627));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9629));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9631));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9369));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9657));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9659));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 14, 24, 4, 538, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "af949aca-f640-42a8-999b-651014be7095", "84eb69a2-a30c-45c5-b452-0217bd83de18" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Attachments_Tickets_TicketId",
                schema: "Dbo",
                table: "Ticket_Attachments",
                column: "TicketId",
                principalSchema: "Dbo",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
