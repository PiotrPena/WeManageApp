using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class ProjectDetail
    {
        [Key]
        public int ProjectDetailID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [ForeignKey("Project")]
        public int ProjectID { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Role { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        public DateTime LeaveDate { get; set; }

        public string? AdditionalInfo { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Project? Project { get; set; }
    }
