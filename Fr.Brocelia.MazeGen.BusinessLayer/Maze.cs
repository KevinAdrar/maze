namespace Fr.Brocelia.MazeGen.BusinessLayer
{
    public enum MapType
    {
        Wall = '#',
        Free = '.',
        CurrentPos = '0',
        Path = '°',
        Unknown = '?',
        Explored = '*'
    }
    /// <summary>
    /// Représente un labyrinthe.
    /// </summary>
    public class Maze
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int Entree { get; set; }
        public int Sortie { get; set; }
        public  MapType[,] Map {get; set;}
    }

}
