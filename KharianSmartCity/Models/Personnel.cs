using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KharianSmartCity.Models
{
    public class Personnel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Rank { get; set; } = string.Empty;

        [Required]
        public PersonnelStatus Status { get; set; } = PersonnelStatus.Available;

        [StringLength(50)]
        public string ContactNumber { get; set; } = string.Empty;

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}
