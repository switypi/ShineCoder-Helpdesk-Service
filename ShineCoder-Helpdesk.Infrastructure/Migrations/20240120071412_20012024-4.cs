using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShineCoder_Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _200120244 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketLevelId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketUrgencyId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Tkt_Number",
            //    schema: "Dbo",
            //    table: "Tickets",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    computedColumnSql: "dbo.Fn_CreateTicketNumber('SNC-', CAST(1000 as nvarchar(10)),4,'0')",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Ticket_Attachments",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Attachments_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalSchema: "Dbo",
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7622));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7624));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Impacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7625));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7576));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Priorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7577));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7108));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7124));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7126));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7127));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7597));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7601));

            migrationBuilder.UpdateData(
                schema: "Dbo",
                table: "Ticket_Urgencies",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 20, 12, 44, 12, 153, DateTimeKind.Local).AddTicks(7602));

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8e190e35-6c0f-4e75-a991-31d8c6cdda00", "633b8b62-6a98-4267-8b5c-c5213b3d40bd" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketLevelId",
                schema: "Dbo",
                table: "Tickets",
                column: "TicketLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketUrgencyId",
                schema: "Dbo",
                table: "Tickets",
                column: "TicketUrgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_ImpactId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Attachments_TicketId",
                schema: "Dbo",
                table: "Ticket_Attachments",
                column: "TicketId");

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
                name: "FK_Tickets_Ticket_Urgencies_TicketUrgencyId",
                schema: "Dbo",
                table: "Tickets",
                column: "TicketUrgencyId",
                principalSchema: "Dbo",
                principalTable: "Ticket_Urgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Impacts_Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Levels_TicketLevelId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Ticket_Urgencies_TicketUrgencyId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Ticket_Attachments",
                schema: "Dbo");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketLevelId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketUrgencyId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketLevelId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketUrgencyId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Tkt_ImpactId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "Tkt_Number",
                schema: "Dbo",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "dbo.Fn_CreateTicketNumber('SNC-', CAST(1000 as nvarchar(10)),4,'0')");

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
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "773fe2bb-60df-40f8-8f16-17e1833545cf", "35234337-7412-478c-8bc4-47b3f4d1b041" });
        }
    }
}
