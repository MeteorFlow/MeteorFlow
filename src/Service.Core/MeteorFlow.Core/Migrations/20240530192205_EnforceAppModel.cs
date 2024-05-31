using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeteorFlow.Core.Migrations
{
    /// <inheritdoc />
    public partial class EnforceAppModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tenant_id",
                table: "app_instances");

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                table: "app_definitions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tenant_id",
                table: "app_definitions");

            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                table: "app_instances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
