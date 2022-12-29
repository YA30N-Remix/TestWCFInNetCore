using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class AdminUserRole
    {
        public int Id { get; set; }
        public int? AdminRoleId { get; set; }
        public int? AdminUserId { get; set; }
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual AdminRole? AdminRole { get; set; }
        public virtual AdminUser? AdminUser { get; set; }
    }
}
