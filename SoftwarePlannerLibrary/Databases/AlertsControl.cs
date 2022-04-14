using System;
using SoftwarePlannerLibrary.DataAccess;
using SoftwarePlannerLibrary.Databases.Interfaces;

namespace SoftwarePlannerLibrary.Databases
{
    public class AlertsControl
    {
        private readonly PlannerContext _context;
        private readonly IRolesControl _rolesControl;

        public AlertsControl(PlannerContext context,
                            IRolesControl rolesControl)
        {
            _context = context;
            _rolesControl = rolesControl;
        }
    }
}
