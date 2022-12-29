using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class AdminRole
    {
        public AdminRole()
        {
            AdminUserRoles = new HashSet<AdminUserRole>();
            CarcartableTraces = new HashSet<CarcartableTrace>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }
        public string RoleNameFa { get; set; } = null!;

        public virtual ICollection<AdminUserRole> AdminUserRoles { get; set; }
        public virtual ICollection<CarcartableTrace> CarcartableTraces { get; set; }
    }
}
