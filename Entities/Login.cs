using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Login
    {

        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Password { get; set; }

        [Required]
        public string? AccessLevel { get; set; } // Basic, Moderator, Admin

        /* Navigation property
        [ForeignKey("EmployeeID")]
        public virtual Employee? Employee { get; set; }*/
    }
