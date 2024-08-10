namespace Facade;

class Program
{
    static void Main(string[] args)
    {
        var orderFacade = new OrderFacade();

        orderFacade.PlaceOrder("1234", "Laptop", "123 Street, City");
    }
}

public class OrderFacade
{
    private readonly PaymentProcessor _paymentProcessor;
    private readonly InventoryManager _inventoryManager;
    private readonly PackagingService _packagingService;
    private readonly ShippingService _shippingService;

    public OrderFacade()
    {
        _paymentProcessor = new PaymentProcessor();
        _inventoryManager = new InventoryManager();
        _packagingService = new PackagingService();
        _shippingService = new ShippingService();
    }

    public void PlaceOrder(string paymentDetails, string item, string address)
    {
        Console.WriteLine("Processing order...");
        _paymentProcessor.ValidatePayment(paymentDetails);
        _inventoryManager.CheckInventory(item);
        _packagingService.PackageItem(item);
        _shippingService.ShipItem(item, address);
        Console.WriteLine("Order processed successfully!");
    }
}

public class PaymentProcessor
{
    public void ValidatePayment(string paymentDetails)
    {
        Console.WriteLine("Payment validated: " + paymentDetails);
    }
}

public class InventoryManager
{
    public void CheckInventory(string item)
    {
        Console.WriteLine("Inventory checked for item: " + item);
    }
}

public class PackagingService
{
    public void PackageItem(string item)
    {
        Console.WriteLine("Item packaged: " + item);
    }
}

public class ShippingService
{
    public void ShipItem(string item, string address)
    {
        Console.WriteLine($"Item {item} shipped to {address}");
    }
}