using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeteorFlow.Core.Migrations
{
    /// <inheritdoc />
    public partial class IconIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "icon",
                table: "app_definitions",
                type: "text",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 2147483647);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "icon",
                table: "app_definitions",
                type: "text",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 2147483647,
                oldNullable: true);
        }
    }
}
