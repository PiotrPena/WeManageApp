using System;
using System.ComponentModel.DataAnnotations;

    public class EmployeeDevelopment
    {
        [Key]
        public int DevelopmentID { get; set; }
        public int EmployeeID { get; set; }
        public string? DevelopmentType { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Provider { get; set; }
        public string? Status { get; set; }
        public string? Result { get; set; }
        public string? Notes { get; set; }

        // Navigation property
        public virtual Employee? Employee { get; set; }
    }
