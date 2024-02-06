using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShineCoder_Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _300120244 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Attachments_Tickets_TicketId",
            //    schema: "Dbo",
            //    table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Impacts_Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Levels_TicketLevelId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Modes_Ticket_ModeId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Priorities_TicketPriorityId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Status_TicketStatusId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                schema: "Dbo",
                table: "Attachments");

            migrationBuilder.RenameTable(
                name: "Attachments",
                schema: "Dbo",
                newName: "Ticket_Attachments",
                newSchema: "Dbo");

            migrationBuilder.RenameColumn(
                name: "Tkt_Subject",
                schema: "Dbo",
                table: "Tickets",
                newName: "Ticket_Subject");

            migrationBuilder.RenameColumn(
                name: "Tkt_Desc",
                schema: "Dbo",
                table: "Tickets",
                newName: "Ticket_Desc");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_TicketId",
                schema: "Dbo",
                table: "Ticket_Attachments",
                newName: "IX_Ticket_Attachments_TicketId");

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Ticket_ModeId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TicketStatusId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TicketPriorityId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TicketLevelId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7483));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7413));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7417));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7419));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7421));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7453));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 30, 16, 16, 34, 574, DateTimeKind.Local).AddTicks(7455));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1d525114-5258-43e2-b0b2-aeaa6c1d05e7", "695b6b8f-7208-4b88-9659-821340200da7" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Attachments_Tickets_TicketId",
                schema: "Dbo",
                table: "Ticket_Attachments",
                column: "TicketId",
                principalSchema: "Dbo",
                principalTable: "Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Ticket_Impacts_Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_ImpactId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Impacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Ticket_Levels_TicketLevelId",
                schema: "Dbo",
                table: "Tickets",
                column: "TicketLevelId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Ticket_Modes_Ticket_ModeId",
                schema: "Dbo",
                table: "Tickets",
                column: "Ticket_ModeId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Modes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Ticket_Priorities_TicketPriorityId",
                schema: "Dbo",
                table: "Tickets",
                column: "TicketPriorityId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Priorities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Ticket_Status_TicketStatusId",
                schema: "Dbo",
                table: "Tickets",
                column: "TicketStatusId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Attachments_Tickets_TicketId",
                schema: "Dbo",
                table: "Ticket_Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Impacts_Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Levels_TicketLevelId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Modes_Ticket_ModeId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Priorities_TicketPriorityId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Status_TicketStatusId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket_Attachments",
                schema: "Dbo",
                table: "Ticket_Attachments");

            migrationBuilder.RenameTable(
                name: "Ticket_Attachments",
                schema: "Dbo",
                newName: "Attachments",
                newSchema: "Dbo");

            migrationBuilder.RenameColumn(
                name: "Ticket_Subject",
                schema: "Dbo",
                table: "Tickets",
                newName: "Tkt_Subject");

            migrationBuilder.RenameColumn(
                name: "Ticket_Desc",
                schema: "Dbo",
                table: "Tickets",
                newName: "Tkt_Desc");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_Attachments_TicketId",
                schema: "Dbo",
                table: "Attachments",
                newName: "IX_Attachments_TicketId");

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ticket_ModeId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TicketStatusId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TicketPriorityId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TicketLevelId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Ticket_Impacts_Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_ImpactId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Impacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Ticket_Levels_TicketLevelId",
                schema: "Dbo",
                table: "Tickets",
                column: "TicketLevelId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Ticket_Modes_Ticket_ModeId",
                schema: "Dbo",
                table: "Tickets",
                column: "Ticket_ModeId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Modes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Ticket_Priorities_TicketPriorityId",
                schema: "Dbo",
                table: "Tickets",
                column: "TicketPriorityId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Ticket_Status_TicketStatusId",
                schema: "Dbo",
                table: "Tickets",
                column: "TicketStatusId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
