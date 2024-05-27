using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeteorFlow.FormBuilder.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_form_elements_element_schemas_schema_id",
                table: "form_elements");

            migrationBuilder.DropIndex(
                name: "ix_form_elements_schema_id",
                table: "form_elements");

            migrationBuilder.DropColumn(
                name: "schema_id",
                table: "form_elements");

            migrationBuilder.AddColumn<Guid>(
                name: "schema_id",
                table: "form_blocks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "element_schemas",
                columns: new[] { "id", "autocomplete", "created_date", "delete_date", "input_type", "last_modified_date", "name", "read_only", "required", "row_version", "searchable", "type" },
                values: new object[,]
                {
                    { new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460"), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 2, null, "name", false, true, null, true, "text" },
                    { new Guid("6ccc1efb-4054-4ace-8fdf-47346bbe6809"), true, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, 3, null, "weather_type", false, true, null, true, "choice" }
                });

            migrationBuilder.InsertData(
                table: "form_elements",
                columns: new[] { "id", "category", "created_date", "delete_date", "description", "icon", "last_modified_date", "name", "renderer", "row_version" },
                values: new object[,]
                {
                    { new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Single line text input", "", null, "Text input", "CoreTextField", null },
                    { new Guid("ea98ca53-bb87-485d-8aa9-750adaa9f89e"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Plain checkout input", "i-mdi-checkbox-outline", null, "Choice input", "CoreSelect", null }
                });

            migrationBuilder.InsertData(
                table: "form_blocks",
                columns: new[] { "id", "append", "created_date", "delete_date", "description", "display_name", "element_id", "icon", "last_modified_date", "name", "order", "placeholder", "prepend", "row_version", "schema_id", "tooltip", "version_id" },
                values: new object[,]
                {
                    { new Guid("0d3007aa-d3e4-4562-8532-a3d17a95d4fc"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Nội dung", new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"), null, null, "content", 0, null, null, null, new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3b732e89-af2f-4793-a234-45c9dac1f590"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Tiêu đề", new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"), null, null, "title", 0, null, null, null, new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("68f49837-8a4e-4294-9df2-091068c01795"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Ngày gửi thông báo", new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"), null, null, "notificationDate", 0, null, null, null, new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460"), null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a3232fd5-64e5-464a-9ae3-fcab5d906818"), null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Khẩn cấp", new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"), null, null, "emergency", 0, null, null, null, new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460"), null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_form_blocks_schema_id",
                table: "form_blocks",
                column: "schema_id");

            migrationBuilder.AddForeignKey(
                name: "fk_form_blocks_element_schemas_schema_id",
                table: "form_blocks",
                column: "schema_id",
                principalTable: "element_schemas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_form_blocks_element_schemas_schema_id",
                table: "form_blocks");

            migrationBuilder.DropIndex(
                name: "ix_form_blocks_schema_id",
                table: "form_blocks");

            migrationBuilder.DeleteData(
                table: "element_schemas",
                keyColumn: "id",
                keyValue: new Guid("6ccc1efb-4054-4ace-8fdf-47346bbe6809"));

            migrationBuilder.DeleteData(
                table: "form_blocks",
                keyColumn: "id",
                keyValue: new Guid("0d3007aa-d3e4-4562-8532-a3d17a95d4fc"));

            migrationBuilder.DeleteData(
                table: "form_blocks",
                keyColumn: "id",
                keyValue: new Guid("3b732e89-af2f-4793-a234-45c9dac1f590"));

            migrationBuilder.DeleteData(
                table: "form_blocks",
                keyColumn: "id",
                keyValue: new Guid("68f49837-8a4e-4294-9df2-091068c01795"));

            migrationBuilder.DeleteData(
                table: "form_blocks",
                keyColumn: "id",
                keyValue: new Guid("a3232fd5-64e5-464a-9ae3-fcab5d906818"));

            migrationBuilder.DeleteData(
                table: "form_elements",
                keyColumn: "id",
                keyValue: new Guid("ea98ca53-bb87-485d-8aa9-750adaa9f89e"));

            migrationBuilder.DeleteData(
                table: "element_schemas",
                keyColumn: "id",
                keyValue: new Guid("1d75ee8c-5565-4374-98aa-06d0785e9460"));

            migrationBuilder.DeleteData(
                table: "form_elements",
                keyColumn: "id",
                keyValue: new Guid("e7db0667-58e4-406f-b8f8-cbe7925a7778"));

            migrationBuilder.DropColumn(
                name: "schema_id",
                table: "form_blocks");

            migrationBuilder.AddColumn<Guid>(
                name: "schema_id",
                table: "form_elements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_form_elements_schema_id",
                table: "form_elements",
                column: "schema_id");

            migrationBuilder.AddForeignKey(
                name: "fk_form_elements_element_schemas_schema_id",
                table: "form_elements",
                column: "schema_id",
                principalTable: "element_schemas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
