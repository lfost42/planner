using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class RequirementModel_004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectModelId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProjectModelId",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "TicketName",
                table: "Tickets",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "Tickets",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketDescription",
                table: "Tickets",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "Tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "Notes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "Files",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "Changes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequirementName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ClosedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PriorityModelId = table.Column<int>(type: "integer", nullable: false),
                    StatusModelId = table.Column<int>(type: "integer", nullable: false),
                    Archived = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedUserlId = table.Column<string>(type: "text", nullable: false),
                    TeamModelId = table.Column<string>(type: "text", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: false),
                    TypeModelId = table.Column<int>(type: "integer", nullable: true),
                    AssignedUserId = table.Column<string>(type: "text", nullable: true),
                    TeamModelId1 = table.Column<int>(type: "integer", nullable: true),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirements_AspNetUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requirements_CreatorModel_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requirements_Files_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requirements_Priorities_PriorityModelId",
                        column: x => x.PriorityModelId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requirements_Projects_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requirements_Status_StatusModelId",
                        column: x => x.StatusModelId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requirements_Teams_TeamModelId1",
                        column: x => x.TeamModelId1,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requirements_Types_TypeModelId",
                        column: x => x.TypeModelId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RequirementModelId",
                table: "Tickets",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RequirementModelId",
                table: "Tasks",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_RequirementModelId",
                table: "Notes",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_RequirementModelId",
                table: "Files",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_RequirementModelId",
                table: "Changes",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_AssignedUserId",
                table: "Requirements",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_CreatorId",
                table: "Requirements",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_PhotoId",
                table: "Requirements",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_PriorityModelId",
                table: "Requirements",
                column: "PriorityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_ProjectModelId",
                table: "Requirements",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_StatusModelId",
                table: "Requirements",
                column: "StatusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_TeamModelId1",
                table: "Requirements",
                column: "TeamModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_TypeModelId",
                table: "Requirements",
                column: "TypeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Requirements_RequirementModelId",
                table: "Changes",
                column: "RequirementModelId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Requirements_RequirementModelId",
                table: "Files",
                column: "RequirementModelId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Requirements_RequirementModelId",
                table: "Notes",
                column: "RequirementModelId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Requirements_RequirementModelId",
                table: "Tasks",
                column: "RequirementModelId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Requirements_RequirementModelId",
                table: "Tickets",
                column: "RequirementModelId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Requirements_RequirementModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Requirements_RequirementModelId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Requirements_RequirementModelId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Requirements_RequirementModelId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Requirements_RequirementModelId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_RequirementModelId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_RequirementModelId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Notes_RequirementModelId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Files_RequirementModelId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Changes_RequirementModelId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketDescription",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "Changes");

            migrationBuilder.AlterColumn<string>(
                name: "TicketName",
                table: "Tickets",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "ProjectModelId",
                table: "Tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectModelId",
                table: "Tasks",
                column: "ProjectModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectModelId",
                table: "Tasks",
                column: "ProjectModelId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
