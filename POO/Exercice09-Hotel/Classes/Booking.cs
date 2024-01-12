using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice09_Hotel.Classes
{
    internal enum BookingStatus
    {
        Planned = 2,
        OnGoing = 1,
        Closed = 3,
        Cancelled = 4
    }
    internal class Booking
    {
        public List<Booking> All = new List<Booking>();
        
        public int Number { get; init; }
        public BookingStatus Status { get; set; }
        public Room Room { get; init; }
        public Client Client { get; init; }

        public static int _lastBookingNumber = 5000;

        public Booking(BookingStatus status, Room room, Client client)
        {
            _lastBookingNumber++;

            Number = _lastBookingNumber;
            Status = status;
            Room = room;
            Client = client;
        }

        public override string ToString()
        {
            string statusColor = "white";
            switch (Status)
            {
                case BookingStatus.OnGoing:
                    statusColor = "green";
                    break;
                case BookingStatus.Planned:
                    statusColor = "yellow";
                    break;
                case BookingStatus.Closed:
                    statusColor = "gray";
                    break;
                case BookingStatus.Cancelled:
                    statusColor = "orange";
                    break;
            }
            return $"{Number.ToString().PadLeft(8, '0')} : [{statusColor}]{Status.ToString()}[/] Room: {Room.Number.ToString().PadLeft(3, '0')} Client: {Client}";
        }
    }
}
