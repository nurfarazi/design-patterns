namespace Composite;

class Program
{
    static void Main(string[] args)
    {
        // Create individual menu items
        var burger = new MenuItem("Burger", 5.99m);
        var fries = new MenuItem("Fries", 2.49m);
        var drink = new MenuItem("Drink", 1.99m);

        // Create a combo meal (composite item)
        var comboMeal = new MenuComposite("Combo Meal");
        comboMeal.Add(burger);
        comboMeal.Add(fries);
        comboMeal.Add(drink);

        // Create a full menu
        var fullMenu = new MenuComposite("Full Menu");
        fullMenu.Add(comboMeal);
        fullMenu.Add(new MenuItem("Salad", 4.99m));

        // Display the menu and total price
        fullMenu.Display();
        Console.WriteLine($"Total price of menu: ${fullMenu.GetPrice()}");
    }
}

public interface IMenuComponent
{
    void Display();
    decimal GetPrice();
}

public class MenuItem : IMenuComponent
{
    private string _name;
    private decimal _price;

    public MenuItem(string name, decimal price)
    {
        _name = name;
        _price = price;
    }

    public void Display()
    {
        Console.WriteLine($"{_name}: ${_price}");
    }

    public decimal GetPrice()
    {
        return _price;
    }
}

public class MenuComposite : IMenuComponent
{
    private readonly List<IMenuComponent> _menuItems = new List<IMenuComponent>();
    private string _name;

    public MenuComposite(string name)
    {
        _name = name;
    }

    public void Add(IMenuComponent menuItem)
    {
        _menuItems.Add(menuItem);
    }

    public void Remove(IMenuComponent menuItem)
    {
        _menuItems.Remove(menuItem);
    }

    public void Display()
    {
        Console.WriteLine($"{_name}:");
        foreach (var item in _menuItems)
        {
            item.Display();
        }
    }

    public decimal GetPrice()
    {
        return _menuItems.Sum(item => item.GetPrice());
    }
}