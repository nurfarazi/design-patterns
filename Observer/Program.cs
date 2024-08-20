namespace Observer;

class Program
{
    static void Main(string[] args)
    {
        var order = new Order();

        order.RegisterObserver(new EmailNotificationObserver());
        order.RegisterObserver(new SmsNotificationObserver());
        order.RegisterObserver(new SlackNotificationObserver());
        order.RegisterObserver(new PushNotificationObserver());

        order.NotifyObservers();
    }
}

public interface INotificationObserver
{
    void Update(string message);
}

public interface IOrderSubject
{
    void RegisterObserver(INotificationObserver observer);
    void RemoveObserver(INotificationObserver observer);
    void NotifyObservers();
}

public class Order : IOrderSubject
{
    private readonly List<INotificationObserver> _observers = [];

    public void RegisterObserver(INotificationObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(INotificationObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update("Order has been processed.");
        }
    }
}

public class EmailNotificationObserver : INotificationObserver
{
    public void Update(string message)
    {
        Console.WriteLine("Sending email notification: " + message);
    }
}

public class SmsNotificationObserver : INotificationObserver
{
    public void Update(string message)
    {
        Console.WriteLine("Sending sms notification: " + message);
    }
}

public class SlackNotificationObserver : INotificationObserver
{
    public void Update(string message)
    {
        Console.WriteLine("Sending slack notification: " + message);
    }
}

public class PushNotificationObserver : INotificationObserver
{
    public void Update(string message)
    {
        Console.WriteLine("Sending push notification: " + message);
    }
}
