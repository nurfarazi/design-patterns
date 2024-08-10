namespace Decorator;

class Program
{
    static void Main(string[] args)
    {
        INotification notification = new BasicNotification();

        notification = new SlackNotification(notification);
        notification = new EmailNotification(notification);
        notification = new SmsNotification(notification);

        notification.Send("Hello");
    }
}

public interface INotification
{
    void Send(string message);
}

public class BasicNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Sending basic notification: " + message);
    }
}

public abstract class NotificationDecorator : INotification
{
    private INotification _notification;

    public NotificationDecorator(INotification notification)
    {
        _notification = notification;
    }

    public virtual void Send(string message)
    {
        _notification.Send(message);
    }
}

public class SlackNotification : NotificationDecorator
{
    public SlackNotification(INotification notification) : base(notification)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine("Sending slack notification: " + message);
    }
}

public class EmailNotification : NotificationDecorator
{
    public EmailNotification(INotification notification) : base(notification)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine("Sending email notification: " + message);
    }
}

public class SmsNotification : NotificationDecorator
{
    public SmsNotification(INotification notification) : base(notification)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine("Sending sms notification: " + message);
    }
}