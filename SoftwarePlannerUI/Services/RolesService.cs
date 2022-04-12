using Microsoft.AspNetCore.Identity;
using SoftwarePlannerUI.Data;
using SoftwarePlannerUI.Models;
using SoftwarePlannerUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwarePlannerUI.Services
{
    public class RolesService : IRolesService
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UserModel> _userManager;
        public RolesService(ApplicationDbContext context,
                            RoleManager<IdentityRole> roleManager,
                            UserManager<UserModel> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        
        public async Task<bool> AddUserToRoleAsync(UserModel user, string roleName)
        {
            return (await _userManager.AddToRoleAsync(user, roleName)).Succeeded;

        }

        public async Task<string> GetRoleNameById(string roleId)
        {
            return await _roleManager.GetRoleNameAsync(_context.Roles.Find(roleId));
        }

        public async Task<IEnumerable<string>> GetUserRolesAsync(UserModel user)
        {
            return await _userManager.GetRolesAsync(user);

        }

        public async Task<bool> IsUserInRoleAsync(UserModel user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<bool> RemoveUserFromRoleAsync(UserModel user, string roleName)
        {
            return (await _userManager.RemoveFromRoleAsync(user, roleName)).Succeeded;
        }

        public async Task<bool> RemoveUserFromRolesAsync(UserModel user, IEnumerable<string> roles)
        {
            return (await _userManager.RemoveFromRolesAsync(user, roles)).Succeeded;
        }
    }
}
