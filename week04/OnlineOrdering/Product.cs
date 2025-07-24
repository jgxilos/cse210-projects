public class Product
{
    private string _name;
    private string _productID;
    private float _price;
    private int _quantity;

    // Constructor
    public Product(string name, string productID, float price, int quantity)
    {
        _name = name;
        _productID = productID;
        _price = price;
        _quantity = quantity;
    }

    // Getter for name
    public string GetName()
    {
        return _name;
    }

    // Getter for product ID
    public string GetProductID()
    {
        return _productID;
    }

    // Method to calculate the total cost of this product
    public float CalculateTotalCost()
    {
        return _price * _quantity;
    }
}