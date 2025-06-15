namespace FactoryMethod;

class Program
{

    
    // Factory Method pattern
    // that can produce different types of notifications (Email and SMS) based on the type specified.
    // It uses an interface for the notification and concrete classes for each type of notification.

    // definition
    // Factory Method pattern is a creational design pattern that provides an
    // interface for creating objects in a superclass,
    // but allows subclasses to alter the type of objects that will be created.

    // simple defination 
    // Factory Method is a design pattern that defines an interface for creating an object,
    // but lets subclasses alter the type of objects that will be created.
    // It is a way to encapsulate the instantiation logic of an object,
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