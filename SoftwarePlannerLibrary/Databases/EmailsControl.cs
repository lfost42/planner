using System;
using SoftwarePlannerLibrary.DataAccess;
using SoftwarePlannerLibrary.Databases.Interfaces;

namespace SoftwarePlannerLibrary.Databases
{
    public class EmailsControl
    {
        private readonly PlannerContext _context;
        private readonly IRolesControl _rolesControl;

        public EmailsControl(PlannerContext context,
                            IRolesControl rolesControl)
        {
            _context = context;
            _rolesControl = rolesControl;
        }


    }
}
