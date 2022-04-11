using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class DbSets_002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "AspNetUsers",
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
                name: "Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PriorityLevel = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ClosedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PriorityModelId = table.Column<int>(type: "integer", nullable: false),
                    StatusModelId = table.Column<int>(type: "integer", nullable: false),
                    Archived = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedUserlId = table.Column<string>(type: "text", nullable: false),
                    TeamModelId = table.Column<string>(type: "text", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: false),
                    AssignedUserId = table.Column<string>(type: "text", nullable: true),
                    TeamModelId1 = table.Column<int>(type: "integer", nullable: true),
                    ChangeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_CreatorModel_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Priorities_PriorityModelId",
                        column: x => x.PriorityModelId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Status_StatusModelId",
                        column: x => x.StatusModelId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Changes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketModelId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedItem = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PreviousValue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CurrentValue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: true),
                    TaskModelId = table.Column<int>(type: "integer", nullable: true),
                    TeamModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Changes_CreatorModel_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Changes_Projects_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UploadDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FileExtension = table.Column<string>(type: "text", nullable: true),
                    FileData = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatorId = table.Column<int>(type: "integer", nullable: false),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: true),
                    TaskModelId = table.Column<int>(type: "integer", nullable: true),
                    TeamModelId = table.Column<int>(type: "integer", nullable: true),
                    TicketModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_CreatorModel_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Projects_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamName = table.Column<string>(type: "text", nullable: true),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_CreatorModel_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Files_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ClosedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: false),
                    PriorityModelId = table.Column<int>(type: "integer", nullable: false),
                    StatusModelId = table.Column<int>(type: "integer", nullable: false),
                    Archived = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedUserlId = table.Column<string>(type: "text", nullable: false),
                    TeamModelId = table.Column<string>(type: "text", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: false),
                    TypeModelId = table.Column<int>(type: "integer", nullable: true),
                    AssignedUserId = table.Column<string>(type: "text", nullable: true),
                    TeamModelId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_CreatorModel_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Files_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Priorities_PriorityModelId",
                        column: x => x.PriorityModelId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Status_StatusModelId",
                        column: x => x.StatusModelId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Teams_TeamModelId1",
                        column: x => x.TeamModelId1,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Types_TypeModelId",
                        column: x => x.TypeModelId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ClosedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: false),
                    TaskModelId = table.Column<int>(type: "integer", nullable: false),
                    TypeModelId = table.Column<int>(type: "integer", nullable: false),
                    PriorityModelId = table.Column<int>(type: "integer", nullable: false),
                    StatusModelId = table.Column<int>(type: "integer", nullable: false),
                    Archived = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedUserlId = table.Column<string>(type: "text", nullable: false),
                    TeamModelId = table.Column<int>(type: "integer", nullable: false),
                    AssignedUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_CreatorModel_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Priorities_PriorityModelId",
                        column: x => x.PriorityModelId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Projects_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Status_StatusModelId",
                        column: x => x.StatusModelId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Tasks_TaskModelId",
                        column: x => x.TaskModelId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Teams_TeamModelId",
                        column: x => x.TeamModelId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Types_TypeModelId",
                        column: x => x.TypeModelId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: false),
                    TaskModelId = table.Column<int>(type: "integer", nullable: false),
                    TicketModelId = table.Column<int>(type: "integer", nullable: false),
                    TypeModelId = table.Column<int>(type: "integer", nullable: false),
                    PriorityModelId = table.Column<int>(type: "integer", nullable: false),
                    StatusModelId = table.Column<int>(type: "integer", nullable: false),
                    Archived = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedUserlId = table.Column<string>(type: "text", nullable: false),
                    TeamModelId = table.Column<string>(type: "text", nullable: false),
                    AssignedUserId = table.Column<string>(type: "text", nullable: true),
                    TeamModelId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_AspNetUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_CreatorModel_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "CreatorModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Priorities_PriorityModelId",
                        column: x => x.PriorityModelId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Projects_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Status_StatusModelId",
                        column: x => x.StatusModelId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Tasks_TaskModelId",
                        column: x => x.TaskModelId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Teams_TeamModelId1",
                        column: x => x.TeamModelId1,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_Tickets_TicketModelId",
                        column: x => x.TicketModelId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Types_TypeModelId",
                        column: x => x.TypeModelId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhotoId",
                table: "AspNetUsers",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_CreatorModelId",
                table: "Changes",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_ProjectModelId",
                table: "Changes",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_TaskModelId",
                table: "Changes",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_TeamModelId",
                table: "Changes",
                column: "TeamModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_TicketModelId",
                table: "Changes",
                column: "TicketModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorModel_UserModelId",
                table: "CreatorModel",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CreatorId",
                table: "Files",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ProjectModelId",
                table: "Files",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_TaskModelId",
                table: "Files",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_TeamModelId",
                table: "Files",
                column: "TeamModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_TicketModelId",
                table: "Files",
                column: "TicketModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_AssignedUserId",
                table: "Notes",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CreatorModelId",
                table: "Notes",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PriorityModelId",
                table: "Notes",
                column: "PriorityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ProjectModelId",
                table: "Notes",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_StatusModelId",
                table: "Notes",
                column: "StatusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TaskModelId",
                table: "Notes",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TeamModelId1",
                table: "Notes",
                column: "TeamModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TicketModelId",
                table: "Notes",
                column: "TicketModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TypeModelId",
                table: "Notes",
                column: "TypeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AssignedUserId",
                table: "Projects",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ChangeModelId",
                table: "Projects",
                column: "ChangeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatorModelId",
                table: "Projects",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PhotoId",
                table: "Projects",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PriorityModelId",
                table: "Projects",
                column: "PriorityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusModelId",
                table: "Projects",
                column: "StatusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamModelId1",
                table: "Projects",
                column: "TeamModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedUserId",
                table: "Tasks",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatorId",
                table: "Tasks",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PhotoId",
                table: "Tasks",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PriorityModelId",
                table: "Tasks",
                column: "PriorityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectModelId",
                table: "Tasks",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusModelId",
                table: "Tasks",
                column: "StatusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TeamModelId1",
                table: "Tasks",
                column: "TeamModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TypeModelId",
                table: "Tasks",
                column: "TypeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CreatorModelId",
                table: "Teams",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PhotoId",
                table: "Teams",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssignedUserId",
                table: "Tickets",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatorModelId",
                table: "Tickets",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PriorityModelId",
                table: "Tickets",
                column: "PriorityModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectModelId",
                table: "Tickets",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StatusModelId",
                table: "Tickets",
                column: "StatusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TaskModelId",
                table: "Tickets",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TeamModelId",
                table: "Tickets",
                column: "TeamModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TypeModelId",
                table: "Tickets",
                column: "TypeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Files_PhotoId",
                table: "AspNetUsers",
                column: "PhotoId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Changes_ChangeModelId",
                table: "Projects",
                column: "ChangeModelId",
                principalTable: "Changes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Files_PhotoId",
                table: "Projects",
                column: "PhotoId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Teams_TeamModelId1",
                table: "Projects",
                column: "TeamModelId1",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Tasks_TaskModelId",
                table: "Changes",
                column: "TaskModelId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Teams_TeamModelId",
                table: "Changes",
                column: "TeamModelId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Tickets_TicketModelId",
                table: "Changes",
                column: "TicketModelId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Tasks_TaskModelId",
                table: "Files",
                column: "TaskModelId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Teams_TeamModelId",
                table: "Files",
                column: "TeamModelId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Tickets_TicketModelId",
                table: "Files",
                column: "TicketModelId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Files_PhotoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_CreatorModel_CreatorModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_CreatorModel_CreatorId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_CreatorModel_CreatorModelId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_CreatorModel_CreatorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_CreatorModel_CreatorModelId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_CreatorModel_CreatorModelId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Projects_ProjectModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Projects_ProjectModelId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectModelId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_ProjectModelId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Tasks_TaskModelId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tasks_TaskModelId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Teams_TeamModelId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Teams_TeamModelId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "CreatorModel");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Changes");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PhotoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
