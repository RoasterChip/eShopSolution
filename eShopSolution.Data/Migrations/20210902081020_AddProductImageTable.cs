using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class AddProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 29, 15, 38, 2, 251, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 2, 15, 10, 19, 642, DateTimeKind.Local).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "C0467CF7-5DAE-478B-9E75-1079B8EAA218",
                column: "ConcurrencyStamp",
                value: "d9d48919-128c-430e-98ce-a48e47387b10");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "25BEC450-B684-4844-A120-61CA38093AA3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "754c7571-2d0d-4702-a1f4-840bcc587fca", "AQAAAAEAACcQAAAAEM8zY1TDZPJjvO5z6KJfmqdTcWW7Ub2nPnAwAmm+leA9fEqGrivsp30N+FWIx4QNIQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 29, 15, 38, 2, 251, DateTimeKind.Local).AddTicks(8423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 29, 15, 38, 2, 265, DateTimeKind.Local).AddTicks(711));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "C0467CF7-5DAE-478B-9E75-1079B8EAA218",
                column: "ConcurrencyStamp",
                value: "1e181085-a448-4402-8a64-4573b8ed4ed7");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "25BEC450-B684-4844-A120-61CA38093AA3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f85f34bf-d053-4b3c-8598-188025f80638", "AQAAAAEAACcQAAAAECtF1c+UfYvF8Ehy9PccgflTXD0eTEmpewSpt9GQvQ/NOTc2zFXbsTwSGY5DYQvOig==" });
        }
    }
}
