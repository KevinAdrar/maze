using Fr.Brocelia.MazeGen.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MazeWeb.Models
{
    public class MazePrint
    {
        public int Id { get; set; }
        public int MazeId { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public MapType MapType { get; set; }
    }
}