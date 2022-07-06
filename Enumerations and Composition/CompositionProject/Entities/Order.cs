using CompositionProject.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionProject.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }
        public double TotalValue { get; set; }

        public Order()
        {

        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {

            foreach (OrderItem order in Items)
            {
                TotalValue += order.SubTotal();
            }
            return TotalValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order moment: {Moment}");
            sb.AppendLine($"Order Status: {Status}");
            sb.AppendLine($"Client: {Client.Name} ({Client.BirthDate}) - {Client.Email}");
            sb.AppendLine("Order Items: ");

            foreach (OrderItem order in Items)
            {
                sb.AppendLine(order.ToString());
            }
            sb.Append($"Total Price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");
            return sb.ToString();
        }
    }
}
