using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class Projects_003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectName = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    TargetDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FileExtension = table.Column<string>(type: "text", nullable: true),
                    FileData = table.Column<byte[]>(type: "bytea", nullable: true),
                    DateUploaded = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserModelId = table.Column<string>(type: "text", nullable: true),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileModel_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FileModel_ProjectModel_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "ProjectModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    UserModelId = table.Column<string>(type: "text", nullable: true),
                    UpdatedItem = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PreviousValue = table.Column<string>(type: "text", nullable: true),
                    CurrentValue = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryModel_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoryModel_ProjectModel_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "ProjectModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModelTeamModel",
                columns: table => new
                {
                    ProjectModelsId = table.Column<int>(type: "integer", nullable: false),
                    TeamModelsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModelTeamModel", x => new { x.ProjectModelsId, x.TeamModelsId });
                    table.ForeignKey(
                        name: "FK_ProjectModelTeamModel_ProjectModel_ProjectModelsId",
                        column: x => x.ProjectModelsId,
                        principalTable: "ProjectModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectModelTeamModel_TeamModel_TeamModelsId",
                        column: x => x.TeamModelsId,
                        principalTable: "TeamModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModelUserModel",
                columns: table => new
                {
                    ProjectModelssId = table.Column<int>(type: "integer", nullable: false),
                    UserModelsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModelUserModel", x => new { x.ProjectModelssId, x.UserModelsId });
                    table.ForeignKey(
                        name: "FK_ProjectModelUserModel_AspNetUsers_UserModelsId",
                        column: x => x.UserModelsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectModelUserModel_ProjectModel_ProjectModelssId",
                        column: x => x.ProjectModelssId,
                        principalTable: "ProjectModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_ProjectModelId",
                table: "FileModel",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_UserModelId",
                table: "FileModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryModel_ProjectModelId",
                table: "HistoryModel",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryModel_UserModelId",
                table: "HistoryModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModelTeamModel_TeamModelsId",
                table: "ProjectModelTeamModel",
                column: "TeamModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModelUserModel_UserModelsId",
                table: "ProjectModelUserModel",
                column: "UserModelsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileModel");

            migrationBuilder.DropTable(
                name: "HistoryModel");

            migrationBuilder.DropTable(
                name: "ProjectModelTeamModel");

            migrationBuilder.DropTable(
                name: "ProjectModelUserModel");

            migrationBuilder.DropTable(
                name: "ProjectModel");
        }
    }
}
