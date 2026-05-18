using Microsoft.EntityFrameworkCore;
using KharianSmartCity.Data;
using KharianSmartCity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KharianSmartCity.Services
{
    public class IncidentService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public IncidentService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Incident>> GetIncidentsAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Incidents.Include(i => i.AssignedDepartment).OrderByDescending(i => i.ReportedAt).ToListAsync();
        }

        public async Task<Incident?> GetIncidentByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Incidents.Include(i => i.AssignedDepartment).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddIncidentAsync(Incident incident)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Incidents.Add(incident);
            context.AuditLogs.Add(new AuditLog { Action = $"Reported new incident: {incident.Title}" });
            await context.SaveChangesAsync();
        }

        public async Task UpdateIncidentAsync(Incident incident)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Entry(incident).State = EntityState.Modified;
            context.AuditLogs.Add(new AuditLog { Action = $"Updated Incident ID: {incident.Id} status to {incident.Status}" });
            await context.SaveChangesAsync();
        }
    }
}