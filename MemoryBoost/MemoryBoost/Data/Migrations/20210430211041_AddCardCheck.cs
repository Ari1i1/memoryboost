using Microsoft.EntityFrameworkCore.Migrations;

namespace MemoryBoost.Data.Migrations
{
    public partial class AddCardCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Check",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Check",
                table: "Cards");
        }
    }
}
