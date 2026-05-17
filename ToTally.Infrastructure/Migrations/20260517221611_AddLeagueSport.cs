using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToTally.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLeagueSport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sport",
                table: "leagues",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sport",
                table: "leagues");
        }
    }
}
