using Microsoft.EntityFrameworkCore;
public class Deleter{

    private WeManageContext Context;
    private Reader Reader;
    public Deleter(WeManageContext context){
        Context = context;
        Reader = new Reader(context);
    }

    public void Process()
{
    bool continueUsingDeleter = true;

    while (continueUsingDeleter)
    {
        Console.WriteLine("Select an option to proceed:");
        Console.WriteLine("1. Delete Employee");
        Console.WriteLine("2. Delete Employee Schedule");
        Console.WriteLine("3. Delete Employee Development");
        Console.WriteLine("4. Delete Incident");
        Console.WriteLine("5. Delete Leave");
        Console.WriteLine("6. Delete Profile");
        Console.WriteLine("7. Delete Performance Rating");
        Console.WriteLine("8. Delete Event");
        Console.WriteLine("9. Delete Project");
        Console.WriteLine("10. Delete Project Detail");
        Console.WriteLine("11. Delete Recruit");
        Console.WriteLine("12. Delete Recruitment");
        Console.WriteLine("13. Delete Notification");
        Console.WriteLine("14. Delete Salary");
        Console.WriteLine("15. Delete Position");
        Console.WriteLine("0. Exit");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                DeleteEmployee();
                break;
            case 2:
                DeleteEmployeeSchedule();
                break;
            case 3:
                DeleteEmployeeDevelopment();
                break;
            case 4:
                DeleteIncident();
                break;
            case 5:
                DeleteLeave();
                break;
            case 6:
                DeleteProfile();
                break;
            case 7:
                DeleteRating();
                break;
            case 8:
                DeleteSchedule();
                break;
            case 9:
                DeleteProject();
                break;
            case 10:
                DeleteProjectDetail();
                break;
            case 11:
                DeleteRecruit();
                break;
            case 12:
                DeleteRecruitment();
                break;
            case 13:
                DeleteNotification();
                break;
            case 14:
                DeleteSalary();
                break;
            case 15:
                DeletePosition();
                break;
            case 0:
                continueUsingDeleter = false;
                break;
            default:
                Console.WriteLine("Invalid choice, please try again.");
                break;
        }

        if (continueUsingDeleter)
        {
            Console.WriteLine("Do you want to continue? (yes/no)");
            string? answer = Console.ReadLine()?.ToLower();
            continueUsingDeleter = answer == "yes";
        }
    }
}


    public void DeleteEmployee()
    {
        try
        {
            // Step 1: Read all employees
            Reader.ReadEmployees();

            // Step 2: Prompt user to choose an employee to delete
            Console.WriteLine("Enter the ID of the employee to delete:");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            // Fetch the employee
            var employee = Context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            // Step 3: Display the chosen employee and ask for confirmation
            Console.WriteLine($"You have selected to delete the following employee:");
            Console.WriteLine($"ID: {employee.EmployeeID}, Name: {employee.FirstName} {employee.LastName}");
            Console.WriteLine("Are you sure you want to delete this employee? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: If confirmed, delete the employee
            if (confirmation == "yes")
            {
                Context.Employees.Remove(employee);
                Context.SaveChanges();
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteEmployeeDevelopment()
    {
        try
        {
            // Step 1: Read all employee development records
            Reader.ReadEmployeeDevelopments();

            // Step 2: Prompt user to choose a record to delete
            Console.WriteLine("Enter the ID of the employee development record to delete:");
            int developmentId = Convert.ToInt32(Console.ReadLine());

            // Fetch the record
            var development = Context.EmployeeDevelopments.FirstOrDefault(ed => ed.DevelopmentID == developmentId);
            if (development == null)
            {
                Console.WriteLine("Employee development record not found.");
                return;
            }

            // Step 3: Display the chosen record and ask for confirmation
            Console.WriteLine($"You have selected to delete the following employee development record:");
            Console.WriteLine($"ID: {development.DevelopmentID}, Employee ID: {development.EmployeeID}, Course: {development.Title}");
            Console.WriteLine("Are you sure you want to delete this record? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: If confirmed, delete the record
            if (confirmation == "yes")
            {
                Context.EmployeeDevelopments.Remove(development);
                Context.SaveChanges();
                Console.WriteLine("Employee development record deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteEmployeeSchedule()
    {
        try
        {
            // Step 1: Display all employee schedules
            Reader.ReadEmployeeSchedules();

            // Step 2: Ask the user to choose a schedule to delete
            Console.WriteLine("Enter the ID of the employee schedule to delete:");
            int scheduleId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected schedule
            var schedule = Context.EmployeeSchedules.FirstOrDefault(es => es.EmployeeScheduleID == scheduleId);
            if (schedule == null)
            {
                Console.WriteLine("Employee schedule not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the schedule for Employee ID: {schedule.EmployeeID} on Date: {schedule.Date.ToShortDateString()}");
            Console.WriteLine("Are you sure you want to delete this schedule? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the schedule if confirmed
            if (confirmation == "yes")
            {
                Context.EmployeeSchedules.Remove(schedule);
                Context.SaveChanges();
                Console.WriteLine("Employee schedule deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteIncident()
    {
        try
        {
            // Step 1: Display all incidents
            Reader.ReadIncidents();

            // Step 2: Ask the user to choose an incident to delete
            Console.WriteLine("Enter the ID of the incident to delete:");
            int incidentId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected incident
            var incident = Context.Incidents.FirstOrDefault(i => i.IncidentID == incidentId);
            if (incident == null)
            {
                Console.WriteLine("Incident not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the incident with ID: {incident.IncidentID}");
            Console.WriteLine("Are you sure you want to delete this incident? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the incident if confirmed
            if (confirmation == "yes")
            {
                Context.Incidents.Remove(incident);
                Context.SaveChanges();
                Console.WriteLine("Incident deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteLeave()
    {
        try
        {
            // Step 1: Display all leaves
            Reader.ReadLeaves();

            // Step 2: Ask the user to choose a leave to delete
            Console.WriteLine("Enter the ID of the leave to delete:");
            int leaveId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected leave
            var leave = Context.Leaves.FirstOrDefault(l => l.LeaveID == leaveId);
            if (leave == null)
            {
                Console.WriteLine("Leave not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the leave with ID: {leave.LeaveID}");
            Console.WriteLine("Are you sure you want to delete this leave? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the leave if confirmed
            if (confirmation == "yes")
            {
                Context.Leaves.Remove(leave);
                Context.SaveChanges();
                Console.WriteLine("Leave deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteNotification()
    {
        try
        {
            // Step 1: Display all notifications
            Reader.ReadNotifications();

            // Step 2: Ask the user to choose a notification to delete
            Console.WriteLine("Enter the ID of the notification to delete:");
            int notificationId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected notification
            var notificationList = NotificationList.GetInstance(Context);
            var notification = notificationList.GetNotification(notificationId);
            if (notification == null)
            {
                Console.WriteLine("Notification not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the notification with ID: {notification.NotificationID}");
            Console.WriteLine("Are you sure you want to delete this notification? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the notification if confirmed
            if (confirmation == "yes")
            {
                Context.Notifications.Remove(notification);
                Context.SaveChanges();
                Console.WriteLine("Notification deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeletePosition()
    {
        try
        {
            // Step 1: Display all positions
            Reader.ReadPositions();

            // Step 2: Ask the user to choose a position to delete
            Console.WriteLine("Enter the ID of the position to delete:");
            int positionId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected position
            var position = Context.Positions.FirstOrDefault(p => p.PositionID == positionId);
            if (position == null)
            {
                Console.WriteLine("Position not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the position with ID: {position.PositionID}");
            Console.WriteLine("Are you sure you want to delete this position? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the position if confirmed
            if (confirmation == "yes")
            {
                Context.Positions.Remove(position);
                Context.SaveChanges();
                Console.WriteLine("Position deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteProfile()
    {
        try
        {
            // Step 1: Display all profiles
            Reader.ReadProfiles();

            // Step 2: Ask the user to choose a profile to delete
            Console.WriteLine("Enter the ID of the profile to delete:");
            int profileId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected profile
            var profile = Context.Profiles.FirstOrDefault(p => p.ProfileID == profileId);
            if (profile == null)
            {
                Console.WriteLine("Profile not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the profile with ID: {profile.ProfileID}");
            Console.WriteLine("Are you sure you want to delete this profile? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the profile if confirmed
            if (confirmation == "yes")
            {
                Context.Profiles.Remove(profile);
                Context.SaveChanges();
                Console.WriteLine("Profile deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteProject()
    {
        try
        {
            // Step 1: Display all projects
            Reader.ReadProjects();

            // Step 2: Ask the user to choose a project to delete
            Console.WriteLine("Enter the ID of the project to delete:");
            int projectId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected project
            var project = Context.Projects.FirstOrDefault(p => p.ProjectID == projectId);
            if (project == null)
            {
                Console.WriteLine("Project not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the project with ID: {project.ProjectID}");
            Console.WriteLine("Are you sure you want to delete this project? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the project if confirmed
            if (confirmation == "yes")
            {
                Context.Projects.Remove(project);
                Context.SaveChanges();
                Console.WriteLine("Project deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteProjectDetail()
    {
        try
        {
            // Step 1: Display all project details
            Reader.ReadProjectDetails();

            // Step 2: Ask the user to choose a project detail to delete
            Console.WriteLine("Enter the ID of the project detail to delete:");
            int projectDetailId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected project detail
            var projectDetail = Context.ProjectDetails.FirstOrDefault(pd => pd.ProjectDetailID == projectDetailId);
            if (projectDetail == null)
            {
                Console.WriteLine("Project Detail not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the project detail with ID: {projectDetail.ProjectDetailID}");
            Console.WriteLine("Are you sure you want to delete this project detail? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the project detail if confirmed
            if (confirmation == "yes")
            {
                Context.ProjectDetails.Remove(projectDetail);
                Context.SaveChanges();
                Console.WriteLine("Project detail deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteRating()
    {
        try
        {
            // Step 1: Display all ratings
            Reader.ReadRatings();

            // Step 2: Ask the user to choose a rating to delete
            Console.WriteLine("Enter the ID of the rating to delete:");
            int ratingId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected rating
            var rating = Context.Ratings.FirstOrDefault(r => r.RatingID == ratingId);
            if (rating == null)
            {
                Console.WriteLine("Rating not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the rating with ID: {rating.RatingID}");
            Console.WriteLine("Are you sure you want to delete this rating? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the rating if confirmed
            if (confirmation == "yes")
            {
                Context.Ratings.Remove(rating);
                Context.SaveChanges();
                Console.WriteLine("Rating deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteRecruit()
    {
        try
        {
            // Step 1: Display all recruits
            Reader.ReadRecruits();

            // Step 2: Ask the user to choose a recruit to delete
            Console.WriteLine("Enter the ID of the recruit to delete:");
            int recruitId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected recruit
            var recruit = Context.Recruits.FirstOrDefault(r => r.RecruitID == recruitId);
            if (recruit == null)
            {
                Console.WriteLine("Recruit not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the recruit with ID: {recruit.RecruitID}");
            Console.WriteLine("Are you sure you want to delete this recruit? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the recruit if confirmed
            if (confirmation == "yes")
            {
                Context.Recruits.Remove(recruit);
                Context.SaveChanges();
                Console.WriteLine("Recruit deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteRecruitment()
    {
        try
        {
            // Step 1: Display all recruitments
            Reader.ReadRecruitments();

            // Step 2: Ask the user to choose a recruitment to delete
            Console.WriteLine("Enter the ID of the recruitment to delete:");
            int recruitmentId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected recruitment
            var recruitment = Context.Recruitments.FirstOrDefault(r => r.RecruitmentID == recruitmentId);
            if (recruitment == null)
            {
                Console.WriteLine("Recruitment not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the recruitment with ID: {recruitment.RecruitmentID}");
            Console.WriteLine("Are you sure you want to delete this recruitment? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty ;

            // Step 4: Delete the recruitment if confirmed
            if (confirmation == "yes")
            {
                Context.Recruitments.Remove(recruitment);
                Context.SaveChanges();
                Console.WriteLine("Recruitment deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteSalary()
    {
        try
        {
            // Step 1: Display all salaries
            Reader.ReadSalaries();

            // Step 2: Ask the user to choose a salary to delete
            Console.WriteLine("Enter the ID of the salary record to delete:");
            int salaryId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected salary
            var salary = Context.Salaries.FirstOrDefault(s => s.SalaryID == salaryId);
            if (salary == null)
            {
                Console.WriteLine("Salary record not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the salary record with ID: {salary.SalaryID}");
            Console.WriteLine("Are you sure you want to delete this salary record? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the salary if confirmed
            if (confirmation == "yes")
            {
                Context.Salaries.Remove(salary);
                Context.SaveChanges();
                Console.WriteLine("Salary record deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteSchedule()
    {
        try
        {
            // Step 1: Display all schedules
            Reader.ReadSchedules();

            // Step 2: Ask the user to choose a schedule to delete
            Console.WriteLine("Enter the ID of the schedule record to delete:");
            int scheduleId = Convert.ToInt32(Console.ReadLine());

            // Fetch the selected schedule
            var schedule = Context.Schedules.FirstOrDefault(s => s.EventID == scheduleId);
            if (schedule == null)
            {
                Console.WriteLine("Schedule record not found.");
                return;
            }

            // Step 3: Confirm deletion
            Console.WriteLine($"You have selected to delete the schedule record with ID: {schedule.EventID}");
            Console.WriteLine("Are you sure you want to delete this schedule record? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: Delete the schedule if confirmed
            if (confirmation == "yes")
            {
                Context.Schedules.Remove(schedule);
                Context.SaveChanges();
                Console.WriteLine("Schedule record deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

}