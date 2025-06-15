namespace AbstractFactory;

class Program
{
    static void Main(string[] args)
    {

        // Abstract Factory Pattern (Simple Definition)
        
        // It’s like a factory that makes other factories — 
        // each factory makes a whole set of matching things.
        INotificationFactory factory;
        if (Environment.GetEnvironmentVariable("ENV") == "PRODUCTION")
        {
            factory = new ProductionNotificationFactory();
        }
        else
        {
            factory = new DevelopmentNotificationFactory();
        }

        var service = new NotificationService(factory);
        service.NotifyUser("Hello! This is a test notification.");
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
        Console.WriteLine($"Email Notification: {message}");
    }
}

public class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS Notification: {message}");
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Push Notification: {message}");
    }
}

// Abstract Factory
public interface INotificationFactory
{
    INotification CreateNotification();
}

public class EmailNotificationFactory : INotificationFactory
{
    public INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

public class SmsNotificationFactory : INotificationFactory
{
    public INotification CreateNotification()
    {
        return new SmsNotification();
    }
}

public class PushNotificationFactory : INotificationFactory
{
    public INotification CreateNotification()
    {
        return new PushNotification();
    }
}

public class DevelopmentNotificationFactory : INotificationFactory
{
    public INotification CreateNotification()
    {
        // In development, we might use simpler, less costly notifications
        return new PushNotification();
    }
}

public class ProductionNotificationFactory : INotificationFactory
{
    public INotification CreateNotification()
    {
        // In production, we may need to use more direct methods like SMS or Email
        return new EmailNotification();
    }
}

// Usage
internal class NotificationService
{
    private readonly INotification _notification;

    public NotificationService(INotificationFactory factory)
    {
        _notification = factory.CreateNotification();
    }

    public void NotifyUser(string message)
    {
        _notification.Send(message);
    }
}