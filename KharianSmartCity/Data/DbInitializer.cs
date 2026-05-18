using System;
using System.Linq;
using KharianSmartCity.Models;

namespace KharianSmartCity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Departments.Any()) return; // DB already seeded

            // 1. Seed Departments
            var departments = new Department[]
            {
                new Department { Name = "Kharian Police Department", Description = "Law enforcement & local security", ContactNumber = "053-15" },
                new Department { Name = "Rescue 1122 Kharian", Description = "Fire emergency & medical response services", ContactNumber = "053-1122" },
                new Department { Name = "Cantt Traffic Control", Description = "Traffic management & highway patrols", ContactNumber = "053-92401" }
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();

            // 2. Seed Personnel
            var personnel = new Personnel[]
            {
                new Personnel { Name = "Officer Amjad Khan", Rank = "Sub-Inspector", Status = PersonnelStatus.OnDuty, DepartmentId = departments[0].Id },
                new Personnel { Name = "Zain Ali", Rank = "Paramedic Lead", Status = PersonnelStatus.Available, DepartmentId = departments[1].Id },
                new Personnel { Name = "Sajid Mahmood", Rank = "Warden", Status = PersonnelStatus.OnDuty, DepartmentId = departments[2].Id }
            };
            context.Personnels.AddRange(personnel);

            // 3. Seed Resources
            var resources = new Resource[]
            {
                new Resource { Name = "Police Interceptor", ResourceNumber = "ICT-789", Status = ResourceStatus.Dispatched, DepartmentId = departments[0].Id },
                new Resource { Name = "Rescue Ambulance", ResourceNumber = "KRN-112", Status = ResourceStatus.Available, DepartmentId = departments[1].Id },
                new Resource { Name = "Fire Tender Alpha", ResourceNumber = "KRN-911", Status = ResourceStatus.Available, DepartmentId = departments[1].Id }
            };
            context.Resources.AddRange(resources);

            // 4. Seed Incidents
            var incidents = new Incident[]
            {
                new Incident { Title = "Traffic Collision on GT Road", Description = "Two-car minor crash causing bottlenecks near General Hospital.", Type = IncidentType.Traffic, Status = IncidentStatus.InProgress, Priority = PriorityLevel.Warning, Zone = KharianZone.GTRoadZone, DepartmentId = departments[2].Id },
                new Incident { Title = "Commercial Fire Outbreak", Description = "Electrical short circuit at Kharian Central Bazar commercial outlet.", Type = IncidentType.Fire, Status = IncidentStatus.Open, Priority = PriorityLevel.Critical, Zone = KharianZone.KharianCentral, DepartmentId = departments[1].Id }
            };
            context.Incidents.AddRange(incidents);

            // 5. Seed Alerts
            var alerts = new Alert[]
            {
                new Alert { Message = "High congestion alert on GT Road due to infrastructure maintenance.", Severity = AlertSeverity.Warning, Zone = KharianZone.GTRoadZone }
            };
            context.Alerts.AddRange(alerts);

            context.SaveChanges();
        }
    }
}