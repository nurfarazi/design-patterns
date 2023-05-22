using SOLID_OCP.Entity;

namespace SOLID_OCP
{
    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }

        public bool IsSatisfied(Product item)
        {
            return item.Color == _color;
        }
    }
}