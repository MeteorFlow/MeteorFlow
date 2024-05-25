using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeteorFlow.Core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app_definitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: false),
                    icon = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    base_definition_id = table.Column<Guid>(type: "uuid", nullable: true),
                    definition_type = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    row_version = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_app_definitions", x => x.id);
                    table.ForeignKey(
                        name: "fk_app_definitions_app_definitions_base_definition_id",
                        column: x => x.base_definition_id,
                        principalTable: "app_definitions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "app_settings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: false),
                    value = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    row_version = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_app_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_version_controls",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    major_version = table.Column<int>(type: "integer", nullable: false),
                    minor_version = table.Column<int>(type: "integer", nullable: false),
                    patch_version = table.Column<int>(type: "integer", nullable: false),
                    app_definition_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    row_version = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_app_version_controls", x => x.id);
                    table.ForeignKey(
                        name: "fk_app_version_controls_app_definitions_app_definition_id",
                        column: x => x.app_definition_id,
                        principalTable: "app_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "app_instances",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: false),
                    icon = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    version_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    last_modified_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    delete_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    row_version = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_app_instances", x => x.id);
                    table.ForeignKey(
                        name: "fk_app_instances_app_version_controls_version_id",
                        column: x => x.version_id,
                        principalTable: "app_version_controls",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_app_definitions_base_definition_id",
                table: "app_definitions",
                column: "base_definition_id");

            migrationBuilder.CreateIndex(
                name: "ix_app_instances_version_id",
                table: "app_instances",
                column: "version_id");

            migrationBuilder.CreateIndex(
                name: "ix_app_version_controls_app_definition_id",
                table: "app_version_controls",
                column: "app_definition_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_instances");

            migrationBuilder.DropTable(
                name: "app_settings");

            migrationBuilder.DropTable(
                name: "app_version_controls");

            migrationBuilder.DropTable(
                name: "app_definitions");
        }
    }
}
