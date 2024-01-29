using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShineCoder_Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _28012024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
