using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Profile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfileID { get; set; }

        [Required]
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime ActivityDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string? ActivityType { get; set; }

        [Required]
        public string? ActivityDescription { get; set; }

        [Required]
        public string? Impact { get; set; }

        [Required]
        public string? VisibilityLevel { get; set; }

        [Required]
        public string? Assessment { get; set; }

        [Required]
        public string? Notes { get; set; }

        public virtual Employee? Employee { get; set; }
    }
