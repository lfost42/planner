using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class Notifications_005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_AspNetUsers_UserModelId",
                table: "HistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_HistoryModel_UserModelId",
                table: "HistoryModel");

            migrationBuilder.RenameColumn(
                name: "UserModelId",
                table: "HistoryModel",
                newName: "CreatorModelId");

            migrationBuilder.AddColumn<int>(
                name: "CreatorModelId",
                table: "TeamModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatorModelId",
                table: "ProjectModel",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorModelId1",
                table: "ProjectModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorModelId1",
                table: "HistoryModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorModelId",
                table: "FileModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreatorModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserModelId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatorModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreatorModel_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    DateSent = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    RecipientId = table.Column<string>(type: "text", nullable: false),
                    ReciptientId = table.Column<string>(type: "text", nullable: true),
                    SenderId = table.Column<string>(type: "text", nullable: false),
                    TeamModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationModel_AspNetUsers_ReciptientId",
                        column: x => x.ReciptientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationModel_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationModel_TeamModel_TeamModelId",
                        column: x => x.TeamModelId,
                        principalTable: "TeamModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamModel_CreatorModelId",
                table: "TeamModel",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModel_CreatorModelId1",
                table: "ProjectModel",
                column: "CreatorModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryModel_CreatorModelId1",
                table: "HistoryModel",
                column: "CreatorModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_CreatorModelId",
                table: "FileModel",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorModel_UserModelId",
                table: "CreatorModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationModel_ReciptientId",
                table: "NotificationModel",
                column: "ReciptientId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationModel_SenderId",
                table: "NotificationModel",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationModel_TeamModelId",
                table: "NotificationModel",
                column: "TeamModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_CreatorModel_CreatorModelId",
                table: "FileModel",
                column: "CreatorModelId",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_CreatorModel_CreatorModelId1",
                table: "HistoryModel",
                column: "CreatorModelId1",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModel_CreatorModel_CreatorModelId1",
                table: "ProjectModel",
                column: "CreatorModelId1",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamModel_CreatorModel_CreatorModelId",
                table: "TeamModel",
                column: "CreatorModelId",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_CreatorModel_CreatorModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_CreatorModel_CreatorModelId1",
                table: "HistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModel_CreatorModel_CreatorModelId1",
                table: "ProjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamModel_CreatorModel_CreatorModelId",
                table: "TeamModel");

            migrationBuilder.DropTable(
                name: "CreatorModel");

            migrationBuilder.DropTable(
                name: "NotificationModel");

            migrationBuilder.DropIndex(
                name: "IX_TeamModel_CreatorModelId",
                table: "TeamModel");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModel_CreatorModelId1",
                table: "ProjectModel");

            migrationBuilder.DropIndex(
                name: "IX_HistoryModel_CreatorModelId1",
                table: "HistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_FileModel_CreatorModelId",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "CreatorModelId",
                table: "TeamModel");

            migrationBuilder.DropColumn(
                name: "CreatorModelId",
                table: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "CreatorModelId1",
                table: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "CreatorModelId1",
                table: "HistoryModel");

            migrationBuilder.DropColumn(
                name: "CreatorModelId",
                table: "FileModel");

            migrationBuilder.RenameColumn(
                name: "CreatorModelId",
                table: "HistoryModel",
                newName: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryModel_UserModelId",
                table: "HistoryModel",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_AspNetUsers_UserModelId",
                table: "HistoryModel",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
