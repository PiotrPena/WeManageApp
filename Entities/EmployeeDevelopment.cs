using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class EmployeeDevelopment
    {
        [Key]
        public int DevelopmentID { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        [Required]
        public string? DevelopmentType { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public string? Provider { get; set; }
        [Required]
        public string? Status { get; set; }
        public string? Result { get; set; }
        public string? Notes { get; set; }

        // Navigation property
        public virtual Employee? Employee { get; set; }
    }
