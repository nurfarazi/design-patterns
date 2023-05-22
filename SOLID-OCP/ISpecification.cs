namespace SOLID_OCP
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);
    }
}