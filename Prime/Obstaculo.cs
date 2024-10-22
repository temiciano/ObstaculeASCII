using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    internal class Obstaculo
    {
        private string[] obstaculoData = new string[]
        {
        "▓",
        "▓",
        "     ▓",
        "▓",
        "▓",
        "     ▓",
        "▓",
        "▓"
        };

        public int X { get; private set; }
        public int Y { get; private set; }

        public Obstaculo(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < obstaculoData.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(obstaculoData[i]);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < obstaculoData.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.Write(new string(' ', obstaculoData[i].Length));
            }
        }

        public void MoveRight(int limit)
        {
            if (X < limit)
            {
                Clear();
                X++;
                Draw();
            }
        }
    }
}