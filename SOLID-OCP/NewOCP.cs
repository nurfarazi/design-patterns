namespace SOLID_OCP
{
    public enum Color
    {
        White = 0,
        Black = 1
    }
    class Product
    {

    }
    public enum Size
    {
        Small = 0,
        Medium = 1,
        Large = 2,
    }
    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);
    }
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
    public class NewOCP
    {

    }
}