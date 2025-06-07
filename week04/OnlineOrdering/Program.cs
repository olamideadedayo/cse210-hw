using System;
using System.Collections.Generic;

// Address class definition
public class Address
{
    public string Street { get; }
    public string City { get; }
    public string StateOrProvince { get; }
    public string Country { get; }

    public Address(string street, string city, string stateOrProvince, string country)
    {
        Street = street;
        City = city;
        StateOrProvince = stateOrProvince;
        Country = country;
    }
    
    public override string ToString()
    {
        return $"{Street}\n{City}, {StateOrProvince}\n{Country}";
    }
}

// Customer class definition
public class Customer
{
    public string Name { get; }
    public Address Address { get; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }
}

// Product class definition
public class Product
{
    public string Name { get; }
    public string ProductId { get; }
    public double Price { get; }
    public int Quantity { get; }

    public Product(string name, string productId, double price, int quantity)
    {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }
}

// Order class definition
public class Order
{
    private List<Product> _products = new List<Product>();
    public Customer Customer { get; }

    public Order(Customer customer)
    {
        Customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.Price * product.Quantity;
        }
        // Add shipping cost: $5 for USA, $35 for others
        total += Customer.Address.Country.ToUpper() == "USA" ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        var label = "";
        foreach (var product in _products)
        {
            label += $"{product.Name} (ID: {product.ProductId}) x{product.Quantity}\n";
        }
        return label.TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"{Customer.Name}\n{Customer.Address}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // First order
        Address address1 = new Address("123 Main St", "Lagos", "Lagos", "Nigeria");
        Customer customer1 = new Customer("Chinedu Okafor", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P001", 1200.00, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25.00, 2));

        // Second order
        Address address2 = new Address("456 Elm St", "Salt Lake City", "UT", "USA");
        Customer customer2 = new Customer("Sarah Johnson", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Book", "P003", 15.00, 3));
        order2.AddProduct(new Product("Pen", "P004", 2.50, 5));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
