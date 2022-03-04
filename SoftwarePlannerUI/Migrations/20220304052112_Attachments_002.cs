using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Migrations
{
    public partial class Attachments_002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    UserModelId = table.Column<string>(type: "text", nullable: true)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileModel_UserModelId",
                table: "FileModel",
                column: "UserModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileModel");
        }
    }
}
