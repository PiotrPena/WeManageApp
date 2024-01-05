using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
public class Adder{

    private WeManageContext Context;
    public Adder(WeManageContext context){
        Context = context;
    }

    public void Process()
    {
        bool continueUsingAdder = true;

        while (continueUsingAdder)
        {
            Console.WriteLine("Select an option to proceed:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Employee Schedule");
            Console.WriteLine("3. Add Employee Development");
            Console.WriteLine("4. Add Incident");
            Console.WriteLine("5. Add Leave");
            Console.WriteLine("6. Add Profile");
            Console.WriteLine("7. Add Performance Rating");
            Console.WriteLine("8. Add Event");
            Console.WriteLine("9. Add Project");
            Console.WriteLine("10. Add Project Detail");
            Console.WriteLine("11. Add Recruit");
            Console.WriteLine("12. Add Recruitment");
            Console.WriteLine("13. Add Notification");
            Console.WriteLine("14. Add Salary");
            Console.WriteLine("15. Add Position");
            Console.WriteLine("0. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    AddEmployeeSchedule();
                    break;
                case 3:
                    AddEmployeeDevelopment();
                    break;
                case 4:
                    AddIncident();
                    break;
                case 5:
                    AddLeave();
                    break;
                case 6:
                    AddProfile();
                    break;
                case 7:
                    AddRating();
                    break;
                case 8:
                    AddSchedule();
                    break;
                case 9:
                    AddProject();
                    break;
                case 10:
                    AddProjectDetail();
                    break;
                case 11:
                    AddRecruit();
                    break;
                case 12:
                    AddRecruitment();
                    break;
                case 13:
                    AddNotification();
                    break;
                case 14:
                    AddSalary();
                    break;
                case 15:
                    AddPosition();
                    break;
                case 0:
                    continueUsingAdder = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            if (continueUsingAdder)
            {
                Console.WriteLine("Do you want to continue? (yes/no)");
                string? answer = Console.ReadLine()?.ToLower();
                continueUsingAdder = answer == "yes";
            }
        }
    }

    public Employee? CreateEmployee()
    {
        try
        {
            Console.WriteLine("Enter Employee Details:");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? string.Empty;

            Console.Write("Date of Birth (yyyy-MM-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Gender: ");
            string gender = Console.ReadLine() ?? string.Empty;

            Console.Write("Address: ");
            string address = Console.ReadLine() ?? string.Empty;

            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                Address = address
            };

            return employee;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddEmployee()
    {
        try
        {
            Employee? employee = CreateEmployee();
            if (employee == null)
            {
                throw new InvalidOperationException("Failed to create employee.");
            }

            Context.Employees.Add(employee);
            Context.SaveChanges();

            Console.WriteLine("Employee added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public EmployeeDevelopment? CreateEmployeeDevelopment()
    {
        try
        {
            Console.WriteLine("Enter Employee Development Details:");

            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employeeId))
            {
                throw new ArgumentException("Invalid Employee ID. It should be a number.");
            }

            Console.Write("Development Type: ");
            string developmentType = Console.ReadLine() ?? string.Empty;

            Console.Write("Title: ");
            string title = Console.ReadLine() ?? string.Empty;

            Console.Write("Start Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                throw new ArgumentException("Invalid Start Date format.");
            }

            Console.Write("End Date (yyyy-MM-dd, optional): ");
            string endDateInput = Console.ReadLine() ?? string.Empty;
            DateTime? endDate = string.IsNullOrEmpty(endDateInput) ? (DateTime?)null : 
                                DateTime.TryParse(endDateInput, out DateTime tempEndDate) ? tempEndDate : 
                                throw new ArgumentException("Invalid End Date format.");

            Console.Write("Provider: ");
            string provider = Console.ReadLine() ?? string.Empty;

            Console.Write("Status: ");
            string status = Console.ReadLine() ?? string.Empty;

            Console.Write("Result (optional): ");
            string result = Console.ReadLine() ?? string.Empty;

            Console.Write("Notes (optional): ");
            string notes = Console.ReadLine() ?? string.Empty;

            var employeeDevelopment = new EmployeeDevelopment
            {
                EmployeeID = employeeId,
                DevelopmentType = developmentType,
                Title = title,
                StartDate = startDate,
                EndDate = endDate,
                Provider = provider,
                Status = status,
                Result = result,
                Notes = notes
            };

            return employeeDevelopment;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddEmployeeDevelopment()
    {
        try
        {
            EmployeeDevelopment? employeeDevelopment = CreateEmployeeDevelopment();
            if (employeeDevelopment == null)
            {
                throw new InvalidOperationException("Failed to create employee development.");
            }

            Context.EmployeeDevelopments.Add(employeeDevelopment);
            Context.SaveChanges();

            Console.WriteLine("Employee development programme added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public EmployeeSchedule? CreateEmployeeSchedule()
    {
        try
        {
            Console.WriteLine("Enter Employee Schedule Details:");

            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employeeId))
            {
                throw new ArgumentException("Invalid Employee ID. It should be a number.");
            }

            Console.Write("Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                throw new ArgumentException("Invalid Date format.");
            }

            Console.Write("Start Hour (HH:mm): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan startHour))
            {
                throw new ArgumentException("Invalid Start Hour format.");
            }

            Console.Write("End Hour (HH:mm): ");
            if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan endHour))
            {
                throw new ArgumentException("Invalid End Hour format.");
            }

            var employeeSchedule = new EmployeeSchedule
            {
                EmployeeID = employeeId,
                Date = date,
                StartHour = startHour,
                EndHour = endHour
            };

            return employeeSchedule;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddEmployeeSchedule()
    {
        try
        {
            EmployeeSchedule? employeeSchedule = CreateEmployeeSchedule();
            if (employeeSchedule == null)
            {
                throw new InvalidOperationException("Failed to create employee schedule.");
            }

            Context.EmployeeSchedules.Add(employeeSchedule);
            Context.SaveChanges();

            Console.WriteLine("Employee Schedule record added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Incident? CreateIncident()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Add New Incident");

                // EmployeeID
                Console.Write("Employee ID: ");
                if (!int.TryParse(Console.ReadLine(), out int employeeId))
                {
                    throw new ArgumentException("Invalid Employee ID. It should be a number.");
                }

                // IncidentDate
                Console.Write("Incident Date (yyyy-MM-dd): ");
                DateTime incidentDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                // IncidentType
                Console.Write("Incident Type: ");
                string incidentType = Console.ReadLine() ?? throw new ArgumentException("Incident Type cannot be empty.");

                // Description
                Console.Write("Description: ");
                string description = Console.ReadLine() ?? throw new ArgumentException("Description cannot be empty.");

                // SeverityLevel
                Console.Write("Severity Level: ");
                string severityLevel = Console.ReadLine() ?? throw new ArgumentException("Severity Level cannot be empty.");

                // ReportedDate
                Console.Write("Reported Date (yyyy-MM-dd): ");
                DateTime reportedDate = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                // ActionTaken (optional)
                Console.Write("Action Taken (optional): ");
                string actionTaken = Console.ReadLine() ?? string.Empty;

                // Status
                Console.Write("Status: ");
                string status = Console.ReadLine() ?? throw new ArgumentException("Status cannot be empty.");

                // ResolutionDate (optional)
                Console.Write("Resolution Date (yyyy-MM-dd) (optional): ");
                DateTime.TryParse(Console.ReadLine(), out DateTime resolutionDate);

                // Notes (optional)
                Console.Write("Notes (optional): ");
                string notes = Console.ReadLine() ?? string.Empty;

                // Creating Incident object
                Incident incident = new Incident
                {
                    EmployeeID = employeeId,
                    IncidentDate = incidentDate,
                    IncidentType = incidentType,
                    Description = description,
                    SeverityLevel = severityLevel,
                    ReportedDate = reportedDate,
                    ActionTaken = actionTaken,
                    Status = status,
                    ResolutionDate = resolutionDate != DateTime.MinValue ? resolutionDate : null, // If date is not entered, set to null
                    Notes = notes
                };

                return incident;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Please try again.");
                return null;
            }
        }
    }

    public void AddIncident()
    {
        try
        {
            Incident? incident = CreateIncident();
            if (incident == null)
            {
                throw new InvalidOperationException("Failed to create incident.");
            }

            Context.Incidents.Add(incident);
            Context.SaveChanges();
            Console.WriteLine("Incident added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Leave? CreateLeave()
    {
        try
        {
            Console.WriteLine("Enter Leave Details:");

            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employeeId))
            {
                throw new ArgumentException("Invalid Employee ID. It should be a number.");
            }

            Console.Write("Start Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                throw new ArgumentException("Invalid Start Date format.");
            }

            Console.Write("End Date (yyyy-MM-dd) [optional]: ");
            string endDateInput = Console.ReadLine() ?? string.Empty;
            DateTime? endDate = string.IsNullOrWhiteSpace(endDateInput) ? (DateTime?)null : DateTime.Parse(endDateInput);

            Console.Write("Type Of Leave: ");
            string typeOfLeave = Console.ReadLine() ?? throw new InvalidOperationException("Type Of Leave is required");

            var leave = new Leave
            {
                EmployeeID = employeeId,
                StartDate = startDate,
                EndDate = endDate,
                TypeOfLeave = typeOfLeave
            };

            return leave;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddLeave()
    {
        try
        {
            Leave? leave = CreateLeave();
            if (leave == null)
            {
                throw new InvalidOperationException("Failed to create leave.");
            }

            Context.Leaves.Add(leave);
            Context.SaveChanges();

            Console.WriteLine("Leave record added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Notification? CreateNotification()
    {
        try
        {
            Console.WriteLine("Enter Notification Details:");

            Console.Write("Sender Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int senderEmployeeId))
            {
                throw new ArgumentException("Invalid Sender Employee ID. It should be a number.");
            }

            Console.Write("Notification Content: ");
            string notificationContent = Console.ReadLine() ?? throw new InvalidOperationException("Notification Content is required");
            
            DateTime timestamp;
            Console.Write("Enter timestamp (yyyy-MM-dd HH:mm): ");

            // Try to parse the input with the specified format
            bool validDate = DateTime.TryParse(Console.ReadLine(), out timestamp);
            if (!validDate)
            {
                throw new ArgumentException("Invalid format. Please enter the timestamp in the format 'yyyy-MM-dd HH:mm'.");
            }

            var notification = new Notification
            {
                SenderEmployeeID = senderEmployeeId,
                NotificationContent = notificationContent,
                Timestamp = timestamp
            };

            return notification;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddNotification()
    {
        try
        {
            Notification? notification = CreateNotification();
            if (notification == null)
            {
                throw new InvalidOperationException("Failed to create notification.");
            }

            Context.Notifications.Add(notification);
            Context.SaveChanges();

            Console.WriteLine("Notification record added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Position? CreatePosition()
    {
        try
        {
            Console.WriteLine("Enter Position Details:");

            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employeeId))
            {
                throw new ArgumentException("Invalid Employee ID. It should be a number.");
            }

            Console.Write("Start Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                throw new ArgumentException("Invalid Start Date format.");
            }

            Console.Write("End Date (yyyy-MM-dd) [Optional]: ");
            var endDateInput = Console.ReadLine();
            DateTime? endDate = string.IsNullOrEmpty(endDateInput) ? (DateTime?)null : DateTime.Parse(endDateInput);

            Console.Write("Position Name (max 100 characters): ");
            string positionName = Console.ReadLine() ?? throw new InvalidOperationException("Position Name is required");

            var position = new Position
            {
                EmployeeID = employeeId,
                StartDate = startDate,
                EndDate = endDate,
                PositionName = positionName
            };

            return position;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddPosition()
    {
        try
        {
            Position? position = CreatePosition();
            if (position == null)
            {
                throw new InvalidOperationException("Failed to create position.");
            }

            Context.Positions.Add(position);
            Context.SaveChanges();

            Console.WriteLine("Position record added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Profile? CreateProfile()
    {
        try
        {
            Console.WriteLine("Enter Profile Details:");

            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employeeId))
            {
                throw new ArgumentException("Invalid Employee ID. It should be a number.");
            }

            Console.Write("Activity Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime activityDate))
            {
                throw new ArgumentException("Invalid Activity Date format.");
            }

            Console.Write("Activity Type (max 255 characters): ");
            string activityType = Console.ReadLine() ?? throw new InvalidOperationException("Activity Type is required");

            Console.Write("Activity Description: ");
            string activityDescription = Console.ReadLine() ?? throw new InvalidOperationException("Activity Description is required");

            Console.Write("Impact: ");
            string impact = Console.ReadLine() ?? throw new InvalidOperationException("Impact is required");

            Console.Write("Visibility Level: ");
            string visibilityLevel = Console.ReadLine() ?? throw new InvalidOperationException("Visibility Level is required");

            Console.Write("Assessment: ");
            string assessment = Console.ReadLine() ?? throw new InvalidOperationException("Assessment is required");

            Console.Write("Notes: ");
            string notes = Console.ReadLine() ?? throw new InvalidOperationException("Notes are required");

            var profile = new Profile
            {
                EmployeeID = employeeId,
                ActivityDate = activityDate,
                ActivityType = activityType,
                ActivityDescription = activityDescription,
                Impact = impact,
                VisibilityLevel = visibilityLevel,
                Assessment = assessment,
                Notes = notes
            };

            return profile;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddProfile()
    {
        try
        {
            Profile? profile = CreateProfile();
            if (profile == null)
            {
                throw new InvalidOperationException("Failed to create profile.");
            }

            Context.Profiles.Add(profile);
            Context.SaveChanges();

            Console.WriteLine("Profile record added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Project? CreateProject()
    {
        try
        {
            Console.WriteLine("Enter Project Details:");

            Console.Write("Project Name (max 200 characters): ");
            string projectName = Console.ReadLine() ?? throw new InvalidOperationException("Project Name is required");

            Console.Write("Project Description (max 500 characters): ");
            string projectDescription = Console.ReadLine() ?? throw new InvalidOperationException("Project Description is required");

            Console.Write("Start Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                throw new ArgumentException("Invalid Start Date format.");
            }

            Console.Write("End Date (yyyy-MM-dd) [Optional]: ");
            DateTime? endDate = null;
            string endDateInput = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(endDateInput))
            {
                if (!DateTime.TryParse(endDateInput, out DateTime parsedEndDate))
                {
                    throw new ArgumentException("Invalid End Date format.");
                }
                endDate = parsedEndDate;
            }

            Console.Write("Budget (Optional): ");
            decimal? budget = null;
            string budgetInput = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(budgetInput))
            {
                if (!decimal.TryParse(budgetInput, out decimal parsedBudget))
                {
                    throw new ArgumentException("Invalid Budget format.");
                }
                budget = parsedBudget;
            }

            Console.Write("Status (max 100 characters) [Optional]: ");
            string status = Console.ReadLine() ?? string.Empty;

            Console.Write("Manager Employee ID (Optional): ");
            int? managerEmployeeId = null;
            string managerEmployeeIdInput = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(managerEmployeeIdInput))
            {
                if (!int.TryParse(managerEmployeeIdInput, out int parsedManagerEmployeeId))
                {
                    throw new ArgumentException("Invalid Manager Employee ID format.");
                }
                managerEmployeeId = parsedManagerEmployeeId;
            }

            var project = new Project
            {
                ProjectName = projectName,
                ProjectDescription = projectDescription,
                StartDate = startDate,
                EndDate = endDate,
                Budget = budget,
                Status = status,
                ManagerEmployeeID = managerEmployeeId
            };

            return project;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddProject()
    {
        try
        {
            Project? project = CreateProject();
            if (project == null)
            {
                throw new InvalidOperationException("Failed to create project.");
            }

            Context.Projects.Add(project);
            Context.SaveChanges();

            Console.WriteLine("Project record added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public ProjectDetail? CreateProjectDetail()
    {
        try
        {
            Console.WriteLine("Enter Project Detail:");

            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employeeId))
            {
                throw new ArgumentException("Invalid Employee ID. It should be a number.");
            }

            Console.Write("Project ID: ");
            if (!int.TryParse(Console.ReadLine(), out int projectId))
            {
                throw new ArgumentException("Invalid Project ID. It should be a number.");
            }

            Console.Write("Role (max 100 characters): ");
            string role = Console.ReadLine() ?? throw new InvalidOperationException("Role is required");

            Console.Write("Join Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime joinDate))
            {
                throw new ArgumentException("Invalid Join Date format.");
            }

            Console.Write("Leave Date (yyyy-MM-dd) [Optional]: ");
            DateTime? leaveDate = null;
            string leaveDateInput = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(leaveDateInput))
            {
                if (!DateTime.TryParse(leaveDateInput, out DateTime parsedLeaveDate))
                {
                    throw new ArgumentException("Invalid Leave Date format.");
                }
                leaveDate = parsedLeaveDate;
            }

            Console.Write("Additional Info [Optional]: ");
            string additionalInfo = Console.ReadLine() ?? string.Empty;

            var projectDetail = new ProjectDetail
            {
                EmployeeID = employeeId,
                ProjectID = projectId,
                Role = role,
                JoinDate = joinDate,
                LeaveDate = leaveDate ?? default(DateTime), // Use default value if null
                AdditionalInfo = additionalInfo
            };

            return projectDetail;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddProjectDetail()
    {
        try
        {
            ProjectDetail? projectDetail = CreateProjectDetail();
            if (projectDetail == null)
            {
                throw new InvalidOperationException("Failed to create project detail.");
            }

            Context.ProjectDetails.Add(projectDetail);
            Context.SaveChanges();

            Console.WriteLine("Project Detail record added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Rating? CreateRating()
    {
        try
        {
            Console.WriteLine("Enter Rating Details:");

            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employeeId))
            {
                throw new ArgumentException("Invalid Employee ID. It should be a number.");
            }

            Console.Write("Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                throw new ArgumentException("Invalid Date format.");
            }

            Console.Write("Performance Rating (optional, numeric): ");
            string performanceRatingInput = Console.ReadLine() ?? string.Empty;
            int? performanceRating = null;
            if (!string.IsNullOrWhiteSpace(performanceRatingInput))
            {
                if (!int.TryParse(performanceRatingInput, out int parsedPerformanceRating))
                {
                    throw new ArgumentException("Invalid Performance Rating format. It should be a number.");
                }
                performanceRating = parsedPerformanceRating;
            }

            var rating = new Rating
            {
                EmployeeID = employeeId,
                Date = date,
                PerformanceRating = performanceRating
            };

            return rating;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddRating()
    {
        try
        {
            Rating? rating = CreateRating();
            if (rating == null)
            {
                throw new InvalidOperationException("Failed to create rating.");
            }

            Context.Ratings.Add(rating);
            Context.SaveChanges();

            Console.WriteLine("Rating record added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Recruit? CreateRecruit()
    {
        try
        {
            Console.WriteLine("Enter Recruit Details:");

            Console.Write("First Name: ");
            string? firstName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First Name is required.");
            }

            Console.Write("Last Name: ");
            string? lastName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last Name is required.");
            }

            Console.Write("Date of Birth (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
            {
                throw new ArgumentException("Invalid Date of Birth format.");
            }

            Console.Write("Email: ");
            string? email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email is required.");
            }

            Console.Write("Gender: ");
            string? gender = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(gender))
            {
                throw new ArgumentException("Gender is required.");
            }

            Console.Write("Address: ");
            string? address = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address is required.");
            }

            var recruit = new Recruit
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Email = email,
                Gender = gender,
                Address = address
            };

            return recruit;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddRecruit()
    {
        try
        {
            Recruit? recruit = CreateRecruit();
            if (recruit == null)
            {
                throw new InvalidOperationException("Failed to create recruit.");
            }

            Context.Recruits.Add(recruit);
            Context.SaveChanges();

            Console.WriteLine("Recruit record added successfully.");      
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Recruitment? CreateRecruitment()
    {
        try
        {
            Console.WriteLine("Enter Recruitment Details:");

            Console.Write("Recruit ID: ");
            if (!int.TryParse(Console.ReadLine(), out int recruitId))
            {
                throw new ArgumentException("Invalid Recruit ID. It should be a number.");
            }

            Console.Write("Position Name: ");
            string? positionName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(positionName))
            {
                throw new ArgumentException("Position Name is required.");
            }

            Console.Write("Application Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime applicationDate))
            {
                throw new ArgumentException("Invalid Application Date format.");
            }

            Console.Write("Status: ");
            string? status = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Status is required.");
            }

            Console.Write("Interview Date (yyyy-MM-dd), optional: ");
            DateTime? interviewDate = null;
            string interviewDateString = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(interviewDateString))
            {
                if (!DateTime.TryParse(interviewDateString, out DateTime parsedDate))
                {
                    throw new ArgumentException("Invalid Interview Date format.");
                }
                interviewDate = parsedDate;
            }

            Console.Write("Notes (optional): ");
            string? notes = Console.ReadLine();

            var recruitment = new Recruitment
            {
                RecruitID = recruitId,
                PositionName = positionName,
                ApplicationDate = applicationDate,
                Status = status,
                InterviewDate = interviewDate ?? default(DateTime),
                Notes = notes
            };

            return recruitment;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddRecruitment()
    {
        try
        {
            Recruitment? recruitment = CreateRecruitment();
            if (recruitment == null)
            {
                throw new InvalidOperationException("Failed to create recruitment.");
            }

            Context.Recruitments.Add(recruitment);
            Context.SaveChanges();

            Console.WriteLine("Recruitment record added successfully.");      
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Salary? CreateSalary()
    {
        try
        {
            Console.WriteLine("Enter Salary Details:");

            Console.Write("Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employeeId))
            {
                throw new ArgumentException("Invalid Employee ID. It should be a number.");
            }

            Console.Write("Monthly Salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal monthlySalary))
            {
                throw new ArgumentException("Invalid Monthly Salary. It should be a decimal number.");
            }

            Console.Write("Start Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                throw new ArgumentException("Invalid Start Date format.");
            }

            Console.Write("End Date (yyyy-MM-dd), optional: ");
            DateTime? endDate = null;
            string endDateString = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(endDateString))
            {
                if (!DateTime.TryParse(endDateString, out DateTime parsedDate))
                {
                    throw new ArgumentException("Invalid End Date format.");
                }
                endDate = parsedDate;
            }

            var salary = new Salary
            {
                EmployeeID = employeeId,
                MonthlySalary = monthlySalary,
                StartDate = startDate,
                EndDate = endDate
            };

            return salary;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddSalary()
    {
        try
        {
            Salary? salary = CreateSalary();
            if (salary == null)
            {
                throw new InvalidOperationException("Failed to create salary.");
            }

            Context.Salaries.Add(salary);
            Context.SaveChanges();

            Console.WriteLine("Salary record added successfully.");     
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public Schedule? CreateSchedule()
    {
        try
        {
            Console.WriteLine("Enter Schedule Event Details:");

            Console.Write("Event Name: ");
            string eventName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(eventName))
            {
                throw new ArgumentException("Event Name is required.");
            }

            Console.Write("Start Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                throw new ArgumentException("Invalid Start Date format.");
            }

            Console.Write("End Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
            {
                throw new ArgumentException("Invalid End Date format.");
            }

            Console.Write("Room ID: ");
            string roomId = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(roomId))
            {
                throw new ArgumentException("Room ID is required.");
            }

            Console.Write("Host Employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int hostEmployeeId))
            {
                throw new ArgumentException("Invalid Host Employee ID. It should be a number.");
            }

            Console.Write("Event Type: ");
            string eventType = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(eventType))
            {
                throw new ArgumentException("Event Type is required.");
            }

            Console.Write("Is Mandatory (true/false): ");
            if (!bool.TryParse(Console.ReadLine(), out bool isMandatory))
            {
                throw new ArgumentException("Invalid input for Is Mandatory. It should be true or false.");
            }

            Console.Write("Description (optional): ");
            string description = Console.ReadLine() ?? string.Empty;

            var schedule = new Schedule
            {
                EventName = eventName,
                StartDate = startDate,
                EndDate = endDate,
                RoomID = roomId,
                HostEmployeeID = hostEmployeeId,
                EventType = eventType,
                IsMandatory = isMandatory,
                Description = description
            };

            return schedule;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddSchedule()
    {
        try
        {
            Schedule? schedule = CreateSchedule();
            if (schedule == null)
            {
                throw new InvalidOperationException("Failed to create schedule.");
            }

            Context.Schedules.Add(schedule);
            Context.SaveChanges();

            Console.WriteLine("Schedule event added successfully.");     
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }


}