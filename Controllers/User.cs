using System.Net.Sockets;

public class User
{
    // Fields from the Employees table
    public int EmployeeID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? Address { get; set; }

    // Additional fields from the Logins table
    public string? Username { get; set; }
    public string? AccessLevel { get; set; }

    public WeManageContext Context {get; set; }

    // Constructor
    public User(Employee employee, Login login, WeManageContext context)
    {
        EmployeeID = employee.EmployeeID;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        Email = employee.Email;
        DateOfBirth = employee.DateOfBirth;
        Gender = employee.Gender;
        Address = employee.Address;

        Username = login.Username;
        AccessLevel = login.AccessLevel;

        Context = context;
    }

    public void ChoosePanel()
    {
        bool validChoice = false;
        Panel? chosenPanel = null;

        if (AccessLevel == "Admin")
        {
            while (!validChoice)
            {
                Console.WriteLine("Choose a panel: 1. Basic 2. Moderator 3. Administrator");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        chosenPanel = new BasicPanel(this, Context);
                        // Initialize and use BasicPanel
                        validChoice = true;
                        break;
                    case "2":
                        chosenPanel = new ModeratorPanel(this, Context);
                        // Initialize and use ModeratorPanel
                        validChoice = true;
                        break;
                    case "3":
                        chosenPanel = new AdministratorPanel(this, Context);
                        // Initialize and use AdministratorPanel
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        else if (AccessLevel == "Moderator")
        {
            while (!validChoice)
            {
                Console.WriteLine("Choose a panel: 1. Basic 2. Moderator");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        chosenPanel = new BasicPanel(this, Context);
                        // Initialize and use BasicPanel
                        validChoice = true;
                        break;
                    case "2":
                        chosenPanel = new ModeratorPanel(this, Context);
                        // Initialize and use ModeratorPanel
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        else if (AccessLevel == "Basic")
        {
            chosenPanel = new BasicPanel(this, Context);
        }
        else
        {
            Console.WriteLine("Invalid access level.");
        }

        chosenPanel?.Process();
        
    }
}
