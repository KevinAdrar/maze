using Fr.Brocelia.MazeGen.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DL = Fr.Brocelia.MazeGen.DataLayer;

namespace MazeWeb.Models
{
    public class MazeList
    {
        public IEnumerable<Maze> Maze { get; set; }
    }
}