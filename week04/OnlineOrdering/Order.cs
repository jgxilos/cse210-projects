using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate the total cost of the order
    public float CalculateTotalCost()
    {
        float totalProductCost = 0;
        foreach (Product product in _products)
        {
            totalProductCost += product.CalculateTotalCost();
        }

        float shippingCost = _customer.IsInUSA() ? 5.0f : 35.0f;

        return totalProductCost + shippingCost;
    }

    // Method to get the packing label
    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder("Packing Label:\n");
        foreach (Product product in _products)
        {
            label.AppendLine($"- {product.GetName()} (ID: {product.GetProductID()})");
        }
        return label.ToString();
    }

    // Method to get the shipping label
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}