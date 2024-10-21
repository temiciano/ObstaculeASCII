using Prime;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Threading;
using System.Timers;

class Program
{
    private static readonly object lockObject = new object();
    private static List<BalaEnemigo> balasEnemigas = new List<BalaEnemigo>();
    private static Map map;

    static void Personaje()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(30, 15);
        Console.Write('☻');
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        Ventana ventana = new Ventana(70, 30);

        Map map = new Map();
        map.Draw();

        Personaje();
                
        Jugador jugador = new Jugador(14, 20, '☻', map);

        System.Timers.Timer moveTimer = new System.Timers.Timer(60);
        moveTimer.Elapsed += (sender, e) => MoveBullets(jugador);
        moveTimer.AutoReset = true;
        moveTimer.Enabled = true;

        System.Timers.Timer spawnTimer = new System.Timers.Timer(500);
        spawnTimer.Elapsed += (sender, e) => SpawnBullet();
        spawnTimer.AutoReset = true;
        spawnTimer.Enabled = true;

        while (true)
        {
            Thread.Sleep(1000);
        }

    }

    private static void MoveBullets(Jugador jugador)
    {
        lock (lockObject)
        {
            jugador.Dibujar();
            jugador.Mover();

            foreach (var balaEnemigo in balasEnemigas.ToList())
            {
                balaEnemigo.Dibujar();
                balaEnemigo.Mover();

                if (balaEnemigo.Y >= 29)
                {
                    balasEnemigas.Remove(balaEnemigo);
                }
            }
        }
    }

    private static void SpawnBullet()
    {
        lock (lockObject)
        {
            int posX = 33; 
            int posY = 0;
            balasEnemigas.Add(new BalaEnemigo(posX, posY, '♥'));
        }
    }
}