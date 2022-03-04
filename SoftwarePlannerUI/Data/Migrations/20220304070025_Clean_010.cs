using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwarePlannerUI.Data.Migrations
{
    public partial class Clean_010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelUserModel_ProjectModel_ProjectModelssId",
                table: "ProjectModelUserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskModelUserModel_TaskModel_TaskModelssId",
                table: "TaskModelUserModel");

            migrationBuilder.RenameColumn(
                name: "TaskModelssId",
                table: "TaskModelUserModel",
                newName: "TaskModelsId");

            migrationBuilder.RenameColumn(
                name: "ProjectModelssId",
                table: "ProjectModelUserModel",
                newName: "ProjectModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelUserModel_ProjectModel_ProjectModelsId",
                table: "ProjectModelUserModel",
                column: "ProjectModelsId",
                principalTable: "ProjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModelUserModel_TaskModel_TaskModelsId",
                table: "TaskModelUserModel",
                column: "TaskModelsId",
                principalTable: "TaskModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModelUserModel_ProjectModel_ProjectModelsId",
                table: "ProjectModelUserModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskModelUserModel_TaskModel_TaskModelsId",
                table: "TaskModelUserModel");

            migrationBuilder.RenameColumn(
                name: "TaskModelsId",
                table: "TaskModelUserModel",
                newName: "TaskModelssId");

            migrationBuilder.RenameColumn(
                name: "ProjectModelsId",
                table: "ProjectModelUserModel",
                newName: "ProjectModelssId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModelUserModel_ProjectModel_ProjectModelssId",
                table: "ProjectModelUserModel",
                column: "ProjectModelssId",
                principalTable: "ProjectModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModelUserModel_TaskModel_TaskModelssId",
                table: "TaskModelUserModel",
                column: "TaskModelssId",
                principalTable: "TaskModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
