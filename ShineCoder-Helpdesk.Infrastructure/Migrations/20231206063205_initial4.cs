using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShineCoder_Helpdesk.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Departments_Tkt_DepartmentId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Locations_Tkt_LocationId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_RequestTypes_Tkt_RequestTypeId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_SubCategories_Tkt_SubCategoryId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_SubCategoryId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_RequestUserId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_RequestTypeId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_LocationId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_DepartmentId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Tkt_CategoryId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Tkt_CategoryId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Categories_Tkt_CategoryId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_CategoryId",
                principalSchema: "Dbo",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Departments_Tkt_DepartmentId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_DepartmentId",
                principalSchema: "Dbo",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Locations_Tkt_LocationId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_LocationId",
                principalSchema: "Dbo",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_RequestTypes_Tkt_RequestTypeId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_RequestTypeId",
                principalSchema: "Dbo",
                principalTable: "RequestTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_SubCategories_Tkt_SubCategoryId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_SubCategoryId",
                principalSchema: "Dbo",
                principalTable: "SubCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Categories_Tkt_CategoryId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Departments_Tkt_DepartmentId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Locations_Tkt_LocationId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_RequestTypes_Tkt_RequestTypeId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_SubCategories_Tkt_SubCategoryId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Tkt_CategoryId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Tkt_CategoryId",
                schema: "Dbo",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_SubCategoryId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_RequestUserId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_RequestTypeId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_LocationId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Tkt_DepartmentId",
                schema: "Dbo",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Departments_Tkt_DepartmentId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_DepartmentId",
                principalSchema: "Dbo",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Locations_Tkt_LocationId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_LocationId",
                principalSchema: "Dbo",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_RequestTypes_Tkt_RequestTypeId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_RequestTypeId",
                principalSchema: "Dbo",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_SubCategories_Tkt_SubCategoryId",
                schema: "Dbo",
                table: "Tickets",
                column: "Tkt_SubCategoryId",
                principalSchema: "Dbo",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
