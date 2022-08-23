using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planner.Models;

namespace Planner.Services.Interfaces
{
    public interface IBTRolesService
    {
        public Task<bool> IsUserInRoleAsync(AppUser user, string roleName);

        public Task<IEnumerable<string>> GetUserRolesAsync(AppUser user);

        public Task<bool> AddUserToRoleAsync(AppUser user, string roleName);

        public Task<bool> RemoveUserFromRoleAsync(AppUser user, string roleName);
        
        public Task<bool> RemoveUserFromRolesAsync(AppUser user, IEnumerable<string> roles);

        
        public Task<List<AppUser>> GetUsersInRolesAsync(string roleName, int TeamId);

        public Task<List<AppUser>> GetUsersNotInRolesAsync(string roleName, int TeamId);


        public Task<string> GetRoleNameByIdAsync(string roleId);

    }
}
