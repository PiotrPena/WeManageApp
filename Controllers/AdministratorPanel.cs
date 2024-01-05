public class AdministratorPanel : Panel
{
    public AdministratorPanel(User user, WeManageContext context) : base(user, context)
    {
    }

    public override void Process()
    {
        bool continueProcessing = true;

        while (continueProcessing)
        {
            Console.WriteLine("Administrator Panel - Choose an option:");
            Console.WriteLine("1. Read Logins");
            Console.WriteLine("2. Add Login");
            Console.WriteLine("3. Delete Login");
            Console.WriteLine("4. Update Login");
            Console.WriteLine("5. Exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ReadLogins();
                    break;
                case "2":
                    AddLogin();
                    break;
                case "3":
                    DeleteLogin();
                    break;
                case "4":
                    UpdateLogin();
                    break;
                case "5":
                    continueProcessing = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

            if (continueProcessing)
            {
                Console.WriteLine("Do you want to continue in the Administrator Panel? (yes/no)");
                string? continueChoice = Console.ReadLine();
                continueProcessing = continueChoice?.Trim().ToLower() == "yes";
                Console.Clear();
            }
        }
    }


    public void ReadLogins()
    {
        var logins = Context.Logins.ToList();

        if (logins.Any())
        {
            Console.WriteLine("Login Details:");
            foreach (var login in logins)
            {
                Console.WriteLine($"Employee ID: {login.EmployeeID}");
                Console.WriteLine($"Username: {login.Username}");
                Console.WriteLine($"Access Level: {login.AccessLevel}");
                Console.WriteLine(new string('-', 40)); // Separator line for each login
            }
        }
        else
        {
            Console.WriteLine("No login records found.");
        }
    }

    public Login? CreateLogin()
    {
        try
        {
            Console.WriteLine("Enter Login Details:");

            Console.Write("Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine() ?? string.Empty);

            Console.Write("Username: ");
            string username = Console.ReadLine() ?? string.Empty;

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? string.Empty;

            Console.Write("Access Level (Basic, Moderator, Admin): ");
            string accessLevel = Console.ReadLine() ?? string.Empty;

            var login = new Login
            {
                EmployeeID = employeeId,
                Username = username,
                Password = password,
                AccessLevel = accessLevel
            };

            return login;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
            return null;
        }
    }

    public void AddLogin()
    {
        try
        {
            Login? login = CreateLogin();
            if (login == null)
            {
                throw new InvalidOperationException("Failed to create login.");
            }

            Context.Logins.Add(login);
            Context.SaveChanges();

            Console.WriteLine("Login added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }

    public void DeleteLogin()
    {
        try
        {
            // Step 1: Read all logins
            ReadLogins();

            // Step 2: Prompt user to choose a login to delete
            Console.WriteLine("Enter the ID of the login to delete:");
            int loginId = Convert.ToInt32(Console.ReadLine());

            // Fetch the login
            var login = Context.Logins.FirstOrDefault(l => l.EmployeeID == loginId);
            if (login == null)
            {
                Console.WriteLine("Login not found.");
                return;
            }

            // Step 3: Display the chosen login and ask for confirmation
            Console.WriteLine($"You have selected to delete the following login:");
            Console.WriteLine($"ID: {login.EmployeeID}, Username: {login.Username}");
            Console.WriteLine("Are you sure you want to delete this login? (yes/no)");
            string confirmation = Console.ReadLine()?.ToLower() ?? string.Empty;

            // Step 4: If confirmed, delete the login
            if (confirmation == "yes")
            {
                Context.Logins.Remove(login);
                Context.SaveChanges();
                Console.WriteLine("Login deleted successfully.");
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

    public void UpdateLogin()
    {
        try
        {
            // Display all logins
            ReadLogins();

            Console.WriteLine("Enter the ID of the Login you want to update:");
            if (!int.TryParse(Console.ReadLine(), out int loginId))
            {
                throw new ArgumentException("Invalid Login ID. It should be a number.");
            }

            // Find the login to update
            var existingLogin = Context.Logins.FirstOrDefault(l => l.EmployeeID == loginId);
            if (existingLogin == null)
            {
                Console.WriteLine("Login not found.");
                return;
            }

            Login? login = CreateLogin();

            if (login == null)
            {
                throw new InvalidOperationException("Failed to create employee development record.");
            }

            // Update the existing login record
            existingLogin.Username = login.Username;
            existingLogin.Password = login.Password;
            existingLogin.AccessLevel = login.AccessLevel;

            // Save changes to the database
            Context.SaveChanges();

            Console.WriteLine("Login updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Please try again.");
        }
    }  
}

