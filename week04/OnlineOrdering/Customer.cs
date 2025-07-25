public class Customer
{
    // Attribues:
    private string _name;
    private Address _address;

    // Constructors:
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUsa()
    {
        return _address.IsInUSA();
    }
    public string GetShippingLabel()
    {
        return $"{_name}\n{_address.GetCompleteAddress()}";
    }
}