using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KharianSmartCity.Models
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty; 

        [Required]
        [StringLength(50)]
        public string ResourceNumber { get; set; } = string.Empty; 

        [Required]
        public ResourceStatus Status { get; set; } = ResourceStatus.Available;

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}