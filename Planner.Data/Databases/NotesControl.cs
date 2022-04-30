using System;
using Planner.Data.Data;
using Planner.Data.Databases.Interfaces;

namespace Planner.Data.Databases
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
