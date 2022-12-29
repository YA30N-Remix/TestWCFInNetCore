using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class Cartable
    {
        public Cartable()
        {
            CarcartableTraces = new HashSet<CarcartableTrace>();
        }

        public int Id { get; set; }
        public string TableName { get; set; } = null!;
        public int? AdminFormId { get; set; }
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual AdminForm? AdminForm { get; set; }
        public virtual ICollection<CarcartableTrace> CarcartableTraces { get; set; }
    }
}
