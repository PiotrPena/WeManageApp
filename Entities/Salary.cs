using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Salary
    {
        [Key]
        public int SalaryID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public decimal MonthlySalary { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual Employee? Employee { get; set; }

    }
