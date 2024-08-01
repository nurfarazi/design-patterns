namespace FactoryMethod;

class Program
{
    static void Main(string[] args)
    {
        var client = new Client();
        client.SendNotification(NotificationType.Email);
        client.SendNotification(NotificationType.Sms);
    }

    // Factory Method pattern with notification interface
    public interface INotification
    {
        void Notify();
    }

    // Concrete implementation of the notification interface
    public class EmailNotification : INotification
    {
        public void Notify()
        {
            Console.WriteLine("Email notification sent.");
        }
    }

    // Concrete implementation of the notification interface
    public class SmsNotification : INotification
    {
        public void Notify()
        {
            Console.WriteLine("SMS notification sent.");
        }
    }

    // Factory method to create a notification
    public class NotificationFactory
    {
        public INotification CreateNotification(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Email:
                    return new EmailNotification();
                case NotificationType.Sms:
                    return new SmsNotification();
                default:
                    throw new ArgumentException("Invalid notification type.");
            }
        }
    }

    public enum NotificationType
    {
        Email = 0,
        Sms = 1
    }

    // Client code
    public class Client
    {
        public void SendNotification(NotificationType type)
        {
            var factory = new NotificationFactory();
            var notification = factory.CreateNotification(type);

            notification.Notify();
        }
    }
}