using System;
using System.Collections.Generic;
using System.Linq;

public class NotificationList
{
    private static NotificationList? _instance;
    private readonly WeManageContext _context;
    private Dictionary<int, Notification> _notificationsMap;

    // Private constructor
    private NotificationList(WeManageContext context)
    {
        _context = context;
        _notificationsMap = new Dictionary<int, Notification>();
        LoadNotifications();
    }

    // Public static method to get the instance
    public static NotificationList GetInstance(WeManageContext context)
    {
        if (_instance == null)
        {
            _instance = new NotificationList(context);
        }
        return _instance;
    }

    private void LoadNotifications()
    {
        var notificationsFromDb = _context.Notifications
                                          .Where(n => n.Timestamp >= DateTime.Now);

        foreach (var notification in notificationsFromDb)
        {
            if (!_notificationsMap.ContainsKey(notification.NotificationID))
            {
                _notificationsMap.Add(notification.NotificationID, notification);
            }
        }
    }

    public Notification? GetNotification(int notificationId)
    {
        if (_notificationsMap.TryGetValue(notificationId, out Notification? notification))
        {
            return notification;
        }
        
        // Load from the database if not found in the map
        notification = _context.Notifications.Find(notificationId);
        if (notification != null)
        {
            _notificationsMap.Add(notificationId, notification);
        }
        return notification;
    }

    public void PrintNotifications()
    {
        var notifications = _notificationsMap.Values;
        
        if (notifications.Count == 0)
        {
            Console.WriteLine("No new notifications.");
            return;
        }

        Console.WriteLine("New Notifications:");
        Console.WriteLine(new string('-', 50));
        foreach (var notification in notifications)
        {
            Console.WriteLine($"Message: {notification.NotificationContent}");
            Console.WriteLine(new string('-', 50));
        }

        Console.WriteLine("Press any key to confirm that you have read the notifications.");
        Console.ReadKey();
    }
}
