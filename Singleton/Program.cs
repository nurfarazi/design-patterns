namespace Singleton;

class Program
{
    static void Main(string[] args)
    {
        Singleton.Instance?.DoSomething();

        // Attempt to create a new instance
        var instance = Singleton.Instance;
        if (instance == null)
        {
            Console.WriteLine("Singleton instance already exists.");
        }

        // Attempt to create a new instance
        var instance2 = Singleton.Instance;

        // Check if the two instances are the same
        if (instance == instance2)
        {
            Console.WriteLine("Singleton instance is the same.");
        }
    }
}

public class Singleton
{
    // Private static instance of the class
    private static Singleton? _instance;

    // Private constructor to prevent direct instantiation
    private Singleton()
    {
    }

    // Public static method to get the instance
    public static Singleton? Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }

    // Example method to demonstrate functionality
    public void DoSomething()
    {
        Console.WriteLine("Singleton instance is doing something!");
    }
}