using System;
using System.ComponentModel.DataAnnotations;

namespace KharianSmartCity.Models
{
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserEmail { get; set; } = "System";

        [Required]
        public string Action { get; set; } = string.Empty; 

        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}