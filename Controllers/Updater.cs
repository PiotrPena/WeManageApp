using Microsoft.EntityFrameworkCore;
public class Updater{

    private WeManageContext Context;
    private Reader Reader;
    private Adder Adder;
    public Updater(WeManageContext context){
        Context = context;
        Reader = new Reader(context);
        Adder = new Adder(context); 
    }

    public void Process()
    {
        bool continueUsingUpdater = true;

        while (continueUsingUpdater)
        {
            Console.WriteLine("Select an option to proceed:");
            Console.WriteLine("1. Update Employee");
            Console.WriteLine("2. Update Employee Schedule");
            Console.WriteLine("3. Update Employee Development");
            Console.WriteLine("4. Update Incident");
            Console.WriteLine("5. Update Leave");
            Console.WriteLine("6. Update Profile");
            Console.WriteLine("7. Update Performance Rating");
            Console.WriteLine("8. Update Event");
            Console.WriteLine("9. Update Project");
            Console.WriteLine("10. Update Project Detail");
            Console.WriteLine("11. Update Recruit");
            Console.WriteLine("12. Update Recruitment");
            Console.WriteLine("13. Update Notification");
            Console.WriteLine("14. Update Salary");
            Console.WriteLine("15. Update Position");
            Console.WriteLine("0. Exit");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input, please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    UpdateEmployee();
                    break;
                case 2:
                    UpdateEmployeeSchedule();
                    break;
                case 3:
                    UpdateEmployeeDevelopment();
                    break;
                case 4:
                    UpdateIncident();
                    break;
                case 5:
                    UpdateLeave();
                    break;
                case 6:
                    UpdateProfile();
                    break;
                case 7:
                    UpdateRating();
                    break;
                case 8:
                    UpdateSchedule();
                    break;
                case 9:
                    UpdateProject();
                    break;
                case 10:
                    UpdateProjectDetail();
                    break;
                case 11:
                    UpdateRecruit();
                    break;
                case 12:
                    UpdateRecruitment();
                    break;
                case 13:
                    UpdateNotification();
                    break;
                case 14:
                    UpdateSalary();
                    break;
                case 15:
                    UpdatePosition();
                    break;
                case 0:
                    continueUsingUpdater = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            if (continueUsingUpdater)
            {
                Console.WriteLine("Do you want to continue updating? (yes/no)");
                string? answer = Console.ReadLine()?.ToLower();
                continueUsingUpdater = answer == "yes";
            }
        }
    }


