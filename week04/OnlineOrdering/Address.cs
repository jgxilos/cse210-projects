public class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    // Constructor
    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return _country.ToLower() == "usa" || _country.ToLower() == "united states" || _country.ToLower() == "united states of america";
    }

    // Method to get the full address as a single string
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}