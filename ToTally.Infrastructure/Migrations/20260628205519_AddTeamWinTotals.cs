using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToTally.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamWinTotals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "team_win_totals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    team_id = table.Column<int>(type: "integer", nullable: false),
                    sportsbook_id = table.Column<Guid>(type: "uuid", nullable: false),
                    season_year = table.Column<int>(type: "integer", nullable: false),
                    total = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    over_american_odds = table.Column<int>(type: "integer", nullable: true),
                    under_american_odds = table.Column<int>(type: "integer", nullable: true),
                    observed_on_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_on_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    modified_on_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_win_totals", x => x.id);
                    table.ForeignKey(
                        name: "FK_team_win_totals_sportsbooks_sportsbook_id",
                        column: x => x.sportsbook_id,
                        principalTable: "sportsbooks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_team_win_totals_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_team_win_totals_sportsbook_id",
                table: "team_win_totals",
                column: "sportsbook_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_win_totals_team_id_sportsbook_id_season_year_observed_~",
                table: "team_win_totals",
                columns: new[] { "team_id", "sportsbook_id", "season_year", "observed_on_utc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "team_win_totals");
        }
    }
}
