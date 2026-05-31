using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToTally.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVenues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "venues",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    state_or_country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    latitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: true),
                    longitude = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: true),
                    is_dome = table.Column<bool>(type: "boolean", nullable: false),
                    is_neutral_site_capable = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venues", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_venues_name",
                table: "venues",
                column: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "venues");
        }
    }
}
