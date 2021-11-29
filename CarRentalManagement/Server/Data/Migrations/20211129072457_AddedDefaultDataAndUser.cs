using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalManagement.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "59657161-45e6-493f-8f22-d57a613e3f19", "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "76d3c93b-3e37-4872-b3ae-d417fdd6fba9", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "cd1b2019-f75f-4fa7-b3cc-bba88c81391f", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAEM+oLe6YtT9ruM7fh/d0zuVKM7QFeU4qJr2zzBUTNLn3A52qj/vFauWc5gzWX/yT1Q==", null, false, "6f7def1f-d73e-448c-a731-234ac82ab09f", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 11, 29, 15, 24, 56, 637, DateTimeKind.Local).AddTicks(1168), new DateTime(2021, 11, 29, 15, 24, 56, 638, DateTimeKind.Local).AddTicks(3649), "Black", "System" },
                    { 2, "System", new DateTime(2021, 11, 29, 15, 24, 56, 638, DateTimeKind.Local).AddTicks(4919), new DateTime(2021, 11, 29, 15, 24, 56, 638, DateTimeKind.Local).AddTicks(4926), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(284), new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(292), "BMW", "System" },
                    { 2, "System", new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(297), new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(298), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(4949), new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(4957), "3 Series", "System" },
                    { 2, "System", new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(4961), new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(4962), "X5", "System" },
                    { 3, "System", new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(4964), new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(4965), "PRius", "System" },
                    { 4, "System", new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(4967), new DateTime(2021, 11, 29, 15, 24, 56, 640, DateTimeKind.Local).AddTicks(4968), "Rav4", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
