using System;
using System.Collections.Generic;

namespace EmployeesEdit.Models
{
    public partial class TblProfile
    {
        public TblProfile()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public int IdProfile { get; set; }
        public string Profile { get; set; } = null!;

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
