using System;
using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Address { get; set; }
    }

