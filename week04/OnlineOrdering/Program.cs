using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System - Foundation Program 2");
        Console.WriteLine("============================================\n");

        // --- Create Order 1 ---
        Console.WriteLine("--- Order 1 ---");

        // Create Address 1
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");

        // Create Customer 1
        Customer customer1 = new Customer("John Doe", address1);

        // Create Order 1
        Order order1 = new Order(customer1);

        // Create and add Products to Order 1
        Product product1_1 = new Product("Apple Watch", "AW001", 399.99f, 1);
        Product product1_2 = new Product("iPhone Charger", "IC002", 19.99f, 2);
        Product product1_3 = new Product("MacBook Pro Case", "MC003", 59.99f, 1);

        order1.AddProduct(product1_1);
        order1.AddProduct(product1_2);
        order1.AddProduct(product1_3);

        // Display Order 1 details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(); // Blank line
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(); // Blank line
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine(); // Blank line for separation

        // --- Create Order 2 ---
        Console.WriteLine("--- Order 2 ---");

        // Create Address 2 (International)
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");

        // Create Customer 2
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create Order 2
        Order order2 = new Order(customer2);

        // Create and add Products to Order 2
        Product product2_1 = new Product("Desk Lamp", "DL004", 24.95f, 1);
        Product product2_2 = new Product("Notebook", "NB005", 3.50f, 5);

        order2.AddProduct(product2_1);
        order2.AddProduct(product2_2);

        // Display Order 2 details
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(); // Blank line
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(); // Blank line
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
        Console.WriteLine(); // Final blank line
    }
}