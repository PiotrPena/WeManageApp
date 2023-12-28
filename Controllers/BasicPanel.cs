using Microsoft.EntityFrameworkCore;

public class BasicPanel : Panel
{
    public BasicPanel(User user, WeManageContext context) : base(user, context)
    {
        // Implementation specific to BasicPanel
    }

    public override void Process()
    {
        bool continueProcessing = true;

        while (continueProcessing)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Check Employee");
            Console.WriteLine("2. Check Employee Development");
            Console.WriteLine("3. Check Employee Schedule");
            Console.WriteLine("4. Check Incidents");
            Console.WriteLine("5. Check Leaves");
            Console.WriteLine("6. Check Profiles");
            Console.WriteLine("7. Check Ratings");
            Console.WriteLine("8. Check Schedule");
            Console.WriteLine("9. Check History");
            Console.WriteLine("10. Check Projects");
            Console.WriteLine("11. Switch Panel");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CheckEmployee();
                    break;
                case "2":
                    CheckEmployeeDevelopment();
                    break;
                case "3":
                    CheckEmployeeSchedule();
                    break;
                case "4":
                    CheckIncidents();
                    break;
                case "5":
                    CheckLeaves();
                    break;
                case "6":
                    CheckProfiles();
                    break;
                case "7":
                    CheckRatings();
                    break;
                case "8":
                    CheckSchedule();
                    break;
                case "9":
                    CheckHistory();
                    break;
                case "10":
                    CheckProjects();
                    break;
                case "11":
                    continueProcessing = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

            if (continueProcessing)
            {
                Console.WriteLine("Do you want to continue in the Basic Panel? (yes/no)");
                string? continueChoice = Console.ReadLine();
                Console.Clear();
                continueProcessing = continueChoice?.Trim().ToLower() == "yes";
            }
        }
    }


    public void CheckEmployee()
    {
        int employeeId = User.EmployeeID;

        var employee = Context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
        if (employee != null)
        {
            Console.WriteLine("Employee Details:");
            Console.WriteLine($"ID: {employee.EmployeeID}");
            Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
            Console.WriteLine($"Email: {employee.Email}");
            Console.WriteLine($"Date of Birth: {employee.DateOfBirth.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Gender: {employee.Gender}");
            Console.WriteLine($"Address: {employee.Address}");
        }
        else
        {
            Console.WriteLine("Employee details not found.");
        }
    }

    public void CheckEmployeeDevelopment()
    {
        int employeeId = User.EmployeeID;

        var employeeDevelopments = Context.EmployeeDevelopments
                                           .Where(ed => ed.EmployeeID == employeeId)
                                           .ToList();

        if (employeeDevelopments.Any())
        {
            Console.WriteLine("Employee Development Programs:");
            foreach (var ed in employeeDevelopments)
            {
                Console.WriteLine($"Development Type: {ed.DevelopmentType}");
                Console.WriteLine($"Title: {ed.Title}");
                Console.WriteLine($"Start Date: {ed.StartDate.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"End Date: {ed.EndDate?.ToString("yyyy-MM-dd") ?? "N/A"}");
                Console.WriteLine($"Provider: {ed.Provider}");
                Console.WriteLine($"Status: {ed.Status}");
                Console.WriteLine($"Result: {ed.Result}");
                Console.WriteLine($"Notes: {ed.Notes}");
                Console.WriteLine(new string('-', 40));
            }
        }
        else
        {
            Console.WriteLine("No development programs found for this employee.");
        }
    }

    public void CheckEmployeeSchedule()
    {
        int employeeId = User.EmployeeID;  // Assuming User class has an EmployeeID property

        var employeeSchedules = Context.EmployeeSchedules
                                        .Where(es => es.EmployeeID == employeeId && es.Date >= DateTime.Today)
                                        .OrderBy(es => es.Date)
                                        .ToList();

        if (employeeSchedules.Any())
        {
            Console.WriteLine("Employee Schedule:");
            foreach (var schedule in employeeSchedules)
            {
                Console.WriteLine($"Date: {schedule.Date.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Start Hour: {schedule.StartHour}");
                Console.WriteLine($"End Hour: {schedule.EndHour}");
                Console.WriteLine(new string('-', 40)); // Separator line
            }
        }
        else
        {
            Console.WriteLine("No schedule found for this employee.");
        }
    }

    public void CheckIncidents()
    {
        int employeeId = User.EmployeeID; // Assuming User class has an EmployeeID property

        var incidents = Context.Incidents
                            .Where(i => i.EmployeeID == employeeId)
                            .OrderBy(i => i.ReportedDate)
                            .ToList();

        if (incidents.Any())
        {
            Console.WriteLine("Employee Incidents:");
            foreach (var incident in incidents)
            {
                Console.WriteLine($"Incident Date: {incident.IncidentDate:yyyy-MM-dd}");
                Console.WriteLine($"Reported Date: {incident.ReportedDate:yyyy-MM-dd}");
                Console.WriteLine($"Incident Type: {incident.IncidentType}");
                Console.WriteLine($"Severity Level: {incident.SeverityLevel}");
                Console.WriteLine($"Description: {incident.Description}");
                Console.WriteLine($"Action Taken: {incident.ActionTaken}");
                Console.WriteLine($"Status: {incident.Status}");
                Console.WriteLine($"Resolution Date: {incident.ResolutionDate:yyyy-MM-dd}");
                Console.WriteLine($"Notes: {incident.Notes}");
                Console.WriteLine(new string('-', 40)); // Separator line
            }
        }
        else
        {
            Console.WriteLine("No incidents found for this employee.");
        }
    }

    public void CheckLeaves()
    {
        int employeeId = User.EmployeeID;

        var leaves = Context.Leaves
                            .Where(l => l.EmployeeID == employeeId)
                            .OrderBy(l => l.StartDate)
                            .ToList();

        if (leaves.Any())
        {
            Console.WriteLine("Employee Leaves:");
            foreach (var leave in leaves)
            {
                Console.WriteLine($"Start Date: {leave.StartDate.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"End Date: {(leave.EndDate.HasValue ? leave.EndDate.Value.ToString("yyyy-MM-dd") : "N/A")}");
                Console.WriteLine($"Leave Type: {leave.TypeOfLeave}");
                Console.WriteLine(new string('-', 40)); // Separator line
            }
        }
        else
        {
            Console.WriteLine("No leave records found for this employee.");
        }
    }

    public void CheckProfiles()
    {
        int employeeId = User.EmployeeID; // Assuming User class has an EmployeeID property

        var profiles = Context.Profiles
                            .Where(p => p.EmployeeID == employeeId)
                            .OrderBy(p => p.ActivityDate) // Updated to ActivityDate
                            .ToList();

        if (profiles.Any())
        {
            Console.WriteLine("Employee Profiles:");
            foreach (var profile in profiles)
            {
                Console.WriteLine($"Date: {profile.ActivityDate.ToString("yyyy-MM-dd")}"); // Updated to ActivityDate
                Console.WriteLine($"Activity Type: {profile.ActivityType}"); // Updated to ActivityType
                Console.WriteLine($"Activity Description: {profile.ActivityDescription}"); // Added ActivityDescription
                Console.WriteLine($"Impact: {profile.Impact}"); // Updated to Impact
                Console.WriteLine($"Visibility Level: {profile.VisibilityLevel}"); // Added VisibilityLevel
                Console.WriteLine($"Assessment: {profile.Assessment}"); // Added Assessment
                Console.WriteLine($"Notes: {profile.Notes}"); // Added Notes
                Console.WriteLine(new string('-', 40)); // Separator line
            }
        }
        else
        {
            Console.WriteLine("No profile records found for this employee.");
        }
    }


    public void CheckRatings()
    {
        int employeeId = User.EmployeeID; // Assuming User class has an EmployeeID property

        var ratings = Context.Ratings
                             .Where(r => r.EmployeeID == employeeId)
                             .OrderByDescending(r => r.Date)
                             .ToList();

        if (ratings.Any())
        {
            Console.WriteLine("Employee Performance Ratings:");
            foreach (var rating in ratings)
            {
                Console.WriteLine($"Date: {rating.Date.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Performance Rating: {rating.PerformanceRating ?? 0}");
                Console.WriteLine(new string('-', 40)); // Separator line
            }
        }
        else
        {
            Console.WriteLine("No performance rating records found for this employee.");
        }
    }

    public void CheckSchedule()
    {
        var upcomingEvents = Context.Schedules
                                    .Where(s => s.StartDate > DateTime.Today) // Updated to StartDate
                                    .OrderBy(s => s.StartDate) // Updated to StartDate
                                    .ToList();

        if (upcomingEvents.Any())
        {
            Console.WriteLine("Upcoming Events:");
            foreach (var eventItem in upcomingEvents)
            {
                Console.WriteLine($"Event Name: {eventItem.EventName}");
                Console.WriteLine($"Start Date: {eventItem.StartDate.ToString("yyyy-MM-dd HH:mm")}");
                Console.WriteLine($"End Date: {eventItem.EndDate.ToString("yyyy-MM-dd HH:mm")}");
                Console.WriteLine($"Room ID: {eventItem.RoomID}");
                Console.WriteLine($"Description: {eventItem.Description}");
                Console.WriteLine($"Host Employee ID: {eventItem.HostEmployeeID}");
                Console.WriteLine($"Event Type: {eventItem.EventType}");
                Console.WriteLine($"Is Mandatory: {(eventItem.IsMandatory.HasValue && eventItem.IsMandatory.Value == true ? "Yes" : "No")}");
                Console.WriteLine(new string('-', 40)); // Separator line
            }
        }
        else
        {
            Console.WriteLine("No upcoming events found.");
        }
    }

    public void CheckHistory()
    {
        int employeeId = User.EmployeeID;

        var salaries = Context.Salaries.Where(s => s.EmployeeID == employeeId).OrderBy(s => s.StartDate);
        var positions = Context.Positions.Where(p => p.EmployeeID == employeeId).OrderBy(p => p.StartDate);

        var history = salaries
            .AsEnumerable()
            .SelectMany(salary => positions
                .Where(position => position.StartDate <= (salary.EndDate ?? DateTime.MaxValue) && 
                                   (position.EndDate == null || position.EndDate >= salary.StartDate))
                .Select(position => new
                {
                    StartDate = new DateTime(Math.Max(salary.StartDate.Ticks, position.StartDate.Ticks)),
                    EndDate = salary.EndDate == null || position.EndDate == null ? 
                              salary.EndDate ?? position.EndDate :
                              new DateTime?(new DateTime(Math.Min((salary.EndDate ?? DateTime.MaxValue).Ticks, 
                                                                  (position.EndDate ?? DateTime.MaxValue).Ticks))),
                    Salary = salary.MonthlySalary,
                    Position = position.PositionName
                }))
            .OrderBy(h => h.StartDate)
            .ToList();

        Console.WriteLine($"History for employee ID {employeeId}:\n");
        foreach (var item in history)
        {
            Console.WriteLine($"From {item.StartDate.ToShortDateString()} to {item.EndDate?.ToShortDateString() ?? "Present"}:");
            Console.WriteLine($"  Position: {item.Position}");
            Console.WriteLine($"  Salary: ${item.Salary}");
            Console.WriteLine();
        }
    }

    public void CheckProjects()
    {
        int employeeId = User.EmployeeID;

        // Retrieve projects the user is part of
        var userProjects = Context.ProjectDetails
            .Where(pd => pd.EmployeeID == employeeId)
            .Select(pd => pd.ProjectID)
            .Distinct()
            .ToList();

        foreach (var projectId in userProjects)
        {
            var project = Context.Projects
                .Include(p => p.ProjectDetails)
                .ThenInclude(pd => pd.Employee)
                .FirstOrDefault(p => p.ProjectID == projectId);

            if (project != null)
            {
                Console.WriteLine($"Project Name: {project.ProjectName}");
                Console.WriteLine($"Description: {project.ProjectDescription}");
                Console.WriteLine($"Start Date: {project.StartDate.ToShortDateString()}");
                Console.WriteLine($"End Date: {project.EndDate?.ToShortDateString()}");
                Console.WriteLine($"Budget: {project.Budget}");
                Console.WriteLine($"Status: {project.Status}");
                Console.WriteLine($"Manager Employee ID: {project.ManagerEmployeeID}");
                Console.WriteLine("Participants:");
                foreach (var detail in project.ProjectDetails)
                {
                    Console.WriteLine($"  Employee ID: {detail.EmployeeID}, Role: {detail.Role}, Join Date: {detail.JoinDate.ToShortDateString()}, Leave Date: {detail.LeaveDate.ToShortDateString()}");
                }
                Console.WriteLine();
            }
        }
    }
}