     public void UpdateEmployee()
    {
        try
        {
            // Display all employees
            Reader.ReadEmployees();

            Console.WriteLine("Enter the ID of the Employee you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int employeeId))
            {
                throw new ArgumentException("Invalid Employee ID. It should be a number.");
            }

            // Find the employee to update
            var existingEmployee = Context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            // Use Adder's CreateEmployee method to create a new employee object
            var updatedEmployee = Adder.CreateEmployee();
            if (updatedEmployee == null)
            {
                throw new InvalidOperationException("Failed to create employee record.");
            }

            // Update the existing employee record
            existingEmployee.FirstName = updatedEmployee.FirstName;
            existingEmployee.LastName = updatedEmployee.LastName;
            existingEmployee.Email = updatedEmployee.Email;
            existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;
            existingEmployee.Gender = updatedEmployee.Gender;
            existingEmployee.Address = updatedEmployee.Address;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Employee updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateEmployeeDevelopment()
    {
        try
        {
            // Display all employee developments
            Reader.ReadEmployeeDevelopments();

            Console.WriteLine("Enter the ID of the Employee Development record you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int developmentId))
            {
                throw new ArgumentException("Invalid Employee Development ID. It should be a number.");
            }

            // Find the employee development record to update
            var existingDevelopment = Context.EmployeeDevelopments.FirstOrDefault(ed => ed.DevelopmentID == developmentId);
            if (existingDevelopment == null)
            {
                Console.WriteLine("Employee Development record not found.");
                return;
            }

            // Use Adder's CreateEmployeeDevelopment method to create a new record
            var updatedDevelopment = Adder.CreateEmployeeDevelopment();
            if (updatedDevelopment == null)
            {
                throw new InvalidOperationException("Failed to create employee development record.");
            }

            // Update the existing record
            existingDevelopment.EmployeeID = updatedDevelopment.EmployeeID;
            existingDevelopment.DevelopmentType = updatedDevelopment.DevelopmentType;
            existingDevelopment.Title = updatedDevelopment.Title;
            existingDevelopment.StartDate = updatedDevelopment.StartDate;
            existingDevelopment.EndDate = updatedDevelopment.EndDate;
            existingDevelopment.Provider = updatedDevelopment.Provider;
            existingDevelopment.Status = updatedDevelopment.Status;
            existingDevelopment.Result = updatedDevelopment.Result;
            existingDevelopment.Notes = updatedDevelopment.Notes;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Employee Development record updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateEmployeeSchedule()
    {
        try
        {
            // Display all employee schedules
            Reader.ReadEmployeeSchedules();

            Console.WriteLine("Enter the ID of the Employee Schedule you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int scheduleId))
            {
                throw new ArgumentException("Invalid Employee Schedule ID. It should be a number.");
            }

            // Find the employee schedule to update
            var existingSchedule = Context.EmployeeSchedules.FirstOrDefault(es => es.EmployeeScheduleID == scheduleId);
            if (existingSchedule == null)
            {
                Console.WriteLine("Employee Schedule not found.");
                return;
            }

            // Use Adder's CreateEmployeeSchedule method to create a new schedule
            var updatedSchedule = Adder.CreateEmployeeSchedule();
            if (updatedSchedule == null)
            {
                throw new InvalidOperationException("Failed to create employee schedule.");
            }

            // Update the existing schedule
            existingSchedule.EmployeeID = updatedSchedule.EmployeeID;
            existingSchedule.Date = updatedSchedule.Date;
            existingSchedule.StartHour = updatedSchedule.StartHour;
            existingSchedule.EndHour = updatedSchedule.EndHour;
            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Employee Schedule updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateIncident()
    {
        try
        {
            // Display all incidents
            Reader.ReadIncidents();

            Console.WriteLine("Enter the ID of the Incident you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int incidentId))
            {
                throw new ArgumentException("Invalid Incident ID. It should be a number.");
            }

            // Find the incident to update
            var existingIncident = Context.Incidents.FirstOrDefault(i => i.IncidentID == incidentId);
            if (existingIncident == null)
            {
                Console.WriteLine("Incident not found.");
                return;
            }

            // Use Adder's CreateIncident method to create a new incident
            var updatedIncident = Adder.CreateIncident();
            if (updatedIncident == null)
            {
                throw new InvalidOperationException("Failed to create incident.");
            }

            // Update the existing record with the new values
            existingIncident.EmployeeID = updatedIncident.EmployeeID;
            existingIncident.IncidentDate = updatedIncident.IncidentDate;
            existingIncident.IncidentType = updatedIncident.IncidentType;
            existingIncident.Description = updatedIncident.Description;
            existingIncident.SeverityLevel = updatedIncident.SeverityLevel;
            existingIncident.ReportedDate = updatedIncident.ReportedDate;
            existingIncident.ActionTaken = updatedIncident.ActionTaken;
            existingIncident.Status = updatedIncident.Status;
            existingIncident.ResolutionDate = updatedIncident.ResolutionDate;
            existingIncident.Notes = updatedIncident.Notes;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Incident updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateLeave()
    {
        try
        {
            // Display all leaves
            Reader.ReadLeaves();

            Console.WriteLine("Enter the ID of the Leave you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int leaveId))
            {
                throw new ArgumentException("Invalid Leave ID. It should be a number.");
            }

            // Find the leave to update
            var existingLeave = Context.Leaves.FirstOrDefault(l => l.LeaveID == leaveId);
            if (existingLeave == null)
            {
                Console.WriteLine("Leave not found.");
                return;
            }

            // Use Adder's CreateLeave method to create a new leave
            var updatedLeave = Adder.CreateLeave();
            if (updatedLeave == null)
            {
                throw new InvalidOperationException("Failed to create leave.");
            }

            // Update the existing record with the new values
            existingLeave.EmployeeID = updatedLeave.EmployeeID;
            existingLeave.StartDate = updatedLeave.StartDate;
            existingLeave.EndDate = updatedLeave.EndDate;
            existingLeave.TypeOfLeave = updatedLeave.TypeOfLeave;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Leave updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateNotification()
    {
        try
        {
            // Display all notifications
            Reader.ReadNotifications();

            Console.WriteLine("Enter the ID of the Notification you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int notificationId))
            {
                throw new ArgumentException("Invalid Notification ID. It should be a number.");
            }

            // Find the notification to update
            var existingNotification = Context.Notifications.FirstOrDefault(n => n.NotificationID == notificationId);
            if (existingNotification == null)
            {
                Console.WriteLine("Notification not found.");
                return;
            }

            // Use Adder's CreateNotification method to create a new notification
            var updatedNotification = Adder.CreateNotification();
            if (updatedNotification == null)
            {
                throw new InvalidOperationException("Failed to create notification.");
            }

            // Update the existing record with the new values
            existingNotification.SenderEmployeeID = updatedNotification.SenderEmployeeID;
            existingNotification.NotificationContent = updatedNotification.NotificationContent;
            existingNotification.Timestamp = updatedNotification.Timestamp;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Notification updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdatePosition()
    {
        try
        {
            // Display all positions
            Reader.ReadPositions();

            Console.WriteLine("Enter the ID of the Position you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int positionId))
            {
                throw new ArgumentException("Invalid Position ID. It should be a number.");
            }

            // Find the position to update
            var existingPosition = Context.Positions.FirstOrDefault(p => p.PositionID == positionId);
            if (existingPosition == null)
            {
                Console.WriteLine("Position not found.");
                return;
            }

            // Use Adder's CreatePosition method to create a new position
            var updatedPosition = Adder.CreatePosition();
            if (updatedPosition == null)
            {
                throw new InvalidOperationException("Failed to create position.");
            }

            // Update the existing record with the new values
            existingPosition.EmployeeID = updatedPosition.EmployeeID;
            existingPosition.StartDate = updatedPosition.StartDate;
            existingPosition.EndDate = updatedPosition.EndDate;
            existingPosition.PositionName = updatedPosition.PositionName;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Position updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateProfile()
    {
        try
        {
            // Display all profiles
            Reader.ReadProfiles();

            Console.WriteLine("Enter the ID of the Profile you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int profileId))
            {
                throw new ArgumentException("Invalid Profile ID. It should be a number.");
            }

            // Find the profile to update
            var existingProfile = Context.Profiles.FirstOrDefault(p => p.ProfileID == profileId);
            if (existingProfile == null)
            {
                Console.WriteLine("Profile not found.");
                return;
            }

            // Use Adder's CreateProfile method to create a new profile
            var updatedProfile = Adder.CreateProfile();
            if (updatedProfile == null)
            {
                throw new InvalidOperationException("Failed to create profile.");
            }

            // Update the existing record with the new values
            existingProfile.EmployeeID = updatedProfile.EmployeeID;
            existingProfile.ActivityDate = updatedProfile.ActivityDate;
            existingProfile.ActivityType = updatedProfile.ActivityType;
            existingProfile.ActivityDescription = updatedProfile.ActivityDescription;
            existingProfile.Impact = updatedProfile.Impact;
            existingProfile.VisibilityLevel = updatedProfile.VisibilityLevel;
            existingProfile.Assessment = updatedProfile.Assessment;
            existingProfile.Notes = updatedProfile.Notes;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Profile updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateProject()
    {
        try
        {
            // Display all projects
            Reader.ReadProjects();

            Console.WriteLine("Enter the ID of the Project you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int projectId))
            {
                throw new ArgumentException("Invalid Project ID. It should be a number.");
            }

            // Find the project to update
            var existingProject = Context.Projects.FirstOrDefault(p => p.ProjectID == projectId);
            if (existingProject == null)
            {
                Console.WriteLine("Project not found.");
                return;
            }

            // Use Adder's CreateProject method to create a new project
            var updatedProject = Adder.CreateProject();
            if (updatedProject == null)
            {
                throw new InvalidOperationException("Failed to create project.");
            }

            // Update the existing record with the new values
            existingProject.ProjectName = updatedProject.ProjectName;
            existingProject.ProjectDescription = updatedProject.ProjectDescription;
            existingProject.StartDate = updatedProject.StartDate;
            existingProject.EndDate = updatedProject.EndDate;
            existingProject.Budget = updatedProject.Budget;
            existingProject.Status = updatedProject.Status;
            existingProject.ManagerEmployeeID = updatedProject.ManagerEmployeeID;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Project updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateProjectDetail()
    {
        try
        {
            // Display all project details
            Reader.ReadProjectDetails();

            Console.WriteLine("Enter the ID of the Project Detail you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int projectDetailId))
            {
                throw new ArgumentException("Invalid Project Detail ID. It should be a number.");
            }

            // Find the project detail to update
            var existingProjectDetail = Context.ProjectDetails.FirstOrDefault(pd => pd.ProjectDetailID == projectDetailId);
            if (existingProjectDetail == null)
            {
                Console.WriteLine("Project Detail not found.");
                return;
            }

            // Use Adder's CreateProjectDetail method to create a new project detail
            var updatedProjectDetail = Adder.CreateProjectDetail();
            if (updatedProjectDetail == null)
            {
                throw new InvalidOperationException("Failed to create project detail.");
            }

            // Update the existing record with the new values
            existingProjectDetail.EmployeeID = updatedProjectDetail.EmployeeID;
            existingProjectDetail.ProjectID = updatedProjectDetail.ProjectID;
            existingProjectDetail.Role = updatedProjectDetail.Role;
            existingProjectDetail.JoinDate = updatedProjectDetail.JoinDate;
            existingProjectDetail.LeaveDate = updatedProjectDetail.LeaveDate;
            existingProjectDetail.AdditionalInfo = updatedProjectDetail.AdditionalInfo;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Project Detail updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateRating()
    {
        try
        {
            // Display all ratings
            Reader.ReadRatings();

            Console.WriteLine("Enter the ID of the Rating you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int ratingId))
            {
                throw new ArgumentException("Invalid Rating ID. It should be a number.");
            }

            // Find the rating to update
            var existingRating = Context.Ratings.FirstOrDefault(r => r.RatingID == ratingId);
            if (existingRating == null)
            {
                Console.WriteLine("Rating not found.");
                return;
            }

            // Use Adder's CreateRating method to create a new rating
            var updatedRating = Adder.CreateRating();
            if (updatedRating == null)
            {
                throw new InvalidOperationException("Failed to create rating.");
            }

            // Update the existing record with the new values
            existingRating.EmployeeID = updatedRating.EmployeeID;
            existingRating.Date = updatedRating.Date;
            existingRating.PerformanceRating = updatedRating.PerformanceRating;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Rating updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateRecruit()
    {
        try
        {
            // Display all recruits
            Reader.ReadRecruits();

            Console.WriteLine("Enter the ID of the Recruit you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int recruitId))
            {
                throw new ArgumentException("Invalid Recruit ID. It should be a number.");
            }

            // Find the recruit to update
            var existingRecruit = Context.Recruits.FirstOrDefault(r => r.RecruitID == recruitId);
            if (existingRecruit == null)
            {
                Console.WriteLine("Recruit not found.");
                return;
            }

            // Use Adder's CreateRecruit method to create a new recruit
            var updatedRecruit = Adder.CreateRecruit();
            if (updatedRecruit == null)
            {
                throw new InvalidOperationException("Failed to create recruit.");
            }

            // Update the existing record with the new values
            existingRecruit.FirstName = updatedRecruit.FirstName;
            existingRecruit.LastName = updatedRecruit.LastName;
            existingRecruit.DateOfBirth = updatedRecruit.DateOfBirth;
            existingRecruit.Email = updatedRecruit.Email;
            existingRecruit.Gender = updatedRecruit.Gender;
            existingRecruit.Address = updatedRecruit.Address;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Recruit updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateRecruitment()
    {
        try
        {
            // Display all recruitment records
            Reader.ReadRecruitments();

            Console.WriteLine("Enter the ID of the Recruitment record you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int recruitmentId))
            {
                throw new ArgumentException("Invalid Recruitment ID. It should be a number.");
            }

            // Find the recruitment record to update
            var existingRecruitment = Context.Recruitments.FirstOrDefault(r => r.RecruitmentID == recruitmentId);
            if (existingRecruitment == null)
            {
                Console.WriteLine("Recruitment record not found.");
                return;
            }

            // Use Adder's CreateRecruitment method to create a new recruitment record
            var updatedRecruitment = Adder.CreateRecruitment();
            if (updatedRecruitment == null)
            {
                throw new InvalidOperationException("Failed to create recruitment record.");
            }

            // Update the existing record with the new values
            existingRecruitment.RecruitID = updatedRecruitment.RecruitID;
            existingRecruitment.PositionName = updatedRecruitment.PositionName;
            existingRecruitment.ApplicationDate = updatedRecruitment.ApplicationDate;
            existingRecruitment.Status = updatedRecruitment.Status;
            existingRecruitment.InterviewDate = updatedRecruitment.InterviewDate;
            existingRecruitment.Notes = updatedRecruitment.Notes;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Recruitment record updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateSalary()
    {
        try
        {
            // Display all salary records
            Reader.ReadSalaries();

            Console.WriteLine("Enter the ID of the Salary record you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int salaryId))
            {
                throw new ArgumentException("Invalid Salary ID. It should be a number.");
            }

            // Find the salary record to update
            var existingSalary = Context.Salaries.FirstOrDefault(s => s.SalaryID == salaryId);
            if (existingSalary == null)
            {
                Console.WriteLine("Salary record not found.");
                return;
            }

            // Use Adder's CreateSalary method to create a new salary record
            var updatedSalary = Adder.CreateSalary();
            if (updatedSalary == null)
            {
                throw new InvalidOperationException("Failed to create salary record.");
            }

            // Update the existing record with the new values
            existingSalary.EmployeeID = updatedSalary.EmployeeID;
            existingSalary.MonthlySalary = updatedSalary.MonthlySalary;
            existingSalary.StartDate = updatedSalary.StartDate;
            existingSalary.EndDate = updatedSalary.EndDate;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Salary record updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void UpdateSchedule()
    {
        try
        {
            // Display all schedule records
            Reader.ReadSchedules();

            Console.WriteLine("Enter the ID of the Schedule record you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int eventId))
            {
                throw new ArgumentException("Invalid Event ID. It should be a number.");
            }

            // Find the schedule record to update
            var existingSchedule = Context.Schedules.FirstOrDefault(s => s.EventID == eventId);
            if (existingSchedule == null)
            {
                Console.WriteLine("Schedule record not found.");
                return;
            }

            // Use Adder's CreateSchedule method to create a new schedule record
            var updatedSchedule = Adder.CreateSchedule();
            if (updatedSchedule == null)
            {
                throw new InvalidOperationException("Failed to create schedule record.");
            }

            // Update the existing record with the new values
            existingSchedule.EventName = updatedSchedule.EventName;
            existingSchedule.StartDate = updatedSchedule.StartDate;
            existingSchedule.EndDate = updatedSchedule.EndDate;
            existingSchedule.RoomID = updatedSchedule.RoomID;
            existingSchedule.Description = updatedSchedule.Description;
            existingSchedule.HostEmployeeID = updatedSchedule.HostEmployeeID;
            existingSchedule.EventType = updatedSchedule.EventType;
            existingSchedule.IsMandatory = updatedSchedule.IsMandatory;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Schedule record updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }


}