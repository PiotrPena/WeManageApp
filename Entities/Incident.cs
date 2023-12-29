using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Incident
    {
        [Key]
        public int IncidentID { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        [Required]
        public DateTime IncidentDate { get; set; }
        [Required]
        public string? IncidentType { get; set; }
        [Required]    
        public string? Description { get; set; }
        [Required]
        public string? SeverityLevel { get; set; }
        [Required]
        public DateTime ReportedDate { get; set; }

        public string? ActionTaken { get; set; }
        [Required]
        public string? Status { get; set; }

        public DateTime? ResolutionDate { get; set; }

        public string? Notes { get; set; }

        // Navigation property
        public virtual Employee? Employee { get; set; }
    }
