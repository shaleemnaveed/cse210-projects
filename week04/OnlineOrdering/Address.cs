public class Address
{
    // Attribues:
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // Constructors:
    public Address(String street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        if (_country == "USA")
        {
            return true;
        }
        return false;
    }
    public string GetCompleteAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }

}