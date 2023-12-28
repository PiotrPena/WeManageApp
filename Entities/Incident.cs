using System;
using System.ComponentModel.DataAnnotations;

    public class Incident
    {
        [Key]
        public int IncidentID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime IncidentDate { get; set; }

        public string? IncidentType { get; set; }
        
        public string? Description { get; set; }

        public string? SeverityLevel { get; set; }

        public DateTime ReportedDate { get; set; }

        public string? ActionTaken { get; set; }

        public string? Status { get; set; }

        public DateTime ResolutionDate { get; set; }

        public string? Notes { get; set; }

        // Navigation property
        public virtual Employee? Employee { get; set; }
    }
