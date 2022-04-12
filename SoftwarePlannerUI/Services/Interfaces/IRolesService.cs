using SoftwarePlannerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwarePlannerUI.Services.Interfaces
{
    public interface IRolesService
    {
        public Task<bool> IsUserInRoleAsync(UserModel user, string roleName);

        public Task<IEnumerable<string>> GetUserRolesAsync(UserModel user);

        public Task<bool> AddUserToRoleAsync(UserModel user, string roleName);

        public Task<bool> RemoveUserFromRoleAsync(UserModel user, string roleName);

        public Task<bool> RemoveUserFromRolesAsync(UserModel user, IEnumerable<string> roles);

        public Task<string> GetRoleNameById(string roleId);


    }
}
