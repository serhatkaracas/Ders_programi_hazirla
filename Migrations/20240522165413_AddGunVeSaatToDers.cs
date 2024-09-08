using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjeOdev.Migrations
{
    /// <inheritdoc />
    public partial class AddGunVeSaatToDers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gun",
                table: "Derss",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Saat",
                table: "Derss",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gun",
                table: "Derss");

            migrationBuilder.DropColumn(
                name: "Saat",
                table: "Derss");
        }
    }
}
