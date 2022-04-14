using SoftwarePlannerLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoftwarePlannerLibrary.Databases.Interfaces
{
    public interface IProjectsControl
    {
        Task AddNProjectAsync(ProjectModel project);
        Task<bool> AddUserToProjectAsync(string userId, int projectId);
        Task ArchiveProjectAsync(ProjectModel project);
        Task<bool> CheckUserOnProjectAsync(string userId, int projectId);
        Task<List<ProjectModel>> GetAllProjectsByPriority(string priorityLevel);
        Task<List<ProjectModel>> GetAllProjectsByStatus(int status);
        Task<List<ProjectModel>> GetAllProjectsByUser(string userId);
        Task<List<UserModel>> GetAllProjectUsersExceptOwnerAsync(int projectId);
        Task<List<UserModel>> GetContributorsOnProjectAsync(int projectId);
        Task<List<UserModel>> GetDevelopersOnProjectAsync(int projectId);
        Task<ProjectModel> GetProjectByIdAsync(int projectId);
        Task<CreatorModel> GetProjectCreatorAsync(int projectId);
        Task<List<UserModel>> GetProjectUsersByRoleAsync(int projectId, string role);
        Task<List<ProjectModel>> GetUserProjectsAsync(string userId);
        Task<List<UserModel>> GetUsersNotOnProjectAsync(int projectId);
        Task<int> LookupProjectPriorityId(string priorityLevel);
        Task<int> LookupProjectStatusId(int status);
        Task RemoveUserFromProjectAsync(string userId, int projectId);
        Task RemoveUsersFromProjectByRoleAsync(string role, int projectId);
        Task UpdateProjectAsync(ProjectModel project);
    }
}