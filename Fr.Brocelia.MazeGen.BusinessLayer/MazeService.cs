using DL = Fr.Brocelia.MazeGen.DataLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace Fr.Brocelia.MazeGen.BusinessLayer
{
    /// <summary>
    /// Algorithme de génération de labyrinthe. 
    /// </summary>
    public class MazeService
    {
        public Maze MazeInformations { get; set; }
        private int CountToExit { get; set; }
        private List<Point> Exposed { get; set; } = new List<Point>();
        public MapType[,] ResolveMap { get; set; }
        public DL.MazeEntities mazeEntities { get; }

        public MazeService() {
            Exposed = new List<Point>();
            mazeEntities = new DL.MazeEntities();
        }
        /// <summary>
        /// Génère aléatoirement un nouveau labyrinthe  
        /// </summary>
        /// <param name="length">Longueur du labyrinthe</param>
        /// <param name="width">Largeur du labyrinthe</param>
        /// <returns>Le labyrinthe généré</returns>
        public Maze Generate(int length, int width)
        {
            Random rnd = new Random();
            this.MazeInformations = new Maze
            {
                Map = new MapType[length, width],
                Length = length,
                Width = width,
                Entree = rnd.Next(1, width - 1)
            };

            for (int i = 0; i < MazeInformations.Length; i++)
            {
                for (int j = 0; j < MazeInformations.Width; j++)
                {
                    if (i == 0 || i == MazeInformations.Length - 1 || j == 0 || j == MazeInformations.Width - 1)
                    {
                        MazeInformations.Map[i, j] = MapType.Wall;
                    }
                    else
                    {
                        MazeInformations.Map[i, j] = MapType.Unknown;
                    }
                }
            }

            MazeInformations.Map[0, MazeInformations.Entree] = MapType.Free;
            Point entreePoint = new Point(1, MazeInformations.Entree);
            Exposed.Add(entreePoint);

            while (Exposed.Any())
            {
                int rand = rnd.Next(Exposed.Count());

                Point point = Exposed[rand];

                if (Decide(point))
                {
                    Dig(point);
                }
                else
                {
                    MazeInformations.Map[point.X, point.Y] = MapType.Wall;
                }
                Exposed.RemoveAt(rand);
            }

            for (int i = 0; i < MazeInformations.Length; i++)
            {
                for (int j = 0; j < MazeInformations.Width; j++)
                {
                    if (MazeInformations.Map[i, j] == MapType.Unknown) MazeInformations.Map[i, j] = MapType.Wall;
                }
            }
            return MazeInformations;
        }

        public bool Decide(Point point)
        {
            int nb = 0;

            if (point.X > 0)
            {
                if (MazeInformations.Map[point.X - 1, point.Y]== MapType.Free)
                {
                    nb++;
                    if (point.Y > 0)
                    {
                        if (MazeInformations.Map[point.X + 1, point.Y + 1] == MapType.Free) nb++;
                    }
                    if (point.Y < MazeInformations.Width - 1)
                    {
                        if (MazeInformations.Map[point.X + 1, point.Y + 1] == MapType.Free) nb++;
                    }
                }
            }

            if (point.Y > 0)
            {
                if (MazeInformations.Map[point.X, point.Y - 1] == MapType.Free)
                {
                    nb++;

                    if (point.X > 0 && MazeInformations.Map[point.X - 1, point.Y +1] == MapType.Free)
                    {
                        nb++;
                    }
                    if (point.X < MazeInformations.Length - 1 && MazeInformations.Map[point.X +1, point.Y +1] == MapType.Free)
                    {
                        nb++;
                    }
                }
            }

            if (point.Y < MazeInformations.Width - 1)
            {
                if (MazeInformations.Map[point.X, point.Y + 1] == MapType.Free)
                {
                    nb++;

                    if (point.X > 0 && MazeInformations.Map[point.X - 1, point.Y - 1] == MapType.Free)
                    {
                        nb++;
                    }
                }
                if (point.X < MazeInformations.Length - 1 && MazeInformations.Map[point.X + 1, point.Y - 1] == MapType.Free)
                {
                    nb++;
                }
            }

            if (point.X < MazeInformations.Length - 1)
            {
                if (MazeInformations.Map[point.X + 1, point.Y] == MapType.Free)
                {
                    nb++;

                    if (point.X > 0 &&
                        MazeInformations.Map[point.X - 1, point.Y - 1] == MapType.Free)
                    {
                        nb++;
                    }
                    if (point.Y < MazeInformations.Width - 1 &&
                        MazeInformations.Map[point.X - 1, point.Y + 1] == (MapType.Free))
                    {
                        nb++;
                    }
                }
            }
            return nb == 1;
        }

        public void Dig(Point point)
        {
            MazeInformations.Map[point.X, point.Y] = MapType.Free;

            if (point.X > 1)
            {
                if (MazeInformations.Map[point.X - 1, point.Y] == MapType.Unknown)
                {
                    Point discoveredPoint = new Point(point.X - 1, point.Y);
                    Exposed.Add(discoveredPoint);
                }
            }

            if (point.X < MazeInformations.Length - 2)
            {
                if (MazeInformations.Map[point.X + 1, point.Y] == MapType.Unknown)
                {

                    Point discoveredPoint = new Point(point.X + 1, point.Y);
                    Exposed.Add(discoveredPoint);
                }
            }

            if (point.Y > 1)
            {
                if (MazeInformations.Map[point.X, point.Y - 1] == MapType.Unknown)
                {
                    Point discoveredPoint = new Point(point.X, point.Y - 1);
                    Exposed.Add(discoveredPoint);
                }
            }

            if (point.Y < MazeInformations.Width - 2)
            {
                if (MazeInformations.Map[point.X, point.Y + 1] == MapType.Unknown)
                {
                    Point discoveredPoint = new Point(point.X, point.Y + 1);
                    Exposed.Add(discoveredPoint);
                }
            }

            if (point.X == MazeInformations.Length - 2)
            {
                CountToExit += 1;
                if (CountToExit == MazeInformations.Width / 2 - 1)
                {
                    MazeInformations.Map[point.X + 1, point.Y] = MapType.Free;
                    this.MazeInformations.Sortie = point.Y;
                }
            }
        }
        public DL.Maze CreateMazeDb(Maze maze)
        {
            using (DL.MazeEntities context = new DL.MazeEntities())
            {
                DL.Maze newmaze = new DL.Maze();
                newmaze.Length = maze.Length;
                newmaze.Width = maze.Width;
                newmaze.Entree = maze.Entree;
                newmaze.Sortie = maze.Sortie;
                newmaze = context.Maze.Add(newmaze);

                for(int x = 0; x < maze.Length; x++)
                {
                    for(int y = 0; y < maze.Width; y++)
                    {
                        DL.MazeTile mazeTile = new DL.MazeTile();
                        MapType tile = maze.Map[x, y];
                        mazeTile.x = x;
                        mazeTile.y = y;
                        mazeTile.MazeId = newmaze.Id;
                        mazeTile.MapType = tile.ToString();//
                        context.MazeTile.Add(mazeTile);
                    }
                }
                context.SaveChanges();
                return newmaze;
            }
        } 
        
        public DL.Maze LireMaze (int maze)
        {
            return mazeEntities.Maze.Find(maze);
            //return mazeEntities.Maze.SingleOrDefault((x) => x.Id == maze);
            //return mazeEntities.Maze.FirstOrDefault((x) => x.Id == maze);
            //return mazeEntities.Maze.Where((x) => x.Id == maze).FirstOrDefault();
        }

        public List<DL.MazeTile> LireMazeTile (int mazeId)
        {
            return mazeEntities.MazeTile.Where(m => m.MazeId == mazeId).ToList();
        }
    }
}
