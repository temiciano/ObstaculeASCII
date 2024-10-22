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
    private static Obstaculo obstaculo;

    static void Personaje()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(33, 4);
        Console.Write('☠');
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        Ventana ventana = new Ventana(70, 30);

        map = new Map();
        map.Draw();

        obstaculo = new Obstaculo(1, 20);
        obstaculo.Draw();

        Personaje();

        Jugador jugador = new Jugador(62, 20, '☻', map);

        System.Timers.Timer moveTimer = new System.Timers.Timer(60);
        moveTimer.Elapsed += (sender, e) => MoveElements(jugador);
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

    private static void MoveElements(Jugador jugador)
    {
        lock (lockObject)
        {
            obstaculo.MoveRight(60);

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
            int posY = 5;
            balasEnemigas.Add(new BalaEnemigo(posX, posY, 'V'));
        }
    }
}