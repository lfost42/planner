using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class Notes_009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoteModelId",
                table: "HistoryModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoteModelId",
                table: "FileModel",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoteModelId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NoteModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TicketId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_NoteModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteModel_CreatorModel_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteModel_HistoryModel_HistoryModelId",
                        column: x => x.HistoryModelId,
                        principalTable: "HistoryModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteModel_TicketModel_TicketId",
                        column: x => x.TicketId,
                        principalTable: "TicketModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryModel_NoteModelId",
                table: "HistoryModel",
                column: "NoteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_NoteModelId",
                table: "FileModel",
                column: "NoteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NoteModelId",
                table: "AspNetUsers",
                column: "NoteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteModel_CreatorModelId",
                table: "NoteModel",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteModel_HistoryModelId",
                table: "NoteModel",
                column: "HistoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteModel_TicketId",
                table: "NoteModel",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_NoteModel_NoteModelId",
                table: "AspNetUsers",
                column: "NoteModelId",
                principalTable: "NoteModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_NoteModel_NoteModelId",
                table: "FileModel",
                column: "NoteModelId",
                principalTable: "NoteModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_NoteModel_NoteModelId",
                table: "HistoryModel",
                column: "NoteModelId",
                principalTable: "NoteModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_NoteModel_NoteModelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_NoteModel_NoteModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_NoteModel_NoteModelId",
                table: "HistoryModel");

            migrationBuilder.DropTable(
                name: "NoteModel");

            migrationBuilder.DropIndex(
                name: "IX_HistoryModel_NoteModelId",
                table: "HistoryModel");

            migrationBuilder.DropIndex(
                name: "IX_FileModel_NoteModelId",
                table: "FileModel");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NoteModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NoteModelId",
                table: "HistoryModel");

            migrationBuilder.DropColumn(
                name: "NoteModelId",
                table: "FileModel");

            migrationBuilder.DropColumn(
                name: "NoteModelId",
                table: "AspNetUsers");
        }
    }
}
