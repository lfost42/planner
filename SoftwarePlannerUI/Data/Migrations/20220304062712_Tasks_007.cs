using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class Tasks_007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequirementModel_RequirementModel_RequirementModelId1",
                table: "RequirementModel");

            migrationBuilder.DropIndex(
                name: "IX_RequirementModel_RequirementModelId1",
                table: "RequirementModel");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "RequirementModel");

            migrationBuilder.DropColumn(
                name: "RequirementModelId1",
                table: "RequirementModel");

            migrationBuilder.AddColumn<int>(
                name: "TaskModelId",
                table: "HistoryModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskModelId",
                table: "FileModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TargetDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RequirementModelId = table.Column<int>(type: "integer", nullable: false),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateClosed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    HistoryModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskModel_CreatorModel_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskModel_HistoryModel_HistoryModelId",
                        column: x => x.HistoryModelId,
                        principalTable: "HistoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskModel_RequirementModel_RequirementModelId",
                        column: x => x.RequirementModelId,
                        principalTable: "RequirementModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskModelUserModel",
                columns: table => new
                {
                    TaskModelssId = table.Column<int>(type: "integer", nullable: false),
                    UserModelsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskModelUserModel", x => new { x.TaskModelssId, x.UserModelsId });
                    table.ForeignKey(
                        name: "FK_TaskModelUserModel_AspNetUsers_UserModelsId",
                        column: x => x.UserModelsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskModelUserModel_TaskModel_TaskModelssId",
                        column: x => x.TaskModelssId,
                        principalTable: "TaskModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryModel_TaskModelId",
                table: "HistoryModel",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_TaskModelId",
                table: "FileModel",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModel_CreatorModelId",
                table: "TaskModel",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModel_HistoryModelId",
                table: "TaskModel",
                column: "HistoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModel_RequirementModelId",
                table: "TaskModel",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModelUserModel_UserModelsId",
                table: "TaskModelUserModel",
                column: "UserModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_TaskModel_TaskModelId",
                table: "FileModel",
                column: "TaskModelId",
                principalTable: "TaskModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_TaskModel_TaskModelId",
                table: "HistoryModel",
                column: "TaskModelId",
                principalTable: "TaskModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_TaskModel_TaskModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_TaskModel_TaskModelId",
                table: "HistoryModel");

            migrationBuilder.DropTable(
                name: "TaskModelUserModel");

            migrationBuilder.DropTable(
                name: "TaskModel");

            migrationBuilder.DropIndex(
                name: "IX_HistoryModel_TaskModelId",
                table: "HistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_FileModel_TaskModelId",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "TaskModelId",
                table: "HistoryModel");

            migrationBuilder.DropColumn(
                name: "TaskModelId",
                table: "FileModel");

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "RequirementModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId1",
                table: "RequirementModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequirementModel_RequirementModelId1",
                table: "RequirementModel",
                column: "RequirementModelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementModel_RequirementModel_RequirementModelId1",
                table: "RequirementModel",
                column: "RequirementModelId1",
                principalTable: "RequirementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
