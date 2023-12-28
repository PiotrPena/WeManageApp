using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class EmployeeSchedule
    {
        public int EmployeeID { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }

        // Navigation property
        public virtual Employee? Employee { get; set; }
    }
