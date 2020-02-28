using Fr.Brocelia.MazeGen.BusinessLayer;
using DL = Fr.Brocelia.MazeGen.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static MazeWeb.Models.MazeWeb;

namespace MazeWeb.Models
{
  
    public class MazeDisplay
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Entree { get; set; }
        public int Sortie { get; set; }
        public List<DL.MazeTile> MazeTile { get; set; }
    }
}