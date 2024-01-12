using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercice09_Hotel.Classes
{
    internal class Client
    {
        private static int _lastClientNumber = 20;
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname {  get; set; }
        public string Phone { get; set; }

        public Client(string lastname, string firstname, string phone)
        {
            _lastClientNumber++;

            Id = _lastClientNumber;
            Lastname = lastname;
            Firstname = firstname;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"{Id.ToString().PadLeft(5, '0')} : {Lastname} {Firstname}";
        }
    }
}
