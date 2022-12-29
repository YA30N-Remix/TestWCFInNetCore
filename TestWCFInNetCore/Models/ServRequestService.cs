using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class ServRequestService
    {
        public int Id { get; set; }
        public string RequestDate { get; set; } = null!;
        public short RequestServiceType { get; set; }
        public string ServicesOrGoods { get; set; } = null!;
        public int? EmpemployeeId { get; set; }
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual Empemployee? Empemployee { get; set; }
    }
}
