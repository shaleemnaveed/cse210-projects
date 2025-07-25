public class Order
{
    // Attributes:
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    // Constructors:
    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public double TotalPrice()
    {
        double sum = 0;
        foreach (Product product in _products)
        {
            sum += product.GetTotalPrice();
        }
        if (_customer.LivesInUsa())
        {
            sum += 5;
        }
        else
        {
            sum += 35;
        }
        return sum;
    }
    public string PackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            label += product.GetPackingLabel() + "\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return "Shipping Label:\n" + _customer.GetShippingLabel();
    }
}