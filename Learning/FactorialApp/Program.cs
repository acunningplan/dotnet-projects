using static System.Console;
using static Shared.FactorialCalculator;
using Shared;

namespace FactorialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"5! is {Factorial(5)}");

            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

            var r = new Rectangle(3, 4.5);
            WriteLine($"Rectangle H: {r.Height}, W: {r.Width}, Area: {r.Area}");
            var s = new Square(5);
            WriteLine($"Square    H: {s.Height}, W: {s.Width}, Area: {s.Area}");
            var c = new Circle(2.5);
            WriteLine($"Circle    H: {c.Height}, W: {c.Width}, Area: {c.Area}");
        }
    }
}
