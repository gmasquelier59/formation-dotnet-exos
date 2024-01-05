using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice04.Classes
{
    internal class WaterTank
    {
        private int _fillLevel = 0;

        public int Number { get; private set; }

        public int WeightEmpty { get; private set; }

        public int MaxCapacity { get; private set; }

        public int FillLevel
        {
            get => _fillLevel;
            private set
            {
                if (value > MaxCapacity)
                    value = MaxCapacity;

                if (value < 0)
                    value = 0;

                TotalFillLevels = TotalFillLevels - FillLevel + value;
                _fillLevel = value;
            }
        }

        public int TotalWeight => WeightEmpty + FillLevel;

        public static int TotalFillLevels { get; private set; } = 0;

        public static int TotalNumberOfTanks { get; private set; } = 0;

        public WaterTank(int weightEmpty, int maxCapacity, int fillLevel)
        {
            TotalNumberOfTanks++;
            Number = TotalNumberOfTanks;
            WeightEmpty = weightEmpty;
            MaxCapacity = maxCapacity;
            FillLevel = fillLevel;
        }

        public int Fill(int waterQuantity)
        {
            if (waterQuantity < 0)
                return 0;

            if (FillLevel + waterQuantity <= MaxCapacity)
            {
                FillLevel += waterQuantity;
                return 0;
            }

            int excessAmount = (FillLevel + waterQuantity) - MaxCapacity;
            FillLevel = MaxCapacity;

            return excessAmount;
        }

        public int Empty(int waterQuantity)
        {
            if (waterQuantity <= 0)
                return 0;

            if (waterQuantity <= FillLevel)
            {
                FillLevel -= waterQuantity;
                return waterQuantity;
            }

            int waterTaken = FillLevel;
            FillLevel = 0;

            return waterTaken;
        }

        public void Show()
        {
            int tankHeight = MaxCapacity / 10;

            Random rand = new Random();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"    Citerne n°{Number}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("               /============================");
            Console.WriteLine("              //");
            Console.WriteLine("             //");
            Console.WriteLine("╔═══════════\\ /═══════════╗");

            for (int i = 0; i < (tankHeight - Math.Ceiling((double)((FillLevel * tankHeight) / (double)MaxCapacity))); i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("║");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█████████████████████████");

                Console.ForegroundColor = ConsoleColor.DarkGray;

                Console.WriteLine("║");
            }

            for (int i = 0; i < (FillLevel * tankHeight) / MaxCapacity; i++)
            {

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("║");

                Console.ForegroundColor = ConsoleColor.Cyan;
                for (int j = 0; j < 25; j++)
                    if (rand.Next(1, 8) == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("º");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("█");
                    }

                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("║");
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("╚═════════════════════════╝");
            Console.WriteLine($"{FillLevel + " litre(s) sur " + MaxCapacity +  " - " + FillLevel * 100 / MaxCapacity + "%",19}");
            Console.WriteLine();
        }
    }
}
