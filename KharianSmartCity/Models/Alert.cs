using System;
using System.ComponentModel.DataAnnotations;

namespace KharianSmartCity.Models
{
    public class Alert
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Message { get; set; } = string.Empty;

        [Required]
        public AlertSeverity Severity { get; set; }

        [Required]
        public KharianZone Zone { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}