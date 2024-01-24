using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Classes
{
    internal class Hotel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<Chambre> Chambres { get; set; } = new List<Chambre>();
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
