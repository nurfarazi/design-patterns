namespace State;

class Program
{
    static void Main(string[] args)
    {
        var order = new Order();

        order.Process();
        order.Process();
        order.Process();
    }
}

public interface IOrderState
{
    void HandleOrder(Order order);
}

public class PendingState : IOrderState
{
    public void HandleOrder(Order order)
    {
        Console.WriteLine("Order is pending.");
        Console.WriteLine("Transition to the next state.");
        
        order.SetState(new ShippedState());
    }
}

public class ShippedState : IOrderState
{
    public void HandleOrder(Order order)
    {
        Console.WriteLine("Order has been shipped.");
        Console.WriteLine("Transition to the next state.");

        order.SetState(new DeliveredState());
    }
}

public class DeliveredState : IOrderState
{
    public void HandleOrder(Order order)
    {
        Console.WriteLine("Order has been delivered.");
        Console.WriteLine("End of the order process.");
    }
}


public class Order
{
    private IOrderState _state;

    public Order()
    {
        _state = new PendingState(); // Initial state
    }

    public void SetState(IOrderState state)
    {
        _state = state;
    }

    public void Process()
    {
        _state.HandleOrder(this);
    }
}