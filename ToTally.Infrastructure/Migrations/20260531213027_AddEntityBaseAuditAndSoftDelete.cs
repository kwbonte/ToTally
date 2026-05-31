using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToTally.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityBaseAuditAndSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "venues",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "created_on_utc",
                table: "venues",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

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

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "venues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "modified_by",
                table: "venues",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "modified_on_utc",
                table: "venues",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "leagues",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "created_on_utc",
                table: "leagues",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

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

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "leagues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "modified_by",
                table: "leagues",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "modified_on_utc",
                table: "leagues",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "venues");

            migrationBuilder.DropColumn(
                name: "created_on_utc",
                table: "venues");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "venues");

            migrationBuilder.DropColumn(
                name: "deleted_on_utc",
                table: "venues");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "venues");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "venues");

            migrationBuilder.DropColumn(
                name: "modified_on_utc",
                table: "venues");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "leagues");

            migrationBuilder.DropColumn(
                name: "created_on_utc",
                table: "leagues");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "leagues");

            migrationBuilder.DropColumn(
                name: "deleted_on_utc",
                table: "leagues");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "leagues");

            migrationBuilder.DropColumn(
                name: "modified_by",
                table: "leagues");

            migrationBuilder.DropColumn(
                name: "modified_on_utc",
                table: "leagues");
        }
    }
}
