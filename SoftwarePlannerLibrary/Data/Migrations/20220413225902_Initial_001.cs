using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SoftwarePlannerLibrary.Data.Migrations
{
    public partial class Initial_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserModelId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creators_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RecipientId = table.Column<string>(type: "text", nullable: true),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false),
                    Read = table.Column<bool>(type: "boolean", nullable: false),
                    NoteId = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alerts_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
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
                    RequirementModelId = table.Column<int>(type: "integer", nullable: true),
                    TaskModelId = table.Column<int>(type: "integer", nullable: true),
                    TeamModelId = table.Column<int>(type: "integer", nullable: true),
                    UserModelId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Changes_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Changes_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    RequirementModelId = table.Column<int>(type: "integer", nullable: true),
                    TaskModelId = table.Column<int>(type: "integer", nullable: true),
                    TeamModelId = table.Column<int>(type: "integer", nullable: true),
                    TicketModelId = table.Column<int>(type: "integer", nullable: true),
                    UserModelId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    PhotoId = table.Column<int>(type: "integer", nullable: false),
                    ChangeModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Changes_ChangeModelId",
                        column: x => x.ChangeModelId,
                        principalTable: "Changes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Files_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Files",
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
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamName = table.Column<string>(type: "text", nullable: true),
                    CreatorModelId = table.Column<int>(type: "integer", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: false),
                    UserModelId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_AspNetUsers_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
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
                name: "ProjectModelUserModel",
                columns: table => new
                {
                    ProjectModelsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModelUserModel", x => new { x.ProjectModelsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProjectModelUserModel_AspNetUsers_UsersId",
                        column: x => x.UsersId,
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
                name: "ProjectModelTeamModel",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "integer", nullable: false),
                    TeamsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModelTeamModel", x => new { x.ProjectsId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_ProjectModelTeamModel_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectModelTeamModel_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_Requirements_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
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
                    PriorityModelId = table.Column<int>(type: "integer", nullable: false),
                    StatusModelId = table.Column<int>(type: "integer", nullable: false),
                    Archived = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedUserlId = table.Column<string>(type: "text", nullable: false),
                    TeamModelId = table.Column<string>(type: "text", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: false),
                    TypeModelId = table.Column<int>(type: "integer", nullable: true),
                    AssignedUserId = table.Column<string>(type: "text", nullable: true),
                    TeamModelId1 = table.Column<int>(type: "integer", nullable: true),
                    ProjectModelId = table.Column<int>(type: "integer", nullable: true),
                    RequirementModelId = table.Column<int>(type: "integer", nullable: true)
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
                        name: "FK_Tasks_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Requirements_RequirementModelId",
                        column: x => x.RequirementModelId,
                        principalTable: "Requirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    TicketName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TicketDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
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
                    AssignedUserId = table.Column<string>(type: "text", nullable: true),
                    RequirementModelId = table.Column<int>(type: "integer", nullable: true)
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
                        name: "FK_Tickets_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
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
                        name: "FK_Tickets_Requirements_RequirementModelId",
                        column: x => x.RequirementModelId,
                        principalTable: "Requirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    RequirementModelId = table.Column<int>(type: "integer", nullable: false),
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
                        name: "FK_Notes_Creators_CreatorModelId",
                        column: x => x.CreatorModelId,
                        principalTable: "Creators",
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
                        name: "FK_Notes_Requirements_RequirementModelId",
                        column: x => x.RequirementModelId,
                        principalTable: "Requirements",
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
                name: "IX_Alerts_CreatorModelId",
                table: "Alerts",
                column: "CreatorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_NoteId",
                table: "Alerts",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_RecipientId",
                table: "Alerts",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Changes_CreatorModelId",
                table: "Changes",
                column: "CreatorModelId");

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
                name: "IX_Changes_TeamModelId",
                table: "Changes",
                column: "TeamModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_TicketModelId",
                table: "Changes",
                column: "TicketModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Changes_UserModelId",
                table: "Changes",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Creators_UserModelId",
                table: "Creators",
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
                name: "IX_Files_RequirementModelId",
                table: "Files",
                column: "RequirementModelId");

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
                name: "IX_Files_UserModelId",
                table: "Files",
                column: "UserModelId");

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
                name: "IX_Notes_RequirementModelId",
                table: "Notes",
                column: "RequirementModelId");

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
                name: "IX_ProjectModelTeamModel_TeamsId",
                table: "ProjectModelTeamModel",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModelUserModel_UsersId",
                table: "ProjectModelUserModel",
                column: "UsersId");

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
                name: "IX_Tasks_RequirementModelId",
                table: "Tasks",
                column: "RequirementModelId");

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
                name: "IX_Teams_UserModelId",
                table: "Teams",
                column: "UserModelId");

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
                name: "IX_Tickets_RequirementModelId",
                table: "Tickets",
                column: "RequirementModelId");

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
                name: "FK_Alerts_Notes_NoteId",
                table: "Alerts",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Projects_ProjectModelId",
                table: "Changes",
                column: "ProjectModelId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Files_Projects_ProjectModelId",
                table: "Files",
                column: "ProjectModelId",
                principalTable: "Projects",
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
                name: "FK_Changes_AspNetUsers_UserModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Creators_AspNetUsers_UserModelId",
                table: "Creators");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_AspNetUsers_UserModelId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_AspNetUsers_AssignedUserId",
                table: "Requirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_AspNetUsers_AssignedUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_UserModelId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_AssignedUserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Creators_CreatorModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Creators_CreatorId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Creators_CreatorModelId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Creators_CreatorId",
                table: "Requirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Creators_CreatorId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Creators_CreatorModelId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Creators_CreatorModelId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Projects_ProjectModelId",
                table: "Changes");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Projects_ProjectModelId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Projects_ProjectModelId",
                table: "Requirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectModelId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_ProjectModelId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Requirements_RequirementModelId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Requirements_RequirementModelId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Requirements_RequirementModelId",
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
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProjectModelTeamModel");

            migrationBuilder.DropTable(
                name: "ProjectModelUserModel");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Creators");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Changes");

            migrationBuilder.DropTable(
                name: "Requirements");

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
        }
    }
}
