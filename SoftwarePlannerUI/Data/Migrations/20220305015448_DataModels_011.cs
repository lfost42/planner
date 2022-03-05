using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class DataModels_011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_NoteModel_NoteModelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RequirementModel_RequirementModelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TeamModel_TeamModelId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CreatorModel_AspNetUsers_UserModelId",
                table: "CreatorModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_AspNetUsers_UserModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_CreatorModel_CreatorModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_NoteModel_NoteModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_ProjectModel_ProjectModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_RequirementModel_RequirementModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_TaskModel_TaskModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FileModel_TicketModel_TicketModelId",
                table: "FileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_CreatorModel_CreatorModelId1",
                table: "HistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_NoteModel_NoteModelId",
                table: "HistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_ProjectModel_ProjectModelId",
                table: "HistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_RequirementModel_RequirementModelId",
                table: "HistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_TaskModel_TaskModelId",
                table: "HistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryModel_TicketModel_TicketModelId",
                table: "HistoryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteModel_CreatorModel_CreatorModelId",
                table: "NoteModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteModel_HistoryModel_HistoryModelId",
                table: "NoteModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteModel_TicketModel_TicketId",
                table: "NoteModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationModel_AspNetUsers_ReciptientId",
                table: "NotificationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationModel_AspNetUsers_SenderId",
                table: "NotificationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationModel_TeamModel_TeamModelId",
                table: "NotificationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationModel_TicketModel_TicketId",
                table: "NotificationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModel_CreatorModel_CreatorModelId1",
                table: "ProjectModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelTeamModel_ProjectModel_ProjectModelsId",
                table: "ProjectModelTeamModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelTeamModel_TeamModel_TeamModelsId",
                table: "ProjectModelTeamModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelUserModel_ProjectModel_ProjectModelsId",
                table: "ProjectModelUserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementModel_CreatorModel_CreatorModelId",
                table: "RequirementModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementModel_HistoryModel_HistoryModelId",
                table: "RequirementModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RequirementModel_ProjectModel_ProjectModelId",
                table: "RequirementModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskModel_CreatorModel_CreatorModelId",
                table: "TaskModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskModel_HistoryModel_HistoryModelId",
                table: "TaskModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskModel_RequirementModel_RequirementModelId",
                table: "TaskModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskModelUserModel_TaskModel_TaskModelsId",
                table: "TaskModelUserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamModel_CreatorModel_CreatorModelId",
                table: "TeamModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketModel_CreatorModel_CreatorModelId",
                table: "TicketModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketModel_HistoryModel_HistoryModelId",
                table: "TicketModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketModel_TaskModel_TaskModelId",
                table: "TicketModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketModelUserModel_TicketModel_TicketModelsId",
                table: "TicketModelUserModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketModel",
                table: "TicketModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamModel",
                table: "TeamModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskModel",
                table: "TaskModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequirementModel",
                table: "RequirementModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectModel",
                table: "ProjectModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationModel",
                table: "NotificationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteModel",
                table: "NoteModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryModel",
                table: "HistoryModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileModel",
                table: "FileModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatorModel",
                table: "CreatorModel");

            migrationBuilder.RenameTable(
                name: "TicketModel",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "TeamModel",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "TaskModel",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "RequirementModel",
                newName: "Requirements");

            migrationBuilder.RenameTable(
                name: "ProjectModel",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "NotificationModel",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "NoteModel",
                newName: "Notes");

            migrationBuilder.RenameTable(
                name: "HistoryModel",
                newName: "Changes");

            migrationBuilder.RenameTable(
                name: "FileModel",
                newName: "Attachments");

            migrationBuilder.RenameTable(
                name: "CreatorModel",
                newName: "Creators");

            migrationBuilder.RenameIndex(
                name: "IX_TicketModel_TaskModelId",
                table: "Tickets",
                newName: "IX_Tickets_TaskModelId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketModel_HistoryModelId",
                table: "Tickets",
                newName: "IX_Tickets_HistoryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketModel_CreatorModelId",
                table: "Tickets",
                newName: "IX_Tickets_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamModel_CreatorModelId",
                table: "Teams",
                newName: "IX_Teams_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskModel_RequirementModelId",
                table: "Tasks",
                newName: "IX_Tasks_RequirementModelId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskModel_HistoryModelId",
                table: "Tasks",
                newName: "IX_Tasks_HistoryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskModel_CreatorModelId",
                table: "Tasks",
                newName: "IX_Tasks_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_RequirementModel_ProjectModelId",
                table: "Requirements",
                newName: "IX_Requirements_ProjectModelId");

            migrationBuilder.RenameIndex(
                name: "IX_RequirementModel_HistoryModelId",
                table: "Requirements",
                newName: "IX_Requirements_HistoryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_RequirementModel_CreatorModelId",
                table: "Requirements",
                newName: "IX_Requirements_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModel_CreatorModelId1",
                table: "Projects",
                newName: "IX_Projects_CreatorModelId1");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationModel_TicketId",
                table: "Notifications",
                newName: "IX_Notifications_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationModel_TeamModelId",
                table: "Notifications",
                newName: "IX_Notifications_TeamModelId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationModel_SenderId",
                table: "Notifications",
                newName: "IX_Notifications_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationModel_ReciptientId",
                table: "Notifications",
                newName: "IX_Notifications_ReciptientId");

            migrationBuilder.RenameIndex(
                name: "IX_NoteModel_TicketId",
                table: "Notes",
                newName: "IX_Notes_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_NoteModel_HistoryModelId",
                table: "Notes",
                newName: "IX_Notes_HistoryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_NoteModel_CreatorModelId",
                table: "Notes",
                newName: "IX_Notes_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryModel_TicketModelId",
                table: "Changes",
                newName: "IX_Changes_TicketModelId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryModel_TaskModelId",
                table: "Changes",
                newName: "IX_Changes_TaskModelId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryModel_RequirementModelId",
                table: "Changes",
                newName: "IX_Changes_RequirementModelId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryModel_ProjectModelId",
                table: "Changes",
                newName: "IX_Changes_ProjectModelId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryModel_NoteModelId",
                table: "Changes",
                newName: "IX_Changes_NoteModelId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryModel_CreatorModelId1",
                table: "Changes",
                newName: "IX_Changes_CreatorModelId1");

            migrationBuilder.RenameIndex(
                name: "IX_FileModel_UserModelId",
                table: "Attachments",
                newName: "IX_Attachments_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_FileModel_TicketModelId",
                table: "Attachments",
                newName: "IX_Attachments_TicketModelId");

            migrationBuilder.RenameIndex(
                name: "IX_FileModel_TaskModelId",
                table: "Attachments",
                newName: "IX_Attachments_TaskModelId");

            migrationBuilder.RenameIndex(
                name: "IX_FileModel_RequirementModelId",
                table: "Attachments",
                newName: "IX_Attachments_RequirementModelId");

            migrationBuilder.RenameIndex(
                name: "IX_FileModel_ProjectModelId",
                table: "Attachments",
                newName: "IX_Attachments_ProjectModelId");

            migrationBuilder.RenameIndex(
                name: "IX_FileModel_NoteModelId",
                table: "Attachments",
                newName: "IX_Attachments_NoteModelId");

            migrationBuilder.RenameIndex(
                name: "IX_FileModel_CreatorModelId",
                table: "Attachments",
                newName: "IX_Attachments_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_CreatorModel_UserModelId",
                table: "Creators",
                newName: "IX_Creators_UserModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requirements",
                table: "Requirements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Changes",
                table: "Changes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Creators",
                table: "Creators",
                column: "Id");

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
                name: "FK_Attachments_AspNetUsers_UserModelId",
                table: "Attachments",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Creators_CreatorModelId",
                table: "Attachments",
                column: "CreatorModelId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Notes_NoteModelId",
                table: "Attachments",
                column: "NoteModelId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Projects_ProjectModelId",
                table: "Attachments",
                column: "ProjectModelId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Requirements_RequirementModelId",
                table: "Attachments",
                column: "RequirementModelId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Tasks_TaskModelId",
                table: "Attachments",
                column: "TaskModelId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Tickets_TicketModelId",
                table: "Attachments",
                column: "TicketModelId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Changes_Creators_CreatorModelId1",
                table: "Changes",
                column: "CreatorModelId1",
                principalTable: "Creators",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Creators_AspNetUsers_UserModelId",
                table: "Creators",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Changes_HistoryModelId",
                table: "Notes",
                column: "HistoryModelId",
                principalTable: "Changes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Creators_CreatorModelId",
                table: "Notes",
                column: "CreatorModelId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Tickets_TicketId",
                table: "Notes",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_ReciptientId",
                table: "Notifications",
                column: "ReciptientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_AspNetUsers_SenderId",
                table: "Notifications",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Teams_TeamModelId",
                table: "Notifications",
                column: "TeamModelId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Tickets_TicketId",
                table: "Notifications",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelTeamModel_Projects_ProjectModelsId",
                table: "ProjectModelTeamModel",
                column: "ProjectModelsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelTeamModel_Teams_TeamModelsId",
                table: "ProjectModelTeamModel",
                column: "TeamModelsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelUserModel_Projects_ProjectModelsId",
                table: "ProjectModelUserModel",
                column: "ProjectModelsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Creators_CreatorModelId1",
                table: "Projects",
                column: "CreatorModelId1",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Changes_HistoryModelId",
                table: "Requirements",
                column: "HistoryModelId",
                principalTable: "Changes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Creators_CreatorModelId",
                table: "Requirements",
                column: "CreatorModelId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Projects_ProjectModelId",
                table: "Requirements",
                column: "ProjectModelId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModelUserModel_Tasks_TaskModelsId",
                table: "TaskModelUserModel",
                column: "TaskModelsId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Changes_HistoryModelId",
                table: "Tasks",
                column: "HistoryModelId",
                principalTable: "Changes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Creators_CreatorModelId",
                table: "Tasks",
                column: "CreatorModelId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Requirements_RequirementModelId",
                table: "Tasks",
                column: "RequirementModelId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Creators_CreatorModelId",
                table: "Teams",
                column: "CreatorModelId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketModelUserModel_Tickets_TicketModelsId",
                table: "TicketModelUserModel",
                column: "TicketModelsId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Changes_HistoryModelId",
                table: "Tickets",
                column: "HistoryModelId",
                principalTable: "Changes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Creators_CreatorModelId",
                table: "Tickets",
                column: "CreatorModelId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tasks_TaskModelId",
                table: "Tickets",
                column: "TaskModelId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_Attachments_AspNetUsers_UserModelId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Creators_CreatorModelId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Notes_NoteModelId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Projects_ProjectModelId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Requirements_RequirementModelId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Tasks_TaskModelId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Tickets_TicketModelId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Changes_Creators_CreatorModelId1",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Creators_AspNetUsers_UserModelId",
                table: "Creators");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Changes_HistoryModelId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Creators_CreatorModelId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Tickets_TicketId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_ReciptientId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_AspNetUsers_SenderId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Teams_TeamModelId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Tickets_TicketId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelTeamModel_Projects_ProjectModelsId",
                table: "ProjectModelTeamModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelTeamModel_Teams_TeamModelsId",
                table: "ProjectModelTeamModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelUserModel_Projects_ProjectModelsId",
                table: "ProjectModelUserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Creators_CreatorModelId1",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Changes_HistoryModelId",
                table: "Requirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Creators_CreatorModelId",
                table: "Requirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Projects_ProjectModelId",
                table: "Requirements");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskModelUserModel_Tasks_TaskModelsId",
                table: "TaskModelUserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Changes_HistoryModelId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Creators_CreatorModelId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Requirements_RequirementModelId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Creators_CreatorModelId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketModelUserModel_Tickets_TicketModelsId",
                table: "TicketModelUserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Changes_HistoryModelId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Creators_CreatorModelId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tasks_TaskModelId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requirements",
                table: "Requirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Creators",
                table: "Creators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Changes",
                table: "Changes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "TicketModel");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "TeamModel");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "TaskModel");

            migrationBuilder.RenameTable(
                name: "Requirements",
                newName: "RequirementModel");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "ProjectModel");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "NotificationModel");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "NoteModel");

            migrationBuilder.RenameTable(
                name: "Creators",
                newName: "CreatorModel");

            migrationBuilder.RenameTable(
                name: "Changes",
                newName: "HistoryModel");

            migrationBuilder.RenameTable(
                name: "Attachments",
                newName: "FileModel");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TaskModelId",
                table: "TicketModel",
                newName: "IX_TicketModel_TaskModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_HistoryModelId",
                table: "TicketModel",
                newName: "IX_TicketModel_HistoryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_CreatorModelId",
                table: "TicketModel",
                newName: "IX_TicketModel_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_CreatorModelId",
                table: "TeamModel",
                newName: "IX_TeamModel_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_RequirementModelId",
                table: "TaskModel",
                newName: "IX_TaskModel_RequirementModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_HistoryModelId",
                table: "TaskModel",
                newName: "IX_TaskModel_HistoryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_CreatorModelId",
                table: "TaskModel",
                newName: "IX_TaskModel_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Requirements_ProjectModelId",
                table: "RequirementModel",
                newName: "IX_RequirementModel_ProjectModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Requirements_HistoryModelId",
                table: "RequirementModel",
                newName: "IX_RequirementModel_HistoryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Requirements_CreatorModelId",
                table: "RequirementModel",
                newName: "IX_RequirementModel_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_CreatorModelId1",
                table: "ProjectModel",
                newName: "IX_ProjectModel_CreatorModelId1");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_TicketId",
                table: "NotificationModel",
                newName: "IX_NotificationModel_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_TeamModelId",
                table: "NotificationModel",
                newName: "IX_NotificationModel_TeamModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_SenderId",
                table: "NotificationModel",
                newName: "IX_NotificationModel_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_ReciptientId",
                table: "NotificationModel",
                newName: "IX_NotificationModel_ReciptientId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_TicketId",
                table: "NoteModel",
                newName: "IX_NoteModel_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_HistoryModelId",
                table: "NoteModel",
                newName: "IX_NoteModel_HistoryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_CreatorModelId",
                table: "NoteModel",
                newName: "IX_NoteModel_CreatorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Creators_UserModelId",
                table: "CreatorModel",
                newName: "IX_CreatorModel_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Changes_TicketModelId",
                table: "HistoryModel",
                newName: "IX_HistoryModel_TicketModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Changes_TaskModelId",
                table: "HistoryModel",
                newName: "IX_HistoryModel_TaskModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Changes_RequirementModelId",
                table: "HistoryModel",
                newName: "IX_HistoryModel_RequirementModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Changes_ProjectModelId",
                table: "HistoryModel",
                newName: "IX_HistoryModel_ProjectModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Changes_NoteModelId",
                table: "HistoryModel",
                newName: "IX_HistoryModel_NoteModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Changes_CreatorModelId1",
                table: "HistoryModel",
                newName: "IX_HistoryModel_CreatorModelId1");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_UserModelId",
                table: "FileModel",
                newName: "IX_FileModel_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_TicketModelId",
                table: "FileModel",
                newName: "IX_FileModel_TicketModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_TaskModelId",
                table: "FileModel",
                newName: "IX_FileModel_TaskModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_RequirementModelId",
                table: "FileModel",
                newName: "IX_FileModel_RequirementModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_ProjectModelId",
                table: "FileModel",
                newName: "IX_FileModel_ProjectModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_NoteModelId",
                table: "FileModel",
                newName: "IX_FileModel_NoteModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Attachments_CreatorModelId",
                table: "FileModel",
                newName: "IX_FileModel_CreatorModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketModel",
                table: "TicketModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamModel",
                table: "TeamModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskModel",
                table: "TaskModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequirementModel",
                table: "RequirementModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectModel",
                table: "ProjectModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationModel",
                table: "NotificationModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteModel",
                table: "NoteModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatorModel",
                table: "CreatorModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryModel",
                table: "HistoryModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileModel",
                table: "FileModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_NoteModel_NoteModelId",
                table: "AspNetUsers",
                column: "NoteModelId",
                principalTable: "NoteModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RequirementModel_RequirementModelId",
                table: "AspNetUsers",
                column: "RequirementModelId",
                principalTable: "RequirementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TeamModel_TeamModelId",
                table: "AspNetUsers",
                column: "TeamModelId",
                principalTable: "TeamModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatorModel_AspNetUsers_UserModelId",
                table: "CreatorModel",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_AspNetUsers_UserModelId",
                table: "FileModel",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_CreatorModel_CreatorModelId",
                table: "FileModel",
                column: "CreatorModelId",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_NoteModel_NoteModelId",
                table: "FileModel",
                column: "NoteModelId",
                principalTable: "NoteModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_ProjectModel_ProjectModelId",
                table: "FileModel",
                column: "ProjectModelId",
                principalTable: "ProjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_RequirementModel_RequirementModelId",
                table: "FileModel",
                column: "RequirementModelId",
                principalTable: "RequirementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_TaskModel_TaskModelId",
                table: "FileModel",
                column: "TaskModelId",
                principalTable: "TaskModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileModel_TicketModel_TicketModelId",
                table: "FileModel",
                column: "TicketModelId",
                principalTable: "TicketModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_CreatorModel_CreatorModelId1",
                table: "HistoryModel",
                column: "CreatorModelId1",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_NoteModel_NoteModelId",
                table: "HistoryModel",
                column: "NoteModelId",
                principalTable: "NoteModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_ProjectModel_ProjectModelId",
                table: "HistoryModel",
                column: "ProjectModelId",
                principalTable: "ProjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_RequirementModel_RequirementModelId",
                table: "HistoryModel",
                column: "RequirementModelId",
                principalTable: "RequirementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryModel_TaskModel_TaskModelId",
                table: "HistoryModel",
                column: "TaskModelId",
                principalTable: "TaskModel",
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
                name: "FK_NoteModel_CreatorModel_CreatorModelId",
                table: "NoteModel",
                column: "CreatorModelId",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteModel_HistoryModel_HistoryModelId",
                table: "NoteModel",
                column: "HistoryModelId",
                principalTable: "HistoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteModel_TicketModel_TicketId",
                table: "NoteModel",
                column: "TicketId",
                principalTable: "TicketModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationModel_AspNetUsers_ReciptientId",
                table: "NotificationModel",
                column: "ReciptientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationModel_AspNetUsers_SenderId",
                table: "NotificationModel",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationModel_TeamModel_TeamModelId",
                table: "NotificationModel",
                column: "TeamModelId",
                principalTable: "TeamModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationModel_TicketModel_TicketId",
                table: "NotificationModel",
                column: "TicketId",
                principalTable: "TicketModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModel_CreatorModel_CreatorModelId1",
                table: "ProjectModel",
                column: "CreatorModelId1",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelTeamModel_ProjectModel_ProjectModelsId",
                table: "ProjectModelTeamModel",
                column: "ProjectModelsId",
                principalTable: "ProjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelTeamModel_TeamModel_TeamModelsId",
                table: "ProjectModelTeamModel",
                column: "TeamModelsId",
                principalTable: "TeamModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelUserModel_ProjectModel_ProjectModelsId",
                table: "ProjectModelUserModel",
                column: "ProjectModelsId",
                principalTable: "ProjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementModel_CreatorModel_CreatorModelId",
                table: "RequirementModel",
                column: "CreatorModelId",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementModel_HistoryModel_HistoryModelId",
                table: "RequirementModel",
                column: "HistoryModelId",
                principalTable: "HistoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementModel_ProjectModel_ProjectModelId",
                table: "RequirementModel",
                column: "ProjectModelId",
                principalTable: "ProjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModel_CreatorModel_CreatorModelId",
                table: "TaskModel",
                column: "CreatorModelId",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModel_HistoryModel_HistoryModelId",
                table: "TaskModel",
                column: "HistoryModelId",
                principalTable: "HistoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModel_RequirementModel_RequirementModelId",
                table: "TaskModel",
                column: "RequirementModelId",
                principalTable: "RequirementModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModelUserModel_TaskModel_TaskModelsId",
                table: "TaskModelUserModel",
                column: "TaskModelsId",
                principalTable: "TaskModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamModel_CreatorModel_CreatorModelId",
                table: "TeamModel",
                column: "CreatorModelId",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketModel_CreatorModel_CreatorModelId",
                table: "TicketModel",
                column: "CreatorModelId",
                principalTable: "CreatorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketModel_HistoryModel_HistoryModelId",
                table: "TicketModel",
                column: "HistoryModelId",
                principalTable: "HistoryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketModel_TaskModel_TaskModelId",
                table: "TicketModel",
                column: "TaskModelId",
                principalTable: "TaskModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketModelUserModel_TicketModel_TicketModelsId",
                table: "TicketModelUserModel",
                column: "TicketModelsId",
                principalTable: "TicketModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
