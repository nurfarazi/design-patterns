using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID_OCP_v1
{
    public enum Color
    {
        white = 0,
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
        public IEnumerable<Product> BySize(IEnumerable<Product> products, Size size)
        {

        }

        public IEnumerable<Product> ByColor(IEnumerable<Product> products, Color color)
        {
            
        }


    }
}