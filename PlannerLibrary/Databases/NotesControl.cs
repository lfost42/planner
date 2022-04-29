using System;
using PlannerLibrary.Data;
using PlannerLibrary.Databases.Interfaces;

namespace PlannerLibrary.Databases
{
    public class NotesControl
    {
        private readonly ApplicationDbContext _context;
        private readonly IRolesControl _rolesControl;

        public NotesControl(ApplicationDbContext context,
                            IRolesControl rolesControl)
        {
            _context = context;
            _rolesControl = rolesControl;
        }
    }
}
