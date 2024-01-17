using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_Commandes.Classes
{
    internal class Order
    {
        public int Id { get; internal set; } = 0;
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public decimal Total {  get; set; }

        public Order(Client client, DateTime date, decimal total)
        {
            Client = client;
            Date = date;
            Total = total;
        }

        internal Order(int id, Client client, DateTime date, decimal total) : this(client, date, total)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"📄 [yellow]Order {Id}[/] - [blue]{Client.Name} {Client.Firstname} - {Date:g} - {Total:C2}[/]";
        }
    }
}
