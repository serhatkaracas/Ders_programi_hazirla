using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjeOdev.Migrations
{
    /// <inheritdoc />
    public partial class dersslikders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DerslikID",
                table: "Derss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Derss_DerslikID",
                table: "Derss",
                column: "DerslikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Derss_Dersliks_DerslikID",
                table: "Derss",
                column: "DerslikID",
                principalTable: "Dersliks",
                principalColumn: "DerslikID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Derss_Dersliks_DerslikID",
                table: "Derss");

            migrationBuilder.DropIndex(
                name: "IX_Derss_DerslikID",
                table: "Derss");

            migrationBuilder.DropColumn(
                name: "DerslikID",
                table: "Derss");
        }
    }
}
