using Microsoft.EntityFrameworkCore.Migrations;

namespace MemoryBoost.Data.Migrations
{
    public partial class AddNumInQueueForGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumInQueue",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumInQueue",
                table: "Games");
        }
    }
}
