using System.Collections.Generic;
using System.Threading.Tasks;
using Planner.Data.Models;

namespace Planner.Data.Databases.Interfaces
{
    public interface IRolesControl
    {
        Task<bool> AddUserToRoleAsync(UserModel user, string roleName);
        Task<string> GetRoleById(string roleId);
        Task<IEnumerable<string>> GetRolesbyUserAsync(UserModel user);
        Task<bool> IsUserInRoleAsync(UserModel user, string roleName);
        Task<bool> RemoveUserFromRoleAsync(UserModel user, string roleName);
        Task<bool> RemoveUserFromRolesAsync(UserModel user, IEnumerable<string> roles);
    }
}