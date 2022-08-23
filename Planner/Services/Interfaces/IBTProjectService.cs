using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models;

namespace Planner.Services.Interfaces
{
    public interface IProjectService
    {
        public Task AddNewProjectAsync(Project project);
        public Task<bool> AddProjectManagerAsync(string userId, int projectId);
        public Task<bool> AddUserToProjectAsync(string userId, int projectId);
        public Task ArchiveProjectAsync(Project project);
        public Task<List<Project>> GetAllProjectsByCompany(int companyId);
        public Task<List<Project>> GetAllProjectsByPriority(int companyId, string priorityName);
        public Task<List<AppUser>> GetAllProjectMembersExceptPMAsync(int projectId);
        public Task<List<Project>> GetArchivedProjectsByCompany(int companyId);
        public Task<List<AppUser>> GetDevelopersOnProjectAsync(int projectId);
        public Task<AppUser> GetProjectManagerAsync(int projectId);
        public Task<List<AppUser>> GetProjectMembersByRoleAsync(int projectId, string role);
        public Task<Project> GetProjectByIdAsync(int projectId, int companyId);
        public Task<List<AppUser>> GetSubmittersOnProjectAsync(int projectId);
        public Task<List<AppUser>> GetUsersNotOnProjectAsync(int projectId, int companyId);
        public Task<List<Project>> GetUserProjectsAsync(string userId);
        public Task<bool> IsUserOnProjectAsync(string userId, int projectId);
        public Task<int> LookupProjectPriorityId(string priorityName);
        public Task RemoveProjectManagerAsync(int projectId);
        public Task RemoveUsersFromProjectByRoleAsync(string role, int projectId);
        public Task RemoveUserFromProjectAsync(string userId, int projectId);
        public Task UpdateProjectAsync(Project project);








    }
}
