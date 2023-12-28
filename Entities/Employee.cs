using System;
using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }

        // Navigation properties for relationships with other tables
        // These properties can be added as needed when setting up relationships
        // public virtual ICollection<Position> Positions { get; set; }
        // public virtual ICollection<Salary> Salaries { get; set; }
        // ... other navigation properties ...
    }

