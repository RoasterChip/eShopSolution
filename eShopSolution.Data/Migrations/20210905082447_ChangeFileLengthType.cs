using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 9, 5, 15, 24, 46, 974, DateTimeKind.Local).AddTicks(8115));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "C0467CF7-5DAE-478B-9E75-1079B8EAA218",
                column: "ConcurrencyStamp",
                value: "9a980f02-b437-4ff5-a47d-5ccf29a9c688");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "25BEC450-B684-4844-A120-61CA38093AA3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e827f975-cee1-4d95-8772-4b7fd4484da6", "AQAAAAEAACcQAAAAEArLGqQXOP8v9Wzao7cegGVSRR6dKaoUuDQUQKnnjNftd2xjl0r8KmZX+9kExcuEIQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
        }
    }
}
