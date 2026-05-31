using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToTally.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDeletedAuditColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "venues");

            migrationBuilder.DropColumn(
                name: "deleted_on_utc",
                table: "venues");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "leagues");

            migrationBuilder.DropColumn(
                name: "deleted_on_utc",
                table: "leagues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "deleted_by",
                table: "venues",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "deleted_on_utc",
                table: "venues",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deleted_by",
                table: "leagues",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "deleted_on_utc",
                table: "leagues",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
