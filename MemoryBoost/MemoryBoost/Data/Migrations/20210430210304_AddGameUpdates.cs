using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MemoryBoost.Data.Migrations
{
    public partial class AddGameUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FirstFlippedCardId",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfFlippedCards",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstFlippedCardId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "NumberOfFlippedCards",
                table: "Games");
        }
    }
}
