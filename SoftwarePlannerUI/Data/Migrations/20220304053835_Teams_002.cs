using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class Teams_002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamModelId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TeamModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamModelId",
                table: "AspNetUsers",
                column: "TeamModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TeamModel_TeamModelId",
                table: "AspNetUsers",
                column: "TeamModelId",
                principalTable: "TeamModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TeamModel_TeamModelId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TeamModel");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamModelId",
                table: "AspNetUsers");
        }
    }
}
