﻿namespace FactoryMethod;

class Program
{
    static void Main(string[] args)
    {
        var client = new Client();
        client.SendNotification("email");
        client.SendNotification("sms");
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
        public INotification CreateNotification(string type)
        {
            switch (type)
            {
                case "email":
                    return new EmailNotification();
                case "sms":
                    return new SmsNotification();
                default:
                    throw new ArgumentException("Invalid notification type.");
            }
        }
    }
    
    // Client code
    public class Client
    {
        public void SendNotification(string type)
        {
            var factory = new NotificationFactory();
            var notification = factory.CreateNotification(type);
            notification.Notify();
        }
        
    }
    
}