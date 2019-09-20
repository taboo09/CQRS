using System.Collections.Generic;

namespace Application.Dtos
{
    public class HomeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        // public ICollection<StaffDto> Staffs { get; set; }
    }
}