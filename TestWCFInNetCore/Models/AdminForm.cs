using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class AdminForm
    {
        public AdminForm()
        {
            Cartables = new HashSet<Cartable>();
        }

        public int Id { get; set; }
        public string FormName { get; set; } = null!;
        public string FormNameFa { get; set; } = null!;
        public int? AdminSubSystemId { get; set; }
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual AdminSubSystem? AdminSubSystem { get; set; }
        public virtual ICollection<Cartable> Cartables { get; set; }
    }
}
