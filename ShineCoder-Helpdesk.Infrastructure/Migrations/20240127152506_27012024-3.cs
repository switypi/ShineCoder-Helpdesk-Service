using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShineCoder_Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _270120243 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5277));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5280));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5200));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5204));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5208));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(4891));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(4894));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(4898));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5241));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5243));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5245));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 27, 20, 55, 5, 898, DateTimeKind.Local).AddTicks(5247));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b4fb787-4fd5-4d69-a6ff-634eed31e565", "2be70b50-62ed-4e38-94f3-a2ea0183034b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
