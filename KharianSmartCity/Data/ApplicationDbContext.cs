using Microsoft.EntityFrameworkCore;
using KharianSmartCity.Models;

namespace KharianSmartCity.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set up cascading rule modifications if necessary
            modelBuilder.Entity<Personnel>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Personnel)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Department)
                .WithMany(d => d.Resources)
                .HasForeignKey(r => r.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}