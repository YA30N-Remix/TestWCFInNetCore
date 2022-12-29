using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class AdminUser
    {
        public AdminUser()
        {
            AdminUserRoles = new HashSet<AdminUserRole>();
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string PassWord { get; set; } = null!;
        public string VerificationCode { get; set; } = null!;
        public int? EmpemployeeId { get; set; }
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual Empemployee? Empemployee { get; set; }
        public virtual ICollection<AdminUserRole> AdminUserRoles { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
