using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KharianSmartCity.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [StringLength(50)]
        public string ContactNumber { get; set; } = string.Empty;

        public ICollection<Personnel> Personnel { get; set; } = new List<Personnel>();
        public ICollection<Resource> Resources { get; set; } = new List<Resource>();
        public ICollection<Incident> AssignedIncidents { get; set; } = new List<Incident>();
    }
}