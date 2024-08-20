namespace Visitor;

class Program
{
    static void Main(string[] args)
    {
        IOrder regularOrder = new RegularOrder { Price = 100 };
        IOrder discountedOrder = new DiscountedOrder { Price = 80 };

        IOrderVisitor discountVisitor = new DiscountVisitor();
        IOrderVisitor taxVisitor = new TaxVisitor();
        IOrderVisitor invoiceVisitor = new InvoiceVisitor();

        // Apply discounts
        Console.WriteLine("Applying discounts:");
        regularOrder.Accept(discountVisitor);
        discountedOrder.Accept(discountVisitor);

        Console.WriteLine();

        // Calculate taxes
        Console.WriteLine("Calculating taxes:");
        regularOrder.Accept(taxVisitor);
        discountedOrder.Accept(taxVisitor);

        Console.WriteLine();

        // Generate invoices
        Console.WriteLine("Generating invoices:");
        regularOrder.Accept(invoiceVisitor);
        discountedOrder.Accept(invoiceVisitor);
    }
}

public interface IOrderVisitor
{
    void Visit(RegularOrder regularOrder);
    void Visit(DiscountedOrder discountedOrder);
}

public class DiscountVisitor : IOrderVisitor
{
    public void Visit(RegularOrder regularOrder)
    {
        Console.WriteLine($"Applying standard discount to regular order. Original Price: {regularOrder.Price}");
        regularOrder.Price -= 10; // Apply a fixed discount
        Console.WriteLine($"New Price: {regularOrder.Price}");
    }

    public void Visit(DiscountedOrder discountedOrder)
    {
        Console.WriteLine($"Applying additional discount to discounted order. Original Price: {discountedOrder.Price}");
        discountedOrder.Price -= 15; // Apply an additional discount
        Console.WriteLine($"New Price: {discountedOrder.Price}");
    }
}

public class TaxVisitor : IOrderVisitor
{
    public void Visit(RegularOrder regularOrder)
    {
        double tax = regularOrder.Price * 0.1; // 10% tax
        Console.WriteLine($"Calculating tax for regular order. Tax: {tax}");
    }

    public void Visit(DiscountedOrder discountedOrder)
    {
        double tax = discountedOrder.Price * 0.1; // 10% tax
        Console.WriteLine($"Calculating tax for discounted order. Tax: {tax}");
    }
}

public class InvoiceVisitor : IOrderVisitor
{
    public void Visit(RegularOrder regularOrder)
    {
        Console.WriteLine($"Generating invoice for regular order. Price: {regularOrder.Price}");
    }

    public void Visit(DiscountedOrder discountedOrder)
    {
        Console.WriteLine($"Generating invoice for discounted order. Price: {discountedOrder.Price}");
    }
}

public interface IOrder
{
    void Accept(IOrderVisitor visitor);
}

public class RegularOrder : IOrder
{
    public double Price { get; set; }

    public void Accept(IOrderVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class DiscountedOrder : IOrder
{
    public double Price { get; set; }

    public void Accept(IOrderVisitor visitor)
    {
        visitor.Visit(this);
    }
}