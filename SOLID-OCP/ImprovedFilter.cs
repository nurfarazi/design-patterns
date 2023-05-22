using System.Collections.Generic;
using System.Linq;
using SOLID_OCP.Entity;

namespace SOLID_OCP
{
    public class ImprovedFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            return items.Where(spec.IsSatisfied);
        }
    }
}