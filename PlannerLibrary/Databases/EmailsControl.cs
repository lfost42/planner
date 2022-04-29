using System;
using PlannerLibrary.Data;
using PlannerLibrary.Databases.Interfaces;

namespace PlannerLibrary.Databases
{
    public class EmailsControl
    {
        private readonly ApplicationDbContext _context;
        private readonly IRolesControl _rolesControl;

        public EmailsControl(ApplicationDbContext context,
                            IRolesControl rolesControl)
        {
            _context = context;
            _rolesControl = rolesControl;
        }


    }
}
