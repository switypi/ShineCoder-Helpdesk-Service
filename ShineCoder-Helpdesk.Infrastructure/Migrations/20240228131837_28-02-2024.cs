using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShineCoder_Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _28022024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusUpdateReason",
                schema: "Dbo",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tkt_UpdateReasonId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tkt_UpdateReasons",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tkt_UpdateReasons", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3212));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3214));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3127));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3131));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 28, 18, 48, 36, 541, DateTimeKind.Local).AddTicks(3133));

            migrationBuilder.InsertData(
                schema: "Dbo",
                table: "Tkt_UpdateReasons",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedDate", "Description", "IsDefault", "ModifiedDate", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, null, null, "Success", true, null, "Success", null },
                    { 2, true, null, null, "Failed", false, null, "Failed to complete", null },
                    { 3, true, null, null, "No Need", false, null, "Not-Needed", null }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58ebd704-9d4d-4ec2-a5d6-a48c6995b9c7", "AQAAAAIAAYagAAAAEClVg+0r8vJ/sQk7GjbL18J5ZphdpZf/LeYI75a4jIeGXq/iO20Bco83qBkRFLXG/A==", "6bdef764-7956-465c-94e8-426f85316d6d" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Tkt_UpdateReasonId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_UpdateReasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tkt_UpdateReasons_Tkt_UpdateReasonId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_UpdateReasonId",
                principalSchema: "Dbo",
                principalTable: "Tkt_UpdateReasons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tkt_UpdateReasons_Tkt_UpdateReasonId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Tkt_UpdateReasons",
                schema: "Dbo");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Tkt_UpdateReasonId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "StatusUpdateReason",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Tkt_UpdateReasonId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(4001));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3875));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3663));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3665));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3668));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3976));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 22, 14, 36, 52, 139, DateTimeKind.Local).AddTicks(3978));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4436338-f93f-49ff-9652-58eb2034679c", "AQAAAAIAAYagAAAAEMkPDGtkMAroNHjNJoRErBp+0uPb8utWdNQoXLYYldLfdvjwEUHel0msFWtpHYhUWA==", "0c50ca6a-e67c-479e-873a-bc758d142700" });
        }
    }
}
