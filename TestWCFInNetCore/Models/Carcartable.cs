using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class Carcartable
    {
        public double Id { get; set; }
        public string FieldCode { get; set; } = null!;
        public string RequestDate { get; set; } = null!;
        public short ConfirmType { get; set; }
        public string SignDate { get; set; } = null!;
        public int? EmpemployeeId { get; set; }
        public int? CarcartableTraceId { get; set; }
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual CarcartableTrace? CarcartableTrace { get; set; }
        public virtual Empemployee? Empemployee { get; set; }
    }
}
