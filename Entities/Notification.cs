using System;
using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }

        [Required]
        public int SenderEmployeeID { get; set; }

        [Required]
        public string? NotificationContent { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

    }
