using System;
using System.Collections.Generic;

namespace EmployeesEdit
{
    public partial class TblUser
    {
        public int IdUser { get; set; }
        public string UserName { get; set; } = null!;
        public string? Password { get; set; }
        public int IdProfile { get; set; }
        public string IdEmployee { get; set; } = null!;
        public bool? Status { get; set; }
        public byte[] CreateDate { get; set; } = null!;
        public DateTime? UpdateDate { get; set; }
        public string? Login { get; set; }
    }
}
