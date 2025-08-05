using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 5, 4);
        Circle circle = new Circle("Green", 4);

        List<Shape> shapes = new List<Shape> { square, rectangle, circle };
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}