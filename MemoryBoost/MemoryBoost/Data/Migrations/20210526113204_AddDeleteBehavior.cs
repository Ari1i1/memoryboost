using Microsoft.EntityFrameworkCore.Migrations;

namespace MemoryBoost.Data.Migrations
{
    public partial class AddDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Trainings_TrainingId",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Trainings_TrainingId",
                table: "Games",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Trainings_TrainingId",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Trainings_TrainingId",
                table: "Games",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
