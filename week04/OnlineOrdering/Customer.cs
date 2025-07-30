public class Customer
{
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Getter for name
    public string GetName()
    {
        return _name;
    }

    // Getter for address
    public Address GetAddress()
    {
        return _address;
    }

    // Method to check if the customer lives in the USA
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}