using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Rating
    {
        [Key]
        public int RatingID { get; set; }
        
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int? PerformanceRating { get; set; }

        public virtual Employee? Employee { get; set; }
    }
