using System.Collections.Generic;
using System.Linq;
using SOLID_OCP.Entity;

namespace SOLID_OCP
{
    public class ProductFilter
    {
        public IEnumerable<Product> BySize(IEnumerable<Product> products, Size size)
        {
            return products.Where(product => product.Size == size);
        }
        // filter product by color method 
        public IEnumerable<Product> ByColor(IEnumerable<Product> products, Color color)
        {
            return products.Where(product => product.Color == color);
        }
    }
}