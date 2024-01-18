using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShineCoder_Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _180120242 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "Identity",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Dbo",
                table: "Departments",
                columns: new[] { "Id", "Active", "CreatedBy", "CreatedDate", "Description", "IsDefault", "ModifiedDate", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, true, null, null, "Technology ", true, null, "Technology", null },
                    { 2, true, null, null, "Hardware", true, null, "Hardware", null },
                    { 3, true, null, null, "Software", true, null, "Software", null }
                });

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1215));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1218));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1222));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(876));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(890));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(892));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(894));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(897));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1256));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1259));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1261));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 18, 13, 30, 38, 978, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DepartmentId", "SecurityStamp" },
                values: new object[] { "773fe2bb-60df-40f8-8f16-17e1833545cf", null, "35234337-7412-478c-8bc4-47b3f4d1b041" });

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentId",
                schema: "Identity",
                table: "User",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Departments_DepartmentId",
                schema: "Identity",
                table: "User",
                column: "DepartmentId",
                principalSchema: "Dbo",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Departments_DepartmentId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DepartmentId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DeleteData(
                schema: "Dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "Identity",
                table: "User");

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4847));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4774));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4777));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4779));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4781));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4558));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4574));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4576));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 17, 10, 59, 58, 585, DateTimeKind.Local).AddTicks(4813));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1d7297b-6086-406e-93d9-03c7374c3416", "4e7ba659-79f9-49f5-b6b9-2b2754f45b14" });
        }
    }
}
