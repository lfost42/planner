using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class Ticket_008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "NotificationModel",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketModelId",
                table: "HistoryModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketModelId",
                table: "FileModel",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TicketType = table.Column<int>(type: "integer", nullable: false),
                    TaskModelId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_TicketModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketModel_CreatorModel_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketModel_HistoryModel_HistoryModelId",
                        column: x => x.HistoryModelId,
                        principalTable: "HistoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketModel_TaskModel_TaskModelId",
                        column: x => x.TaskModelId,
                        principalTable: "TaskModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketModelUserModel",
                columns: table => new
                {
                    TicketModelsId = table.Column<int>(type: "integer", nullable: false),
                    UserModelsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketModelUserModel", x => new { x.TicketModelsId, x.UserModelsId });
                    table.ForeignKey(
                        name: "FK_TicketModelUserModel_AspNetUsers_UserModelsId",
                        column: x => x.UserModelsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketModelUserModel_TicketModel_TicketModelsId",
                        column: x => x.TicketModelsId,
                        principalTable: "TicketModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationModel_TicketId",
                table: "NotificationModel",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryModel_TicketModelId",
                table: "HistoryModel",
                column: "TicketModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_TicketModelId",
                table: "FileModel",
                column: "TicketModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketModel_CreatorModelId",
                table: "TicketModel",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketModel_HistoryModelId",
                table: "TicketModel",
                column: "HistoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketModel_TaskModelId",
                table: "TicketModel",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketModelUserModel_UserModelsId",
                table: "TicketModelUserModel",
                column: "UserModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_TicketModel_TicketModelId",
                table: "FileModel",
                column: "TicketModelId",
                principalTable: "TicketModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_TicketModel_TicketModelId",
                table: "HistoryModel",
                column: "TicketModelId",
                principalTable: "TicketModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationModel_TicketModel_TicketId",
                table: "NotificationModel",
                column: "TicketId",
                principalTable: "TicketModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_TicketModel_TicketModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_TicketModel_TicketModelId",
                table: "HistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationModel_TicketModel_TicketId",
                table: "NotificationModel");

            migrationBuilder.DropTable(
                name: "TicketModelUserModel");

            migrationBuilder.DropTable(
                name: "TicketModel");

            migrationBuilder.DropIndex(
                name: "IX_NotificationModel_TicketId",
                table: "NotificationModel");

            migrationBuilder.DropIndex(
                name: "IX_HistoryModel_TicketModelId",
                table: "HistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_FileModel_TicketModelId",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "NotificationModel");

            migrationBuilder.DropColumn(
                name: "TicketModelId",
                table: "HistoryModel");

            migrationBuilder.DropColumn(
                name: "TicketModelId",
                table: "FileModel");
        }
    }
}
