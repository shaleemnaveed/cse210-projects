public class Product
{
    // Attribues:
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    // Constructors:
    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return _price * _quantity;
    }
    public string GetPackingLabel()
    {
        return $"Product: {_name} (ID: {_productId})";
    }
}