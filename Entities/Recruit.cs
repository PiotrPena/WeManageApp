using System;
using System.ComponentModel.DataAnnotations;

    public class Recruit
    {
        [Key]
        public int RecruitID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Email { get; set; }

        public string? Gender { get; set; }

        public string? Address { get; set; }

        public virtual ICollection<Recruitment> Recruitments { get; set; }

        public Recruit()
        {
            Recruitments = new HashSet<Recruitment>();
        }
    }
