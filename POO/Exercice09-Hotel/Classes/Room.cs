using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice09_Hotel.Classes
{
    internal enum RoomStatus
    {
        /// <summary>
        /// Chambre libre
        /// </summary>
        Free = 1,
        /// <summary>
        /// Chambre occupée
        /// </summary>
        Occupied = 2,
        /// <summary>
        /// Chambre en cours de nettoyage
        /// </summary>
        InCleaning = 3
    }
    
    internal class Room
    {
        public static List<Room> All = new List<Room>();

        public int Number { get; set; }
        public RoomStatus Status { get; set;}
        public int BedsCount {  get; set; }
        public decimal Price { get; set; }
        
        public Room(int number, RoomStatus status, int bedsCount, decimal price)
        {
            Number = number;
            Status = status;
            BedsCount = bedsCount;
            Price = price;

            All.Add(this);
        }

        public override string ToString()
        {
            string statusColor = "white";
            switch (Status)
            {
                case RoomStatus.Free:
                    statusColor = "green";
                    break;
                case RoomStatus.Occupied:
                    statusColor = "red";
                    break;
                case RoomStatus.InCleaning:
                    statusColor = "blue";
                    break;
            }
            return $"{Number.ToString().PadLeft(3,'0')} : [{statusColor}]{Status.ToString()}[/] ([yellow]{Price:C2} / night[/], {BedsCount} bed" + (BedsCount == 1 ? "" : "s") + ")";
        }
    }
}
