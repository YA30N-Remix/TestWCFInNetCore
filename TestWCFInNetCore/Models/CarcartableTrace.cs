using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class CarcartableTrace
    {
        public CarcartableTrace()
        {
            Carcartables = new HashSet<Carcartable>();
        }

        public int Id { get; set; }
        public int OrderNo { get; set; }
        public string SignTitle { get; set; } = null!;
        public string SignTitleFa { get; set; } = null!;
        public int? CartableId { get; set; }
        public int? AdminRoleId { get; set; }
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual AdminRole? AdminRole { get; set; }
        public virtual Cartable? Cartable { get; set; }
        public virtual ICollection<Carcartable> Carcartables { get; set; }
    }
}
