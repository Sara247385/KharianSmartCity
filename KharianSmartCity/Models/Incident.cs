using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KharianSmartCity.Models
{
    public class Incident
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public IncidentType Type { get; set; }

        [Required]
        public IncidentStatus Status { get; set; } = IncidentStatus.Open;

        [Required]
        public PriorityLevel Priority { get; set; }

        [Required]
        public KharianZone Zone { get; set; }

        [Required]
        public DateTime ReportedAt { get; set; } = DateTime.Now;

        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? AssignedDepartment { get; set; }
    }
}
