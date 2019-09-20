using System;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class StaffDto
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string JobTitle { get; set; }
        public decimal AnnualSalary { get; set; }
        public int HomeId { get; set; }
        public ICollection<QualDto> Qualifications { get; set; }
    }
}