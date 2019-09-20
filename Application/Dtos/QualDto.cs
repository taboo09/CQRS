using System;

namespace Application.Dtos
{
    public class QualDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Grade { get; set; }
        public DateTime? Date { get; set; }
        public int StaffId { get; set; }
    }
}