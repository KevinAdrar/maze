using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Fr.Brocelia.MazeGen.DataLayer;
using System.ComponentModel.DataAnnotations.Schema;

namespace MazeWeb.Models
{
    public class MazeWeb
    {
        [Table("Maze")]
        public class Maze
        {
            public int Id { get; set; }
            public int Width { get; set; }
            public int Length { get; set; }
            public int Entree { get; set; }
            public int Sortie { get; set; }
        }

        [Table("MazeTile")]
        public class MazeTile
        {
            public int Id { get; set; }
            public int MazeId { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public char MapType { get; set; }
        }
        public partial class MazeEntities : DbContext
        {
            public virtual DbSet<Maze> Maze { get; set; }
            public virtual DbSet<MazeTile> MazeTile { get; set; }
        }
    }
}