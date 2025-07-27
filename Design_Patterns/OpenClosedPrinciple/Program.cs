using System.Reflection.PortableExecutable;

namespace OpenClosedPrinciple
{
    /// <summary>
    /// With this demonstration we want to demonstrate how we can add functionalities (in this filter) without modifying the base class Color
    /// We added few interfaces to achieve that instead of adding functions in the Base class.
    /// </summary>
    public enum Color
    {
        Red,
        Green,
        Blue,
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
    }

    public class Product
    {
        public Color Color;
        public Size Size;
        public string Name { get; set; }

        public Product(Color color,
                       Size size,
                       string name)
        {
            this.Color = color;
            this.Size = size;
            this.Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
        }
    }
    public interface ISpecfication<T>
    {
        bool IsSatisfied(Product item);
    }
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<Product> product, ISpecfication<T> specfication);
    }

    public class ColorSpecification : ISpecfication<Product>
    {
        private Color Color;

        public ColorSpecification(Color color)
        {
            this.Color = color;
        }
        public bool IsSatisfied(Product item)
        {
            return item.Color == Color;
        }
    }

    public class SizeSpecification : ISpecfication<Product>
    {
        private Size Size;

        public SizeSpecification(Size size)
        {
            this.Size = size;
        }
        public bool IsSatisfied(Product item)
        {
            return item.Size == Size;
        }
    }

    public class AndSpecification<T> : ISpecfication<Product>
    {
        private ISpecfication<Product> first, second;

        public AndSpecification(ISpecfication<Product> fisrt, ISpecfication<Product> second)
        {
            this.first = fisrt;
            this.second = second;
        }
        bool ISpecfication<Product>.IsSatisfied(Product item)
        {
            return first.IsSatisfied(item) && second.IsSatisfied(item);
        }
    }

    public class ProductFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> product, ISpecfication<Product> specfication)
        {
            foreach (Product item in product)
            {
                if (specfication.IsSatisfied(item))
                    yield return item;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(color: Color.Red, size: Size.Medium, name: "Tomato"));
            products.Add(new Product(color: Color.Red, size: Size.Large, name: "Carrot"));
            products.Add(new Product(color: Color.Green, size: Size.Medium, name: "Green Chilly"));
            products.Add(new Product(color: Color.Blue, size: Size.Medium, name: "Blue Berry"));

            ProductFilter filter = new ProductFilter();

            //Red Color items
            Console.WriteLine("Red Color Product");
            foreach (Product item in filter.Filter(products, new ColorSpecification(Color.Red)))
            {
                Console.WriteLine($"Red Color Product: {item.Name}");
            }

            //Medium size products
            Console.WriteLine("Medium size Product");
            foreach (Product item in filter.Filter(products, new SizeSpecification(Size.Medium)))
            { Console.WriteLine($"Medium size product: {item.Name}"); }

            //Red Color and medium size products
            Console.WriteLine("Red Color and medium size products");
            foreach(Product item in filter.Filter(products,new AndSpecification<Product>(new ColorSpecification(Color.Red),new SizeSpecification(Size.Medium))))
            {
                Console.WriteLine($"Item with Red color and Medium size: {item.Name}");
            }
        }
    }
}
