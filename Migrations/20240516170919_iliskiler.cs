using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjeOdev.Migrations
{
    /// <inheritdoc />
    public partial class iliskiler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "KullaniciRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRoles_Code",
                table: "KullaniciRoles",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRoles_KullaniciID",
                table: "KullaniciRoles",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Derss_OgretmenID",
                table: "Derss",
                column: "OgretmenID");

            migrationBuilder.CreateIndex(
                name: "IX_Derss_SinifID",
                table: "Derss",
                column: "SinifID");

            migrationBuilder.AddForeignKey(
                name: "FK_Derss_Ogretmens_OgretmenID",
                table: "Derss",
                column: "OgretmenID",
                principalTable: "Ogretmens",
                principalColumn: "OgretmenID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Derss_Sinifs_SinifID",
                table: "Derss",
                column: "SinifID",
                principalTable: "Sinifs",
                principalColumn: "SinifID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRoles_Kullanicis_KullaniciID",
                table: "KullaniciRoles",
                column: "KullaniciID",
                principalTable: "Kullanicis",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRoles_Rolles_Code",
                table: "KullaniciRoles",
                column: "Code",
                principalTable: "Rolles",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Derss_Ogretmens_OgretmenID",
                table: "Derss");

            migrationBuilder.DropForeignKey(
                name: "FK_Derss_Sinifs_SinifID",
                table: "Derss");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRoles_Kullanicis_KullaniciID",
                table: "KullaniciRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRoles_Rolles_Code",
                table: "KullaniciRoles");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciRoles_Code",
                table: "KullaniciRoles");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciRoles_KullaniciID",
                table: "KullaniciRoles");

            migrationBuilder.DropIndex(
                name: "IX_Derss_OgretmenID",
                table: "Derss");

            migrationBuilder.DropIndex(
                name: "IX_Derss_SinifID",
                table: "Derss");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "KullaniciRoles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
