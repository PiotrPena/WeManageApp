using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Schedule
    {
        [Key]
        public int EventID { get; set; }

        public string? EventName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? RoomID { get; set; }

        public string? Description { get; set; }

        [ForeignKey("EmployeeID")]
        public int? HostEmployeeID { get; set; }

        public string? EventType { get; set; }

        public Boolean? IsMandatory { get; set; }
    }
