namespace Adapter;

class Program
{
    static void Main(string[] args)
    {
        var advancedNotificationService = new AdvancedNotificationService();
        INotification notification = new NotificationAdapter(advancedNotificationService);

        notification.Send("This is an important update!");
    }
}

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email notification: {message}");
    }
}

// New notification service with a different interface
public class AdvancedNotificationService
{
    public void SendNotification(string title, string message)
    {
        Console.WriteLine($"Sending {title}: {message}");
    }
}

// Adapter to make AdvancedNotificationService compatible with INotification
public class NotificationAdapter : INotification
{
    private readonly AdvancedNotificationService _advancedService;

    public NotificationAdapter(AdvancedNotificationService advancedService)
    {
        _advancedService = advancedService;
    }

    public void Send(string message)
    {
        // Using a fixed title for simplicity of this example, but 
        // You can place more logic here to determine the title
        _advancedService.SendNotification("Alert", message);
    }
}