using SoftwarePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePlannerLibrary.Services.Interfaces
{
    public interface IProjectsService
    {
        public Task AddNewProjectAsync(ProjectModel project);

        public Task<bool> AddProjectManagerAsync(string userId, int projectId);

        public Task<bool> AddUserToProjectAsync(string userId, int projectId);

        public Task ArchiveProjectAsync(ProjectModel project);

        public Task<List<ProjectModel>> GetAllProjectsByCompany(int companyId);

        public Task<List<ProjectModel>> GetAllProjectsByPriority(int companyId, string priorityName);

        public Task<List<UserModel>> GetAllProjectMembersExceptPMAsync(int projectId);

        public Task<List<ProjectModel>> GetArchivedProjectsByCompany(int companyId);

        public Task<List<UserModel>> GetDevelopersOnProjectAsync(int projectId);

        public Task<UserModel> GetProjectManagerAsync(int projectId);

        public Task<List<UserModel>> GetProjectMembersByRoleAsync(int projectId, string role);

        public Task<ProjectModel> GetProjectByIdAsync(int projectId, int companyId);

        public Task<List<UserModel>> GetSubmittersOnProjectAsync(int projectId);

        public Task<List<UserModel>> GetUsersNotOnProjectAsync(int projectId, int companyId);

        public Task<List<ProjectModel>> GetUserProjectsAsync(string userId);

        public Task<bool> IsUserOnProject(string userId, int projectId);

        public Task<int> LookupProjectPriorityId(string priorityName);

        public Task RemoveProjectManagerAsync(int projectId);

        public Task RemoveUsersFromProjectByRoleAsync(string role, int projectId);

        public Task RemoveUserFromProjectAsync(string userId, int projectId);

        public Task UpdateProjectAsync(ProjectModel project);

    }
}
