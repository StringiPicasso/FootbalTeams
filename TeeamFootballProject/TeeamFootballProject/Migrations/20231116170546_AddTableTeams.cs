using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeeamFootballProject.Migrations
{
    public partial class AddTableTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamNames_Players_PlayerId",
                table: "TeamNames");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamNames",
                table: "TeamNames");

            migrationBuilder.DropIndex(
                name: "IX_TeamNames_PlayerId",
                table: "TeamNames");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "TeamNames");

            migrationBuilder.RenameTable(
                name: "TeamNames",
                newName: "Teams");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Teams",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "TeamNames");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TeamNames",
                newName: "TeamId");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "TeamNames",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamNames",
                table: "TeamNames",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamNames_PlayerId",
                table: "TeamNames",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamNames_Players_PlayerId",
                table: "TeamNames",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
