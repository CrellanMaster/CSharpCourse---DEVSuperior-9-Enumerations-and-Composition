using CompositionProject.Entities.Enums;
using System.Globalization;
using CompositionProject.Entities;

namespace CompositionProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (MM/DD/YYYY):");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(
                name,
                email,
                birthDate
                );

            Console.WriteLine("Enter order data: ");
            Console.WriteLine($"Status: {OrderStatus.Processing}");
            Console.Write("How many items to this order? ");
            int number = int.Parse(Console.ReadLine());

            Order order = new Order(
                            DateTime.Now,
                            OrderStatus.Processing,
                            client
                            );

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product Price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(
                    productName,
                    productPrice
                    );
                OrderItem orderItem = new OrderItem(
                    quantity,
                    productPrice,
                    product
                    );
                order.AddItem(orderItem);
            }

            Console.WriteLine("ORDER SUMARY: ");
            Console.WriteLine(order.ToString());
        }
    }
}
