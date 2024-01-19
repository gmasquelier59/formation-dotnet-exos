using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice02_Commandes.Classes
{
    internal class Client
    {
        public int Id { get; internal set; } = 0;
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Address { get; set; }
        public string AddressZip { get; set; }
        public string AddressCity { get; set; }
        public string Phone {  get; set; }
        public List<Order> Orders { get; } = new List<Order>();

        public Client(string name, string firstname, string address, string addressZip, string addressCity, string phone)
        {
            Name = name;
            Firstname = firstname;
            Address = address;
            AddressZip = addressZip;
            AddressCity = addressCity;
            Phone = phone;
        }

        internal Client(int id, string name, string firstname, string address, string addressZip, string addressCity, string phone) : this(name, firstname, address, addressZip, addressCity, phone)
        {
            Id = id;
        }

        public void AddOrder(Order order)
        {
            if (order == null)
                return;

            Orders.Add(order);
        }

        public override string ToString() {
            return $"🙋 [yellow]Client {Id}[/] - [blue]{Name} {Firstname} - {Address} {AddressZip} {AddressCity} - {Phone}[/]";
        }
    }
}
