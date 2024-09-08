﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjeOdev.Migrations
{
    /// <inheritdoc />
    public partial class dersProgramison : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToplamSaat",
                table: "Derss",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToplamSaat",
                table: "Derss");
        }
    }
}
