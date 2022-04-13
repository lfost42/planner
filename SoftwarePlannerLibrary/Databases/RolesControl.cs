using Microsoft.AspNetCore.Identity;
using SoftwarePlannerLibrary.DataAccess;
using SoftwarePlannerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoftwarePlannerLibrary.Datases.Interfaces;

namespace SoftwarePlannerLibrary.Datases
{
    public class RolesControl : IRolesControl
    {
        private readonly PlannerContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UserModel> _userManager;
        public RolesControl(PlannerContext context,
                            RoleManager<IdentityRole> roleManager,
                            UserManager<UserModel> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //CREATE
        public async Task<bool> AddUserToRoleAsync(UserModel user, string roleName)
        {
            return (await _userManager.AddToRoleAsync(user, roleName)).Succeeded;

        }

        //READ
        public async Task<string> GetRoleById(string roleId)
        {
            return await _roleManager.GetRoleNameAsync(_context.Roles.Find(roleId));
        }

        public async Task<IEnumerable<string>> GetRolesbyUserAsync(UserModel user)
        {
            return await _userManager.GetRolesAsync(user);

        }

        public async Task<bool> IsUserInRoleAsync(UserModel user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        //DELETE
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
