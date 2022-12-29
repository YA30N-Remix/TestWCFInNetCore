using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class AdminSubSystem
    {
        public AdminSubSystem()
        {
            AdminForms = new HashSet<AdminForm>();
        }

        public int Id { get; set; }
        public string SubSystemName { get; set; } = null!;
        public string SubSystemNameFarsi { get; set; } = null!;
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<AdminForm> AdminForms { get; set; }
    }
}
