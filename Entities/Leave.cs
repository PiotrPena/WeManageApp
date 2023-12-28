using System;
using System.ComponentModel.DataAnnotations;

    public class Leave
    {
        [Key]
        public int LeaveID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? TypeOfLeave { get; set; }

        // Navigation property
        public virtual Employee? Employee { get; set; }
    }
