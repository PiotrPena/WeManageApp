using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int SenderEmployeeID { get; set; }

        [Required]
        public string? NotificationContent { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

    }
