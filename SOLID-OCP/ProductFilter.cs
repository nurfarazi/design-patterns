public class ProductFilter
{
    public static IEnumerable<Product> BySize(IEnumerable<Product> products, Size size)
    {
        return products.Where(product => product.Size == size);
    }
    // filter product by color method 
    public static IEnumerable<Product> ByColor(IEnumerable<Product> products, Color color)
    {
        return products.Where(product => product.Color == color);
    }
}