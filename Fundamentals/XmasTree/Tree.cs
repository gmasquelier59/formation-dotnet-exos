using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace XmasTree
{
    internal class Tree
    {
        private readonly int _leafsHeight;
        private readonly int _trunkHeight;

        private ConsoleColor[] ballsColors = { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Yellow, ConsoleColor.Magenta };
        public Tree(int height)
        {
            this._leafsHeight = height;
            this._trunkHeight = height <= 5 ? 3 : height / 3;
        }

        public void Draw()
        {
            while (1 == 1)
            {
                Console.Clear();
                this.DrawOnce();
                Thread.Sleep(800);
            }
        }

        private void DrawOnce()
        {
            this.drawLeafsAndBalls();
            this.DrawTrunk();
        }

        private void drawLeafsAndBalls()
        {
            for (int i = 1; i < this.LeafsHeight; i++)
            {
                Console.Write(string.Concat(System.Linq.Enumerable.Repeat(" ", (this.LeafsHeight - i))));

                Random random = new Random();
                for (int j = 0; j < i * 2 - 1; j++)
                {
                    if (random.Next(1, 100) % 2 == 0)
                    {
                        Console.ForegroundColor = this.ballsColors[random.Next(0, this.ballsColors.Length)];
                        Console.Write('O');
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write('*');
                    }

                }

                Console.WriteLine();

            }
            Console.ResetColor();
        }
        private void DrawTrunk()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < this.TrunkHeight; i++)
            {
                Console.WriteLine(string.Concat(System.Linq.Enumerable.Repeat(" ", (this.LeafsHeight - 2))) + "███");
            }
            Console.ResetColor();
        }

        public int LeafsHeight
        {
            get => _leafsHeight;
        }

        public int TrunkHeight
        {
            get => _trunkHeight;
        }
    }
}