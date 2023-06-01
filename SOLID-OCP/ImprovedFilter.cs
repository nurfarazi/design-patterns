public class ImprovedFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
    {
        return items.Where(spec.IsSatisfied);
    }
}