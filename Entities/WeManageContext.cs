using Microsoft.EntityFrameworkCore;

public class WeManageContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeDevelopment> EmployeeDevelopments { get; set; }
    public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Leave> Leaves { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<ProjectDetail> ProjectDetails { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Recruitment> Recruitments { get; set; }
    public DbSet<Recruit> Recruits { get; set; }
    public DbSet<Salary> Salaries { get; set; }
    public DbSet<Schedule> Schedules { get; set; }

     // Constructor
    public WeManageContext()
    {
    }

    public WeManageContext(DbContextOptions<WeManageContext> options)
        : base(options)
    {
    }

    // OnConfiguring method
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Define the connection string here
            // Alternatively, you can configure it in the Startup.cs or Program.cs
            var connectionString = "Server=localhost;Database=WeManageDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure composite key for EmployeeSchedule
        modelBuilder.Entity<EmployeeSchedule>()
            .HasKey(es => new { es.EmployeeID, es.Date });
        // Configure composite key for EmployeeSchedule
        modelBuilder.Entity<ProjectDetail>()
            .HasKey(pd => new { pd.EmployeeID, pd.ProjectID });
            // Configure composite key for EmployeeSchedule
        modelBuilder.Entity<Rating>()
            .HasKey(r => new { r.EmployeeID, r.Date });
    }
}
