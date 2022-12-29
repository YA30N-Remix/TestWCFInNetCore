using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class InOutRequestLeaf
    {
        public int Id { get; set; }
        public string RequestDate { get; set; } = null!;
        public short RequestLeaveType { get; set; }
        public short LeaveType { get; set; }
        public string FromDate { get; set; } = null!;
        public string ToDate { get; set; } = null!;
        public string TimeLeaveDate { get; set; } = null!;
        public string FromTime { get; set; } = null!;
        public string ToTime { get; set; } = null!;
        public int LeaveDay { get; set; }
        public int LeaveTime { get; set; }
        public string LeaveReason { get; set; } = null!;
        public int? EmpemployeeId { get; set; }
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual Empemployee? Empemployee { get; set; }
    }
}
