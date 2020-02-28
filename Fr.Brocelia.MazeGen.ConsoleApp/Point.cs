using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Brocelia.MazeGen.ConsoleApp
{
    public struct Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public Point(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
}
