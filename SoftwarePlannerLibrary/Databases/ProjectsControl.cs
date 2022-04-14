using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftwarePlannerLibrary.DataAccess;
using SoftwarePlannerLibrary.Models;
using SoftwarePlannerLibrary.Models.Enum;
using SoftwarePlannerLibrary.Databases.Interfaces;

namespace SoftwarePlannerLibrary.Databases
{
    public class ProjectsControl : IProjectsControl
    {
        private readonly PlannerContext _context;
        private readonly IRolesControl _rolesControl;

        public ProjectsControl(PlannerContext context,
                            IRolesControl rolesControl)
        {
            _context = context;
            _rolesControl = rolesControl;
        }

        //Create
        public async Task AddNProjectAsync(ProjectModel project)
        {
            _context.Add(project);
            await _context.SaveChangesAsync();
        }


        //Read

        public async Task<List<ProjectModel>> GetAllProjectsByPriority(string priorityLevel)
        {
            List<ProjectModel> projects = await GetAllProjectsByPriority(priorityLevel);
            int priorityId = await LookupProjectPriorityId(priorityLevel);
            return projects.Where(p => p.PriorityModelId == priorityId).ToList();
        }

        public async Task<List<ProjectModel>> GetAllProjectsByStatus(int status)
        {

            List<ProjectModel> projects = await GetAllProjectsByStatus(status);
            int statusId = await LookupProjectStatusId(status);
            return projects.Where(p => p.StatusModelId == statusId).ToList();
        }

        public async Task<List<UserModel>> GetAllProjectUsersExceptOwnerAsync(int projectId)
        {
            List<UserModel> contributors = await GetProjectUsersByRoleAsync(projectId, Roles.Contributor.ToString());
            List<UserModel> developers = await GetProjectUsersByRoleAsync(projectId, Roles.Developer.ToString());
            List<UserModel> admins = await GetProjectUsersByRoleAsync(projectId, Roles.Admin.ToString());
            List<UserModel> developerTeam = developers.Concat(contributors).Concat(admins).ToList();
            return developerTeam;
        }

        public async Task<List<UserModel>> GetDevelopersOnProjectAsync(int projectId)
        {
            return await GetProjectUsersByRoleAsync(projectId, Roles.Developer.ToString());
        }

        public async Task<bool> CheckUserOnProjectAsync(string userId, int projectId)
        {
            ProjectModel project = await _context.Projects
                .Include(p => p.Users)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            bool result = false;
            if (project != null)
            {
                result = project.Users.Any(u => u.Id == userId);
            }

            return result;
        }

