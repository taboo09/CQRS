using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Homes
    {
        public Homes()
        {
            Staffs = new HashSet<Staffs>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
