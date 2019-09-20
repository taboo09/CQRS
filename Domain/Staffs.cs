using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Staffs
    {
        public Staffs()
        {
            Qualifications = new HashSet<Qualifications>();
        }

        public long Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string JobTitle { get; set; }
        public string AnnualSalary { get; set; }
        public long HomeId { get; set; }

        public virtual Homes Home { get; set; }
        public virtual ICollection<Qualifications> Qualifications { get; set; }
    }
}
