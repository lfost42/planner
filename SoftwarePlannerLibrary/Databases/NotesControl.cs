using System;
using SoftwarePlannerLibrary.DataAccess;
using SoftwarePlannerLibrary.Databases.Interfaces;

namespace SoftwarePlannerLibrary.Databases
{
    public class NotesControl
    {
        private readonly PlannerContext _context;
        private readonly IRolesControl _rolesControl;

        public NotesControl(PlannerContext context,
                            IRolesControl rolesControl)
        {
            _context = context;
            _rolesControl = rolesControl;
        }
    }
}
