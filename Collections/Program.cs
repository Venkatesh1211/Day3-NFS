using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    // Customer class
    class Customer
    {
        public int Id;
        public string Name;

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    // Order class
    class Order
    {
        public int OrderId;
        public int CustomerId;
        public string Product;
        public string Category;

        // Stack for status tracking
        public Stack<string> StatusHistory = new Stack<string>();

        public Order(int orderId, int customerId, string product, string category)
        {
            OrderId = orderId;
            CustomerId = customerId;
            Product = product;
            Category = category;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // List to store orders
            List<Order> orders = new List<Order>();

            // Dictionary for customers
            Dictionary<int, Customer> customers = new Dictionary<int, Customer>();

            // HashSet for unique categories
            HashSet<string> categories = new HashSet<string>();

            // Queue for order processing
            Queue<Order> orderQueue = new Queue<Order>();

            // Add customers
            customers[1] = new Customer(1, "Kartheek");
            customers[2] = new Customer(2, "Ravi");

            // Add orders
            Order o1 = new Order(101, 1, "Laptop", "Electronics");
            Order o2 = new Order(102, 2, "Shoes", "Fashion");

            orders.Add(o1);
            orders.Add(o2);

            // Add categories
            categories.Add(o1.Category);
            categories.Add(o2.Category);

            // Add to queue
            orderQueue.Enqueue(o1);
            orderQueue.Enqueue(o2);

            // Update order
            o1.Product = "Gaming Laptop";

            // Track status using Stack
            o1.StatusHistory.Push("Order Placed");
            o1.StatusHistory.Push("Shipped");
            o1.StatusHistory.Push("Delivered");

            // Process orders (FIFO)
            Console.WriteLine("--- Processing Orders ---");
            while (orderQueue.Count > 0)
            {
                Order current = orderQueue.Dequeue();
                Console.WriteLine("Processing Order ID: " + current.OrderId);
            }

            // Display all orders
            Console.WriteLine("\n--- All Orders ---");
            foreach (var order in orders)
            {
                Console.WriteLine("OrderID: " + order.OrderId +
                                  ", Product: " + order.Product +
                                  ", Category: " + order.Category);
            }

            // Display status history
            Console.WriteLine("\n--- Status History (Latest First) ---");
            foreach (var status in o1.StatusHistory)
            {
                Console.WriteLine(status);
            }

            // Remove an order
            orders.Remove(o2);

            // Display unique categories
            Console.WriteLine("\n--- Unique Categories ---");
            foreach (var cat in categories)
            {
                Console.WriteLine(cat);
            }
        }
    }
}