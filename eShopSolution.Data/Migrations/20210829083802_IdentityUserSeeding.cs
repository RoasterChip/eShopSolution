using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class IdentityUserSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 29, 15, 38, 2, 251, DateTimeKind.Local).AddTicks(8423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 29, 15, 31, 15, 883, DateTimeKind.Local).AddTicks(9485));

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "C0467CF7-5DAE-478B-9E75-1079B8EAA218", "25BEC450-B684-4844-A120-61CA38093AA3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 29, 15, 38, 2, 265, DateTimeKind.Local).AddTicks(711));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "C0467CF7-5DAE-478B-9E75-1079B8EAA218", "1e181085-a448-4402-8a64-4573b8ed4ed7", "AppRole", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "25BEC450-B684-4844-A120-61CA38093AA3", 0, "f85f34bf-d053-4b3c-8598-188025f80638", "AppUser", "androidforkha@gmail.com", true, false, null, "androidforkha@gmail.com", "admin", "AQAAAAEAACcQAAAAECtF1c+UfYvF8Ehy9PccgflTXD0eTEmpewSpt9GQvQ/NOTc2zFXbsTwSGY5DYQvOig==", null, false, "", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "C0467CF7-5DAE-478B-9E75-1079B8EAA218", "25BEC450-B684-4844-A120-61CA38093AA3" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "C0467CF7-5DAE-478B-9E75-1079B8EAA218");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "25BEC450-B684-4844-A120-61CA38093AA3");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Roles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 29, 15, 31, 15, 883, DateTimeKind.Local).AddTicks(9485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 29, 15, 38, 2, 251, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 8, 29, 15, 31, 15, 896, DateTimeKind.Local).AddTicks(8923));
        }
    }
}
