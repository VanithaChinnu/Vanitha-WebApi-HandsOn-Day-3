using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreEmpLibrary
{
    public partial class EMPL
    {
        public int EID { get; set; }
        public string EmpName { get; set; }
        public DateTime? DoBirth { get; set; }
        public decimal? Salary { get; set; }
    }
}
