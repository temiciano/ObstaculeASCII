using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    class Bala
    {
        private int x;
        public int y;
        private char simbolo;
        private int prevX;
        private int prevY;
        public int X => x;
        public int Y => y;

        public Bala(int posX, int posY, char simboloBala)
        {
            x = posX;
            y = posY;
            prevX = posX;
            prevY = posY;
            simbolo = simboloBala;
        }

        public void Dibujar()
        {
            Console.SetCursorPosition(prevX, prevY);
            Console.Write(' ');

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.Write(simbolo);

            prevX = x;
            prevY = y;
        }

        public virtual void Mover()
        {
            y = Math.Max(0, y - 1);
        }

    }
}