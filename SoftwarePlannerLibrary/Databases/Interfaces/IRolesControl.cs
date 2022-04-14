using System.Collections.Generic;
using System.Threading.Tasks;
using SoftwarePlannerLibrary.Models;

namespace SoftwarePlannerLibrary.Databases.Interfaces
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