using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerUI.Migrations
{
    public partial class build_002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoteModelId",
                table: "Changes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectModelId",
                table: "Changes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "Changes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskModelId",
                table: "Changes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketModelId",
                table: "Changes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserModelId",
                table: "Changes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoteModelId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequirementModelId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamModelId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectName = table.Column<string>(type: "text", nullable: false),
                    CreatorModelId = table.Column<string>(type: "text", nullable: true),
                    CreatorModelId1 = table.Column<int>(type: "integer", nullable: true),
                    Summary = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TargetDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Creators_CreatorModelId1",
                        column: x => x.CreatorModelId1,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Team = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModelUserModel",
                columns: table => new
                {
                    ProjectModelsId = table.Column<int>(type: "integer", nullable: false),
                    UserModelsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModelUserModel", x => new { x.ProjectModelsId, x.UserModelsId });
                    table.ForeignKey(
                        name: "FK_ProjectModelUserModel_AspNetUsers_UserModelsId",
                        column: x => x.UserModelsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectModelUserModel_Projects_ProjectModelsId",
                        column: x => x.ProjectModelsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TargetDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", maxLength: 50, nullable: false),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requirements_Changes_HistoryModelId",
                        column: x => x.HistoryModelId,
                        principalTable: "Changes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requirements_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requirements_Projects_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "Projects",
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
                        name: "FK_ProjectModelTeamModel_Projects_ProjectModelsId",
                        column: x => x.ProjectModelsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectModelTeamModel_Teams_TeamModelsId",
                        column: x => x.TeamModelsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Changes_HistoryModelId",
                        column: x => x.HistoryModelId,
                        principalTable: "Changes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Requirements_RequirementModelId",
                        column: x => x.RequirementModelId,
                        principalTable: "Requirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskModelUserModel",
                columns: table => new
                {
                    TaskModelsId = table.Column<int>(type: "integer", nullable: false),
                    UserModelsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskModelUserModel", x => new { x.TaskModelsId, x.UserModelsId });
                    table.ForeignKey(
                        name: "FK_TaskModelUserModel_AspNetUsers_UserModelsId",
                        column: x => x.UserModelsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskModelUserModel_Tasks_TaskModelsId",
                        column: x => x.TaskModelsId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Changes_HistoryModelId",
                        column: x => x.HistoryModelId,
                        principalTable: "Changes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Tasks_TaskModelId",
                        column: x => x.TaskModelId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Changes_HistoryModelId",
                        column: x => x.HistoryModelId,
                        principalTable: "Changes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DateSent = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Message = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TicketId = table.Column<int>(type: "integer", nullable: false),
                    RecipientId = table.Column<string>(type: "text", nullable: false),
                    ReciptientId = table.Column<string>(type: "text", nullable: true),
                    SenderId = table.Column<string>(type: "text", nullable: false),
                    TeamModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_ReciptientId",
                        column: x => x.ReciptientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Teams_TeamModelId",
                        column: x => x.TeamModelId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
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
                        name: "FK_TicketModelUserModel_Tickets_TicketModelsId",
                        column: x => x.TicketModelsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    FileExtension = table.Column<string>(type: "text", nullable: true),
                    FileData = table.Column<byte[]>(type: "bytea", nullable: true),
                    DateUploaded = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserModelId = table.Column<string>(type: "text", nullable: true),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: false),
                    NoteModelId = table.Column<int>(type: "integer", nullable: true),
                    RequirementModelId = table.Column<int>(type: "integer", nullable: true),
                    TaskModelId = table.Column<int>(type: "integer", nullable: true),
                    TicketModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attachments_Notes_NoteModelId",
                        column: x => x.NoteModelId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Projects_ProjectModelId",
                        column: x => x.ProjectModelId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attachments_Requirements_RequirementModelId",
                        column: x => x.RequirementModelId,
                        principalTable: "Requirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Tasks_TaskModelId",
                        column: x => x.TaskModelId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Tickets_TicketModelId",
                        column: x => x.TicketModelId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Changes_NoteModelId",
                table: "Changes",
                column: "NoteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_ProjectModelId",
                table: "Changes",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_RequirementModelId",
                table: "Changes",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_TaskModelId",
                table: "Changes",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_TicketModelId",
                table: "Changes",
                column: "TicketModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_UserModelId",
                table: "Changes",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NoteModelId",
                table: "AspNetUsers",
                column: "NoteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RequirementModelId",
                table: "AspNetUsers",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamModelId",
                table: "AspNetUsers",
                column: "TeamModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_CreatorModelId",
                table: "Attachments",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_NoteModelId",
                table: "Attachments",
                column: "NoteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ProjectModelId",
                table: "Attachments",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_RequirementModelId",
                table: "Attachments",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_TaskModelId",
                table: "Attachments",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_TicketModelId",
                table: "Attachments",
                column: "TicketModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_UserModelId",
                table: "Attachments",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CreatorModelId",
                table: "Notes",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_HistoryModelId",
                table: "Notes",
                column: "HistoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TicketId",
                table: "Notes",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReciptientId",
                table: "Notifications",
                column: "ReciptientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SenderId",
                table: "Notifications",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TeamModelId",
                table: "Notifications",
                column: "TeamModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TicketId",
                table: "Notifications",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModelTeamModel_TeamModelsId",
                table: "ProjectModelTeamModel",
                column: "TeamModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModelUserModel_UserModelsId",
                table: "ProjectModelUserModel",
                column: "UserModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CreatorModelId1",
                table: "Projects",
                column: "CreatorModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_CreatorModelId",
                table: "Requirements",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_HistoryModelId",
                table: "Requirements",
                column: "HistoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_ProjectModelId",
                table: "Requirements",
                column: "ProjectModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskModelUserModel_UserModelsId",
                table: "TaskModelUserModel",
                column: "UserModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatorModelId",
                table: "Tasks",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_HistoryModelId",
                table: "Tasks",
                column: "HistoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RequirementModelId",
                table: "Tasks",
                column: "RequirementModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CreatorModelId",
                table: "Teams",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketModelUserModel_UserModelsId",
                table: "TicketModelUserModel",
                column: "UserModelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CreatorModelId",
                table: "Tickets",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_HistoryModelId",
                table: "Tickets",
                column: "HistoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TaskModelId",
                table: "Tickets",
                column: "TaskModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Notes_NoteModelId",
                table: "AspNetUsers",
                column: "NoteModelId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Requirements_RequirementModelId",
                table: "AspNetUsers",
                column: "RequirementModelId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_TeamModelId",
                table: "AspNetUsers",
                column: "TeamModelId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_AspNetUsers_UserModelId",
                table: "Changes",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Notes_NoteModelId",
                table: "Changes",
                column: "NoteModelId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Projects_ProjectModelId",
                table: "Changes",
                column: "ProjectModelId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Requirements_RequirementModelId",
                table: "Changes",
                column: "RequirementModelId",
                principalTable: "Requirements",
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
                name: "FK_Changes_Tickets_TicketModelId",
                table: "Changes",
                column: "TicketModelId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Notes_NoteModelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Requirements_RequirementModelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_TeamModelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_AspNetUsers_UserModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Notes_NoteModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Projects_ProjectModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Requirements_RequirementModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Tasks_TaskModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Tickets_TicketModelId",
                table: "Changes");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProjectModelTeamModel");

            migrationBuilder.DropTable(
                name: "ProjectModelUserModel");

            migrationBuilder.DropTable(
                name: "TaskModelUserModel");

            migrationBuilder.DropTable(
                name: "TicketModelUserModel");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Changes_NoteModelId",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_Changes_ProjectModelId",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_Changes_RequirementModelId",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_Changes_TaskModelId",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_Changes_TicketModelId",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_Changes_UserModelId",
                table: "Changes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NoteModelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RequirementModelId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NoteModelId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "ProjectModelId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "TaskModelId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "TicketModelId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Changes");

            migrationBuilder.DropColumn(
                name: "NoteModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RequirementModelId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamModelId",
                table: "AspNetUsers");
        }
    }
}
