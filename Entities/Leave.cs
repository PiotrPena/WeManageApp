using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Leave
    {
        [Key]
        public int LeaveID { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        [Required]
        public string? TypeOfLeave { get; set; }

        // Navigation property
        public virtual Employee? Employee { get; set; }
    }