        public async Task<List<ProjectModel>> GetAllProjectsByUser(string userId)
        {
            List<ProjectModel> projects = new();

            projects = (await _context.Users
                        .Include(u => u.ProjectModels)
                        .Include(u => u.ProjectModels).ThenInclude(p => p.Requirements)
                        .Include(u => u.ProjectModels).ThenInclude(p => p.Tasks)
                        .Include(u => u.ProjectModels).ThenInclude(p => p.Notes)
                        .Include(u => u.ProjectModels).ThenInclude(p => p.Attachments)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Photo)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.CreatorModel)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.TypeModel)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.PriorityModel)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.StatusModel)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.Notes)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.Notes).ThenInclude(n => n.StatusModel)
                        .FirstOrDefaultAsync(u => u.Id == userId)).ProjectModels.ToList();
            return projects;
        }

        public async Task<ProjectModel> GetProjectByIdAsync(int projectId)
        {
            ProjectModel project = await _context.Projects
                .Include(p => p.Users)
                .Include(p => p.Requirements)
                .Include(p => p.Requirements).ThenInclude(r => r.Tasks)
                .Include(p => p.PriorityModel)
                .Include(p => p.StatusModel)
                .Include(p => p.Changes)
                .Include(p => p.Notes)
                .Include(p => p.Tickets)
                .Include(p => p.Tickets).ThenInclude(p => p.CreatorModel)
                .Include(p => p.Tickets).ThenInclude(p => p.Notes)
                .Include(p => p.Tickets).ThenInclude(p => p.TypeModel)
                .Include(p => p.Tickets).ThenInclude(p => p.StatusModel)
                .Include(p => p.Tickets).ThenInclude(p => p.PriorityModel)
                .FirstOrDefaultAsync(p => p.Id == projectId);
            return project;
        }

        public async Task<CreatorModel> GetProjectCreatorAsync(int projectId)
        {
            return await _context.Creators.FirstOrDefaultAsync(p => p.Id == projectId);
        }

        public async Task<List<UserModel>> GetProjectUsersByRoleAsync(int projectId, string role)
        {
            ProjectModel project = await _context.Projects
                .Include(p => p.Users)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            List<UserModel> users = new();

            foreach (var user in project.Users)
            {
                if (await _rolesControl.IsUserInRoleAsync(user, role))
                {
                    users.Add(user);
                }
            }

            return users;
        }



        public async Task<List<UserModel>> GetContributorsOnProjectAsync(int projectId)
        {
            return await GetProjectUsersByRoleAsync(projectId, Roles.Contributor.ToString());
        }

        public async Task<List<UserModel>> GetUsersNotOnProjectAsync(int projectId)
        {
            return await _context.Users.Where(u => u.ProjectModels.All(p => p.Id == projectId)).ToListAsync();
        }

        public async Task<List<ProjectModel>> GetUserProjectsAsync(string userId)
        {
            try
            {
                List<ProjectModel> userProjects = (await _context.Users
                        .Include(u => u.ProjectModels)
                        .Include(u => u.ProjectModels).ThenInclude(p => p.Requirements)
                        .Include(u => u.ProjectModels).ThenInclude(p => p.Requirements).ThenInclude(p => p.Tasks)
                        .Include(u => u.ProjectModels).ThenInclude(p => p.Notes)
                        .Include(u => u.ProjectModels).ThenInclude(p => p.Attachments)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Photo)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.CreatorModel)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.TypeModel)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.PriorityModel)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.StatusModel)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.Notes)
                        .Include(p => p.ProjectModels).ThenInclude(p => p.Tickets)
                            .ThenInclude(t => t.Notes).ThenInclude(n => n.StatusModel)
                        .FirstOrDefaultAsync(u => u.Id == userId)).ProjectModels.ToList();
                return userProjects;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


        public async Task<int> LookupProjectPriorityId(string priorityLevel)
        {
            return (await _context.Priorities.FirstOrDefaultAsync(p => p.PriorityLevel == priorityLevel)).Id;
        }

        public async Task<int> LookupProjectStatusId(int status)
        {
            return (await _context.Status.FirstOrDefaultAsync(p => p.Id == status)).Id;
        }


        //Update
        public async Task<bool> AddUserToProjectAsync(string userId, int projectId)
        {
            UserModel user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                ProjectModel project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);

                if (!await CheckUserOnProjectAsync(userId, projectId))
                {
                    try
                    {
                        project.Users.Add(user);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else return false;
            }
            else return false;
        }

        public async Task ArchiveProjectAsync(ProjectModel project)
        {
            project.Archived = true;
            _context.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(ProjectModel project)
        {
            _context.Update(project);
            await _context.SaveChangesAsync();
        }


        //Delets
        public async Task RemoveUsersFromProjectByRoleAsync(string role, int projectId)
        {
            try
            {
                List<UserModel> users = await GetProjectUsersByRoleAsync(projectId, role);
                ProjectModel project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);

                foreach (UserModel user in users)
                {
                    try
                    {
                        project.Users.Remove(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task RemoveUserFromProjectAsync(string userId, int projectId)
        {
            try
            {
                UserModel user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                ProjectModel project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);

                try
                {
                    if (await CheckUserOnProjectAsync(userId, projectId))
                    {
                        project.Users.Remove(user);
                        await _context.SaveChangesAsync();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


    }
}
