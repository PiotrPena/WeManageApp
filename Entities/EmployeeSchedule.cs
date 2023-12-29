using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class EmployeeSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeScheduleID { get; set; }
        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartHour { get; set; }
        [Required]
        public TimeSpan EndHour { get; set; }

        // Navigation property
        public virtual Employee? Employee { get; set; }
    }
