using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    internal class Map
    {
        private string[] mapData = new string[]
        {
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        " ",
        "###################################################################",
        "#                                                                 #",
        "#                                                                 #",
        "#                                                                 #",
        "#                                                                 #",
        "#                                                                 #",
        "#                                                                 #",
        "#                                                                 #",
        "#                                                                 #",
        "###################################################################"
        };

        public void Draw()
        {
            Console.Clear();
            foreach (var line in mapData)
            {
                Console.WriteLine(line);
            }
        }

        public bool IsCollision(int x, int y)
        {
            // || = or
            if (x < 0 || y < 0 || y >= mapData.Length || x >= mapData[y].Length)
            {
                return true;
            }
            return mapData[y][x] == '#';
        }
    }
}