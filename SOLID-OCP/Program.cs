
var products = new[]
{
    new Product("Apple", Color.Green, Size.Small),
    new Product("Tree", Color.Green, Size.Large),
    new Product("House", Color.Blue, Size.Large),
    new Product("Car", Color.Red, Size.Medium),
    new Product("Pen", Color.Blue, Size.Small),
    new Product("Pencil", Color.Red, Size.Small),
    new Product("Bike", Color.Red, Size.Large)
};
            
OldImplementation(products);

NewImplementation(products);

void NewImplementation(Product[] products)
{
    // New implementation which respects Open Closed Principle
    var improvedFilter = new ImprovedFilter();
    var greenProducts = improvedFilter.Filter(products, new ColorSpecification(Color.Green));
    var largeProducts = improvedFilter.Filter(products, new SizeSpecification(Size.Large));

    // log green products
    foreach (var gProduct in greenProducts)
    {
        Console.WriteLine($"{gProduct.Name} is green");
    }

    // log large products
    foreach (var lProduct in largeProducts)
    {
        Console.WriteLine($"{lProduct.Name} is large");
    }
}

static void OldImplementation(Product[] products)
{
    // Old implementation which violates Open Closed Principle
    var oldFilter = new ProductFilter();
    // var greenProductsOld = oldFilter.ByColor(products, Color.Green);
    // var largeProductsOld = oldFilter.BySize(products, Size.Large);
    // // log green products
    // foreach (var product in greenProductsOld)
    // {
    //     System.Console.WriteLine($"{product.Name} is green");
    // }
    //
    // // log large products
    // foreach (var product in largeProductsOld)
    // {
    //     Console.WriteLine($"{product.Name} is large");
    // }
}