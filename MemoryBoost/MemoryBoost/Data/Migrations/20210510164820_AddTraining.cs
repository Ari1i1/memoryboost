using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MemoryBoost.Data.Migrations
{
    public partial class AddTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TrainingId",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PlayerId = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    NumOfLevelOneGame = table.Column<int>(nullable: true),
                    NumOfLevelTwoGame = table.Column<int>(nullable: true),
                    NumOfLevelThreeGame = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainings_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_TrainingId",
                table: "Games",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_PlayerId",
                table: "Trainings",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Trainings_TrainingId",
                table: "Games",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Trainings_TrainingId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Games_TrainingId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "Games");
        }
    }
}
