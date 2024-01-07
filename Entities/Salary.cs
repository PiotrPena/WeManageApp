using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Salary
{
    [Key]
    public int SalaryID { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeID { get; set; }

    [Required]
    public decimal MonthlySalary { get; set; }

    // Add this property for currency
    [Required]
    [StringLength(3)] // Assuming currency codes are 3 letters like USD, EUR, etc.
    public string? Currency { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Employee? Employee { get; set; }
}

