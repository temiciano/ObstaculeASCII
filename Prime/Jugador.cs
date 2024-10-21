using System;
using System.Collections.Generic;

namespace Prime
{
    class Jugador
    {
        private int x;
        private int y;
        private char simbolo;
        private int prevX;
        private int prevY;
        private List<Bala> balas;
        private Map map;

        public Jugador(int posX, int posY, char simboloJugador, Map map)
        {
            x = posX;
            y = posY;
            prevX = posX;
            prevY = posY;
            simbolo = simboloJugador;
            balas = new List<Bala>();
            this.map = map;
        }

        public void Dibujar()
        {
            Console.SetCursorPosition(prevX, prevY);
            Console.Write(' ');

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x, y);
            Console.Write(simbolo);

            prevX = x;
            prevY = y;
            
            foreach (var bala in balas)
            {
                bala.Dibujar();
            }
        }

        public void Mover()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);
                int newX = x;
                int newY = y;

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        newY = Math.Max(0, y - 1);
                        break;
                    case ConsoleKey.DownArrow:
                        newY = Math.Min(Console.WindowHeight - 1, y + 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        newX = Math.Max(0, x - 1);
                        break;
                    case ConsoleKey.RightArrow:
                        newX = Math.Min(Console.WindowWidth - 1, x + 1);
                        break;
                    case ConsoleKey.L:
                        Bala nuevaBala = new Bala(x, y - 1, '♦');
                        balas.Add(nuevaBala);
                        break;
                }

                if (!map.IsCollision(newX, newY))
                {
                    x = newX;
                    y = newY;
                }
            }

            foreach (var bala in balas)
            {
                bala.Mover();
            }

            balas.RemoveAll(b => b.Y == 0);
        }
    }
}