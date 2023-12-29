using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Schedule
    {
        [Key]
        public int EventID { get; set; }
        [Required]
        public string? EventName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        [Required]
        public string? RoomID { get; set; }

        public string? Description { get; set; }

        [ForeignKey("Employee")]
        [Required]
        public int? HostEmployeeID { get; set; }
        [Required]
        public string? EventType { get; set; }
        [Required]
        public Boolean? IsMandatory { get; set; }
    }
