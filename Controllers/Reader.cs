using Microsoft.EntityFrameworkCore;
public class Reader{

    private WeManageContext Context;
    public Reader(WeManageContext context){
        Context = context;
    }

    public void Process(){

    }

    public void ReadEmployees()
    {
        var employees = Context.Employees.ToList();

        if (employees.Any())
        {
            Console.WriteLine("Employee Details:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.EmployeeID}");
                Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"Date of Birth: {employee.DateOfBirth.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Gender: {employee.Gender}");
                Console.WriteLine($"Address: {employee.Address}");
                Console.WriteLine(new string('-', 40)); // Separator line for each employee
            }
        }
        else
        {
            Console.WriteLine("No employees found.");
        }
    }

    public void ReadEmployeeDevelopments()
    {
        var employeeDevelopments = Context.EmployeeDevelopments.ToList();

        if (employeeDevelopments.Any())
        {
            Console.WriteLine("All Employee Development Programs:");
            foreach (var ed in employeeDevelopments)
            {
                Console.WriteLine($"Employee ID: {ed.EmployeeID}");
                Console.WriteLine($"Development Type: {ed.DevelopmentType}");
                Console.WriteLine($"Title: {ed.Title}");
                Console.WriteLine($"Start Date: {ed.StartDate.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"End Date: {ed.EndDate?.ToString("yyyy-MM-dd") ?? "N/A"}");
                Console.WriteLine($"Provider: {ed.Provider}");
                Console.WriteLine($"Status: {ed.Status}");
                Console.WriteLine($"Result: {ed.Result}");
                Console.WriteLine($"Notes: {ed.Notes}");
                Console.WriteLine(new string('-', 40)); // Separator line for each record
            }
        }
        else
        {
            Console.WriteLine("No development programs found.");
        }
    }

     public void ReadEmployeeSchedules()
    {
        var employeeSchedules = Context.EmployeeSchedules
                                        .OrderBy(es => es.Date)
                                        .ToList();

        if (employeeSchedules.Any())
        {
            Console.WriteLine("All Employee Schedules:");
            foreach (var schedule in employeeSchedules)
            {
                Console.WriteLine($"Employee ID: {schedule.EmployeeID}");
                Console.WriteLine($"Date: {schedule.Date.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Start Hour: {schedule.StartHour}");
                Console.WriteLine($"End Hour: {schedule.EndHour}");
                Console.WriteLine(new string('-', 40)); // Separator line
            }
        }
        else
        {
            Console.WriteLine("No schedules found.");
        }
    }

    public void ReadIncidents()
    {
        var incidents = Context.Incidents
                               .OrderBy(i => i.ReportedDate)
                               .ToList();

        if (incidents.Any())
        {
            Console.WriteLine("All Incidents:");
            foreach (var incident in incidents)
            {
                Console.WriteLine($"Employee ID: {incident.EmployeeID}");
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
            Console.WriteLine("No incidents found.");
        }
    }

    public void ReadLeaves()
    {
        var leaves = Context.Leaves
                            .OrderBy(l => l.StartDate)
                            .ToList();

        if (leaves.Any())
        {
            Console.WriteLine("All Leave Records:");
            foreach (var leave in leaves)
            {
                Console.WriteLine($"Employee ID: {leave.EmployeeID}");
                Console.WriteLine($"Start Date: {leave.StartDate.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"End Date: {(leave.EndDate.HasValue ? leave.EndDate.Value.ToString("yyyy-MM-dd") : "N/A")}");
                Console.WriteLine($"Leave Type: {leave.TypeOfLeave}");
                Console.WriteLine(new string('-', 40)); // Separator line
            }
        }
        else
        {
            Console.WriteLine("No leave records found.");
        }
    }

    public void ReadProfiles()
    {
        var profiles = Context.Profiles
                              .OrderBy(p => p.ActivityDate)
                              .ToList();

        if (profiles.Any())
        {
            Console.WriteLine("All Employee Profiles:");
            foreach (var profile in profiles)
            {
                Console.WriteLine($"Employee ID: {profile.EmployeeID}");
                Console.WriteLine($"Date: {profile.ActivityDate.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Activity Type: {profile.ActivityType}");
                Console.WriteLine($"Activity Description: {profile.ActivityDescription}");
                Console.WriteLine($"Impact: {profile.Impact}");
                Console.WriteLine($"Visibility Level: {profile.VisibilityLevel}");
                Console.WriteLine($"Assessment: {profile.Assessment}");
                Console.WriteLine($"Notes: {profile.Notes}");
                Console.WriteLine(new string('-', 40)); // Separator line
            }
        }
        else
        {
            Console.WriteLine("No profile records found.");
        }
    }

    public void ReadRatings()
    {
        var ratings = Context.Ratings
                             .OrderByDescending(r => r.Date)
                             .ToList();

        if (ratings.Any())
        {
            Console.WriteLine("All Employee Performance Ratings:");
            foreach (var rating in ratings)
            {
                Console.WriteLine($"Employee ID: {rating.EmployeeID}");
                Console.WriteLine($"Date: {rating.Date.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Performance Rating: {rating.PerformanceRating ?? 0}");
                Console.WriteLine(new string('-', 40)); // Separator line
            }
        }
        else
        {
            Console.WriteLine("No performance rating records found.");
        }
    }

    public void ReadSchedules()
    {
        var schedules = Context.Schedules
                               .OrderBy(s => s.StartDate)
                               .ToList();

        if (schedules.Any())
        {
            Console.WriteLine("All Scheduled Events:");
            foreach (var eventItem in schedules)
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
            Console.WriteLine("No scheduled events found.");
        }
    }

    public void ReadHistory()
    {
        var employees = Context.Employees.ToList();

        foreach (var employee in employees)
        {
            var salaries = Context.Salaries.Where(s => s.EmployeeID == employee.EmployeeID).OrderBy(s => s.StartDate);
            var positions = Context.Positions.Where(p => p.EmployeeID == employee.EmployeeID).OrderBy(p => p.StartDate);

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

            Console.WriteLine($"History for employee ID {employee.EmployeeID} - {employee.FirstName} {employee.LastName}:\n");
            foreach (var item in history)
            {
                Console.WriteLine($"From {item.StartDate.ToShortDateString()} to {item.EndDate?.ToShortDateString() ?? "Present"}:");
                Console.WriteLine($"  Position: {item.Position}");
                Console.WriteLine($"  Salary: ${item.Salary}");
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 40)); // Separator line between employees
        }
    }

    public void ReadProjects()
    {
        var allProjects = Context.Projects
            .Include(p => p.ProjectDetails)
            .ThenInclude(pd => pd.Employee)
            .ToList();

        if (!allProjects.Any())
        {
            Console.WriteLine("No projects found.");
            return;
        }

        foreach (var project in allProjects)
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
                Console.WriteLine($"  Employee ID: {detail.EmployeeID}, Role: {detail.Role}, Join Date: {detail.JoinDate.ToShortDateString()}, Leave Date: {detail.LeaveDate.ToShortDateString() ?? "N/A"}");
            }
            Console.WriteLine(new string('-', 40)); // Separator line between projects
        }
    }

    public void ReadRecruitments()
    {
        var recruits = Context.Recruits
            .Include(r => r.Recruitments) // Include recruitment processes for each recruit
            .ToList();

        if (!recruits.Any())
        {
            Console.WriteLine("No recruits found.");
            return;
        }

        foreach (var recruit in recruits)
        {
            Console.WriteLine($"Recruit ID: {recruit.RecruitID}");
            Console.WriteLine($"Name: {recruit.FirstName} {recruit.LastName}");
            Console.WriteLine($"Date of Birth: {recruit.DateOfBirth.ToShortDateString()}");
            Console.WriteLine($"Email: {recruit.Email}");
            Console.WriteLine($"Gender: {recruit.Gender}");
            Console.WriteLine($"Address: {recruit.Address}");
            Console.WriteLine($"Recruitment Processes:");
            
            if (recruit.Recruitments != null && recruit.Recruitments.Any())
            {
                foreach (var recruitment in recruit.Recruitments)
                {
                    Console.WriteLine($"  Recruitment ID: {recruitment.RecruitmentID}");
                    Console.WriteLine($"  Position Name: {recruitment.PositionName}");
                    Console.WriteLine($"  Application Date: {recruitment.ApplicationDate.ToShortDateString()}");
                    Console.WriteLine($"  Status: {recruitment.Status}");
                    Console.WriteLine($"  Interview Date: {recruitment.InterviewDate.ToShortDateString()}");
                    Console.WriteLine($"  Notes: {recruitment.Notes}");
                    Console.WriteLine(new string('-', 20)); // Separator line for each recruitment process
                }
            }
            else
            {
                Console.WriteLine("  No recruitment processes found for this recruit.");
            }

            Console.WriteLine(new string('=', 40)); // Separator line between recruits
        }
    }

    public void ReadNotifications()
    {
        var currentDateTime = DateTime.Now;
        var notifications = Context.Notifications
            .Where(n => n.Timestamp > currentDateTime)
            .OrderBy(n => n.Timestamp) // Optional: Order by timestamp
            .ToList();

        if (!notifications.Any())
        {
            Console.WriteLine("No new notifications.");
            return;
        }

        foreach (var notification in notifications)
        {
            Console.WriteLine($"Notification ID: {notification.NotificationID}");
            Console.WriteLine($"Sender Employee ID: {notification.SenderEmployeeID}");
            Console.WriteLine($"Timestamp: {notification.Timestamp}");
            Console.WriteLine($"Content: {notification.NotificationContent}");
            Console.WriteLine(new string('-', 40)); // Separator line
        }
    }

}