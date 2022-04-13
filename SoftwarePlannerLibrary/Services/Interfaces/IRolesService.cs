using System.Collections.Generic;
using System.Threading.Tasks;
using SoftwarePlannerLibrary.Models;

namespace SoftwarePlannerUI.Services.Interfaces
{
    public interface IRolesService
    {
        Task<bool> AddUserToRoleAsync(UserModel user, string roleName);
        Task<string> GetRoleNameById(string roleId);
        Task<IEnumerable<string>> GetUserRolesAsync(UserModel user);
        Task<bool> IsUserInRoleAsync(UserModel user, string roleName);
        Task<bool> RemoveUserFromRoleAsync(UserModel user, string roleName);
        Task<bool> RemoveUserFromRolesAsync(UserModel user, IEnumerable<string> roles);
    }
}