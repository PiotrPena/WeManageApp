using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        [Required]
        [MaxLength(200)]
        public string? ProjectName { get; set; }

        [MaxLength(500)]
        public string? ProjectDescription { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? Budget { get; set; }

        [MaxLength(100)]
        public string? Status { get; set; }

        public int? ManagerEmployeeID { get; set; }

        public virtual ICollection<ProjectDetail> ProjectDetails { get; set; }

        public Project()
        {
            ProjectDetails = new HashSet<ProjectDetail>();
        }
    }
