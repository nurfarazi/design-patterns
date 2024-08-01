namespace Builder;

class Program
{
    static void Main(string[] args)
    {
        var notificationBuilder = new NotificationBuilder();
        notificationBuilder.SetTitle("Hello World");
        notificationBuilder.SetMessage("This is a message");
        notificationBuilder.SetIcon("icon.png");

        var notification = notificationBuilder.Build();
        Console.WriteLine(notification);
    }
}

public class Notification
{
    public string? Title { get; set; }
    public string? Message { get; set; }
    public string? Icon { get; set; }

    public override string ToString()
    {
        return $"Notification - Title: {Title}, Message: {Message}, Icon: {Icon}";
    }
}

public interface INotificationBuilder
{
    void SetTitle(string title);
    void SetMessage(string message);
    void SetIcon(string icon);
    Notification Build();
}

public class NotificationBuilder : INotificationBuilder
{
    private readonly Notification _notification = new Notification();

    public void SetTitle(string title)
    {
        _notification.Title = title;
    }

    public void SetMessage(string message)
    {
        _notification.Message = message;
    }

    public void SetIcon(string icon)
    {
        _notification.Icon = icon;
    }

    public Notification Build()
    {
        return _notification;
    }
}