using System;
using System.Collections.Generic;
using System.Linq;

    public class NotificationList
    {
        public List<Notification> Notifications { get; private set; }

        public NotificationList(WeManageContext context)
        {
            {
                Notifications = context.Notifications
                                        .Where(n => n.Timestamp >= DateTime.Now)
                                        .ToList();
            }
        }

        public void PrintNotifications()
        {
            if (Notifications.Count == 0)
            {
                Console.WriteLine("No new notifications.");
                return;
            }

            Console.WriteLine("New Notifications:");
            Console.WriteLine(new string('-', 50)); // Print a separator line
            foreach (var notification in Notifications)
            {
                Console.WriteLine($"Message: {notification.NotificationContent}");
                Console.WriteLine(new string('-', 50)); // Print a separator line between notifications
            }

            // Prompt for confirmation
            Console.WriteLine("Press any key to confirm that you have read the notifications.");
            Console.ReadKey(); // Waits for the user to press a key
        }
    }