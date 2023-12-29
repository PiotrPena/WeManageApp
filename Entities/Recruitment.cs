using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Recruitment
    {
        [Key]
        public int RecruitmentID { get; set; }

        [ForeignKey("Recruit")]
        public int RecruitID { get; set; }
        [Required]
        public string? PositionName { get; set; }
        [Required]
        public DateTime ApplicationDate { get; set; }
        [Required]
        public string? Status { get; set; }

        public DateTime InterviewDate { get; set; }

        public string? Notes { get; set; }

        public virtual Recruit? Recruit { get; set; }

    }
