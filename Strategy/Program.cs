class Program
{
    static void Main(string[] args)
    {
        // Create products
        var product1 = new Product("Laptop", 1000);
        var product2 = new Product("Mouse", 20);
        var product3 = new Product("Keyboard", 50);

        // Set discount strategy
        product1.SetDiscountStrategy(new ChristmasDiscountStrategy());
        product2.SetDiscountStrategy(new BlackFridayDiscountStrategy());
        product3.SetDiscountStrategy(new PercentageDiscountStrategy(0.1m));

        // Calculate final price
        Console.WriteLine($"{product1.Name} price: {product1.GetFinalPrice()}");
        Console.WriteLine($"{product2.Name} price: {product2.GetFinalPrice()}");
        Console.WriteLine($"{product3.Name} price: {product3.GetFinalPrice()}");

        // Shopping cart
        var shoppingCart = new ShoppingCart(new FixedAmountDiscountStrategy(100));
        Console.WriteLine($"Total price: {shoppingCart.Checkout(1000)}");
        
    }
}

public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal originalPrice);
}

public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal originalPrice)
    {
        return originalPrice;
    }
}

public class ChristmasDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal originalPrice)
    {
        return originalPrice * 0.5m;
    }
}

public class BlackFridayDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal originalPrice)
    {
        return originalPrice * 0.7m;
    }
}

public class PercentageDiscountStrategy : IDiscountStrategy
{
    private readonly decimal _percentage;

    public PercentageDiscountStrategy(decimal percentage)
    {
        _percentage = percentage;
    }

    public decimal ApplyDiscount(decimal originalPrice)
    {
        return originalPrice * (1 - _percentage);
    }
}

public class FixedAmountDiscountStrategy : IDiscountStrategy
{
    private readonly decimal _amount;

    public FixedAmountDiscountStrategy(decimal amount)
    {
        _amount = amount;
    }

    public decimal ApplyDiscount(decimal originalPrice)
    {
        return originalPrice - _amount;
    }
}

public class BuyOneGetOneFreeStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal originalPrice)
    {
        return originalPrice / 2;
    }
}

public class Product
{
    private IDiscountStrategy _discountStrategy;
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price){
        Name = name;
        Price = price;
        _discountStrategy = new NoDiscountStrategy();
    }

     public void SetDiscountStrategy(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public decimal GetFinalPrice()
    {
        return _discountStrategy.ApplyDiscount(Price);
    }
}


public class ShoppingCart
{
    private readonly IDiscountStrategy _discountStrategy;

    public ShoppingCart(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public decimal Checkout(decimal originalPrice)
    {
        return _discountStrategy.ApplyDiscount(originalPrice);
    }
}

