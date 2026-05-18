namespace KharianSmartCity.Models
{
    public enum IncidentType { Fire, Crime, Medical, Traffic, Infrastructure }
    public enum IncidentStatus { Open, InProgress, Resolved, Closed }
    public enum PriorityLevel { Info, Warning, Critical }
    public enum PersonnelStatus { Available, OnDuty, OffDuty }
    public enum ResourceStatus { Available, Dispatched, Maintenance }
    public enum AlertSeverity { Info, Warning, Critical }

    public enum KharianZone
    {
        GTRoadZone,
        KharianCentral,
        CanttSector,
        EmergencyResponseZone,
        MedicalCoordinationSector
    }
}