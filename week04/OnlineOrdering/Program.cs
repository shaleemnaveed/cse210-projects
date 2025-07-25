using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1:
        Customer customer1 = new Customer("John Doe", new Address("123 Maple St", "Springfield", "IL", "USA"));
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LP1001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "MS2001", 25.50, 2));
        // Order 2:
        Customer customer2 = new Customer("Alice Smith", new Address("456 Elm Ave", "Toronto", "ON", "Canada"));
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Tablet", "TB3001", 300.00, 1));
        order2.AddProduct(new Product("Stylus", "ST4001", 20.00, 3));
        // List of orders:
        List<Order> orders = new List<Order> { order1, order2 };
        // Displaying orders:
        int count = 0;
        foreach (Order order in orders)
        {
            count++;
            Console.WriteLine($"\nOrder {count}:\n\n{order.PackingLabel()}\n{order.ShippingLabel()}\n\nTotal Price: {order.TotalPrice():F2}\n");
        }
    }
}