using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class Empemployee
    {
        public Empemployee()
        {
            AdminUsers = new HashSet<AdminUser>();
            Carcartables = new HashSet<Carcartable>();
            InOutRequestLeaves = new HashSet<InOutRequestLeaf>();
            ServRequestServices = new HashSet<ServRequestService>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int EmpoloyeeNo { get; set; }
        public string FatherName { get; set; } = null!;
        public string NationalCode { get; set; } = null!;
        public string IdentifyNo { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public short Gender { get; set; }
        public string HireDate { get; set; } = null!;
        public string LeaveDate { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public string ImaghePath { get; set; } = null!;
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<AdminUser> AdminUsers { get; set; }
        public virtual ICollection<Carcartable> Carcartables { get; set; }
        public virtual ICollection<InOutRequestLeaf> InOutRequestLeaves { get; set; }
        public virtual ICollection<ServRequestService> ServRequestServices { get; set; }
    }
}
