public abstract class Shape
{
    // Attribues:
    protected string _color;

    // Constructors:
    public Shape(string color)
    {
        _color = color;
    }

    // Methods:
    public string GetColor()
    {
        return _color;
    }
    public void SetColor(string color)
    {
        _color = color;
    }
    public abstract double GetArea();
}