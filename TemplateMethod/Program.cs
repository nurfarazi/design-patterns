namespace TemplateMethod;

class Program
{
    static void Main(string[] args)
    {
        CheckoutProcessTemplate creditCardCheckout = new CreditCardCheckout();
        creditCardCheckout.Checkout();
        // Output:
        // Validating credit card information
        // Processing credit card payment
        // Generating receipt for the order
        // Updating order status to 'Completed'

        Console.WriteLine();

        CheckoutProcessTemplate payPalCheckout = new PayPalCheckout();
        payPalCheckout.Checkout();
        // Output:
        // Validating PayPal account
        // Processing PayPal payment
        // Generating receipt for the order
        // Updating order status to 'Completed'
    }
}
public abstract class CheckoutProcessTemplate
{
    // Template method defining the checkout process
    public void Checkout()
    {
        ValidatePaymentMethod();
        ProcessPayment();
        GenerateReceipt();
        UpdateOrderStatus();
    }

    // Abstract methods to be implemented by subclasses
    protected abstract void ValidatePaymentMethod();
    protected abstract void ProcessPayment();

    // Common methods with default implementation
    private void GenerateReceipt()
    {
        Console.WriteLine("Generating receipt for the order");
    }

    private void UpdateOrderStatus()
    {
        Console.WriteLine("Updating order status to 'Completed'");
    }
}

public class CreditCardCheckout : CheckoutProcessTemplate
{
    protected override void ValidatePaymentMethod()
    {
        Console.WriteLine("Validating credit card information");
    }

    protected override void ProcessPayment()
    {
        Console.WriteLine("Processing credit card payment");
    }
}

public class PayPalCheckout : CheckoutProcessTemplate
{
    protected override void ValidatePaymentMethod()
    {
        Console.WriteLine("Validating PayPal account");
    }

    protected override void ProcessPayment()
    {
        Console.WriteLine("Processing PayPal payment");
    }
}

