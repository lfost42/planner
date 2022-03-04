using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class Requirements_006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "HistoryModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "FileModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RequirementModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TargetDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: false),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateClosed = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    RequirementModelId = table.Column<int>(type: "integer", nullable: false),
                    RequirementModelId1 = table.Column<int>(type: "integer", nullable: true),
                    HistoryModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementModel_CreatorModel_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequirementModel_HistoryModel_HistoryModelId",
                        column: x => x.HistoryModelId,
                        principalTable: "HistoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequirementModel_ProjectModel_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "ProjectModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequirementModel_RequirementModel_RequirementModelId1",
                        column: x => x.RequirementModelId1,
                        principalTable: "RequirementModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryModel_RequirementModelId",
                table: "HistoryModel",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_RequirementModelId",
                table: "FileModel",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RequirementModelId",
                table: "AspNetUsers",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementModel_CreatorModelId",
                table: "RequirementModel",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementModel_HistoryModelId",
                table: "RequirementModel",
                column: "HistoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementModel_ProjectModelId",
                table: "RequirementModel",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementModel_RequirementModelId1",
                table: "RequirementModel",
                column: "RequirementModelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RequirementModel_RequirementModelId",
                table: "AspNetUsers",
                column: "RequirementModelId",
                principalTable: "RequirementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_RequirementModel_RequirementModelId",
                table: "FileModel",
                column: "RequirementModelId",
                principalTable: "RequirementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_RequirementModel_RequirementModelId",
                table: "HistoryModel",
                column: "RequirementModelId",
                principalTable: "RequirementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RequirementModel_RequirementModelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_RequirementModel_RequirementModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_RequirementModel_RequirementModelId",
                table: "HistoryModel");

            migrationBuilder.DropTable(
                name: "RequirementModel");

            migrationBuilder.DropIndex(
                name: "IX_HistoryModel_RequirementModelId",
                table: "HistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_FileModel_RequirementModelId",
                table: "FileModel");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RequirementModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "HistoryModel");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "AspNetUsers");
        }
    }
}
