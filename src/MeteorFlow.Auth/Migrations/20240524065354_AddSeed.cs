using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeteorFlow.Auth.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedUserRoleDate",
                table: "UserRole",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeleteDate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                table: "UserRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "UserRole",
                type: "bytea",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "DeleteDate", "LastModifiedDate", "Name", "NormalizedName", "RowVersion" },
                values: new object[,]
                {
                    { new Guid("a1b1c1d1-e1f1-1234-5678-9abcdef12345"), null, new DateTimeOffset(new DateTime(2024, 5, 24, 6, 53, 54, 484, DateTimeKind.Unspecified).AddTicks(1660), new TimeSpan(0, 0, 0, 0, 0)), null, null, "User", "USER", null },
                    { new Guid("a2b2c2d2-e2f2-1234-5678-9abcdef12345"), null, new DateTimeOffset(new DateTime(2024, 5, 24, 6, 53, 54, 484, DateTimeKind.Unspecified).AddTicks(1660), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Tenant", "TENANT", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a1b1c1d1-e1f1-1234-5678-9abcdef12345"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a2b2c2d2-e2f2-1234-5678-9abcdef12345"));

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserRole",
                newName: "CreatedUserRoleDate");
        }
    }
}
