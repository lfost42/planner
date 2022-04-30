using System;
using Planner.Data.Data;
using Planner.Data.Databases.Interfaces;

namespace Planner.Data.Databases
{
    public class AlertsControl
    {
        private readonly ApplicationDbContext _context;
        private readonly IRolesControl _rolesControl;

        public AlertsControl(ApplicationDbContext context,
                            IRolesControl rolesControl)
        {
            _context = context;
            _rolesControl = rolesControl;
        }
    }
}
