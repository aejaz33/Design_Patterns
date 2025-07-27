using System.Runtime.CompilerServices;

namespace Liskov_Substitution_Principle
{
    /// <summary>
    /// This is to demonstrate Liskov Substitution principle where Base class types can be subtituted with Base types.
    /// </summary>
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            return ($"Width: {this.Width}, Height: {this.Height}");
        }
    }

    public class Square : Rectangle
    {
        public override int Width { get; set; }
        public override int Height { get; set; }
    }
    internal class Program
    {
        public static float Area(Rectangle r) => r.Height * r.Width;
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(width: 10, height: 20);
            Console.WriteLine($"Area of Rectange {r}: {Area(r)}");

            Rectangle square = new Square();
            square.Width = 2;
            square.Height = 4;
            Console.WriteLine($"Area of Square {square}: {Area(square)}");
        }
    }
}
