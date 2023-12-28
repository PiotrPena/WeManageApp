using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();
        string? connectionString = configuration.GetConnectionString("WeManageDbConnection");

        // Setup DbContext
        var optionsBuilder = new DbContextOptionsBuilder<WeManageContext>();
        optionsBuilder.UseSqlServer(connectionString);

        using (var context = new WeManageContext(optionsBuilder.Options))
        {
            bool loginSuccessful = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter your login:");
                string? userLogin = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string? userPassword = Console.ReadLine();

                var user = context.Logins
                                  .FirstOrDefault(l => l.Username == userLogin && l.Password == userPassword);

                if (user != null)
                {
                    Console.WriteLine("Login successful!");
                    loginSuccessful = true;

                    // Fetch Employee data
                    var employeeData = context.Employees.FirstOrDefault(e => e.EmployeeID == user.EmployeeID);
                    if (employeeData == null)
                    {
                        Console.WriteLine("Error: Employee data not found.");
                        return; // Exit if employee data is not found
                    }

                    // Create User object
                    User loggedInUser = new User(employeeData, user, context);

                    // Create NotificationList object and print notifications
                    NotificationList notifications = new NotificationList(context);
                    notifications.PrintNotifications();
                    Console.Clear();

                    // Display personalized welcome message
                    Console.WriteLine($"Welcome {loggedInUser.FirstName} {loggedInUser.LastName}! You are logged in as {loggedInUser.AccessLevel}.");
                    Thread.Sleep(3000);
                    while(true){
                        loggedInUser.ChoosePanel();
                        Console.WriteLine($"Would you like to log out? Press (Esc) to log out.");
                        if(Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid login or password. Please try again.");
                    Console.ReadKey();
                }

            } while (!loginSuccessful);
        }
    }
}

