using System;
using System.Collections.Generic;

namespace TestWCFInNetCore.Models
{
    public partial class Session
    {
        public int Id { get; set; }
        public string Token { get; set; } = null!;
        public string SessionUser { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
        public int? AdminUserId { get; set; }
        public short Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string? Description { get; set; }

        public virtual AdminUser? AdminUser { get; set; }
    }
}
