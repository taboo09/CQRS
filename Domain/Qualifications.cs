using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Qualifications
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public double Grade { get; set; }
        public string Date { get; set; }
        public long StaffId { get; set; }

        public virtual Staffs Staff { get; set; }
    }
}
