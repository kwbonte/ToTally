using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ToTally.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    division_id = table.Column<int>(type: "integer", nullable: false),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    abbreviation = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    created_on_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    modified_on_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.id);
                    table.ForeignKey(
                        name: "FK_teams_divisions_division_id",
                        column: x => x.division_id,
                        principalTable: "divisions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_teams_venues_venue_id",
                        column: x => x.venue_id,
                        principalTable: "venues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teams_abbreviation",
                table: "teams",
                column: "abbreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teams_city_name",
                table: "teams",
                columns: new[] { "city", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teams_division_id",
                table: "teams",
                column: "division_id");

            migrationBuilder.CreateIndex(
                name: "IX_teams_venue_id",
                table: "teams",
                column: "venue_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
