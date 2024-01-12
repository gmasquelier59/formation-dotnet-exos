using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice09_Hotel.Classes
{    internal class Hotel
    {
        public List<Client> Clients { get; set; } = [];
        public List<Room> Rooms { get; set; } = [];
        public List<Booking> Bookings { get; set; } = [];
        public string Name { get; init; }

        public Hotel(string name, List<Room> rooms)
        {
            Name = name;
            Rooms = rooms;
        }

        public void AddBooking(Booking booking)
        {
            Bookings.Add(booking);
        }

        public void AddClient(Client client)
        {
            if (FindClientById(client.Id) != null)
                throw new ArgumentException("client", $"A client with id [{client.Id}] already exists !");

            Clients.Add(client);
        }

        public Client FindClientById(int id)
        {
            return Clients.FirstOrDefault(x => x.Id == id, null);
        }

        public Room FindRoomByNumber(int number)
        {
            return Rooms.FirstOrDefault(x => x.Number == number, null);
        }

        public List<Room> FindRoomsByStatus(RoomStatus status)
        {
            return Rooms.Where(x => x.Status == status).ToList();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
