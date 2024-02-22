using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShineCoder_Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _22022024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Dbo",
                table: "Ticket_Levels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Dbo",
                table: "Ticket_Levels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Dbo",
                table: "Ticket_Levels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "VIEWACCESS", "True", 1 },
                    { 2, "ADDACCESS", "True", 1 },
                    { 3, "EDITACCESS", "True", 1 },
                    { 4, "DELETEACCESS", "True", 1 }
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NormalizedName", "RoleName" },
                values: new object[] { "Admin", "Admin" });

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
                columns: new[] { "Active", "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { true, "e4436338-f93f-49ff-9652-58eb2034679c", "admin@gmail.com", "admin", "AQAAAAIAAYagAAAAEMkPDGtkMAroNHjNJoRErBp+0uPb8utWdNQoXLYYldLfdvjwEUHel0msFWtpHYhUWA==", "0c50ca6a-e67c-479e-873a-bc758d142700" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "RoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NormalizedName", "RoleName" },
                values: new object[] { "ADMIN", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsActive", "IsAgent", "IsClient", "Name", "NormalizedName", "RoleName" },
                values: new object[,]
                {
                    { 2, null, true, false, true, "CLIENT", "CLIENT", "CLIENT" },
                    { 3, null, true, true, false, "AGENT", "AGENT", "AGENT" }
                });

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7857));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7862));

            migrationBuilder.InsertData(
                schema: "Dbo",
                table: "Ticket_Levels",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedDate", "Description", "IsDefault", "ModifiedDate", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, null, null, "P1 level", true, null, "P1", null },
                    { 2, true, null, null, "P2 level", true, null, "P2", null },
                    { 3, true, null, null, "P3 level", true, null, "P3", null }
                });

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7784));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7788));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7791));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7793));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7426));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7440));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7443));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7445));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7825));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7828));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 13, 16, 22, 52, 553, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Active", "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { false, "03efb590-a76a-4757-91e1-9b2211970aca", null, null, "AQAAAAIAAYagAAAAEMRq17yUGfOG/7I/1QSOiam2yzauEpcMFIXuonELAmU9DlJEGUuB5NAHPe7cKQCWxg==", "97100062-a1a7-44e9-ba15-ef2a36a24041" });
        }
    }
}
