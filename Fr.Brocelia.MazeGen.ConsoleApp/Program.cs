using Fr.Brocelia.MazeGen.BusinessLayer;
using System;



namespace Fr.Brocelia.MazeGen.ConsoleApp
{
    /// <summary>
    /// Lanceur via ligne de commande.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Point d'entrée.
        /// </summary>
        /// <param name="args">Arguments de la ligne de commande</param>
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            MazeService mazeDb = new MazeService();
            Maze maze = mazeDb.Generate(10, 20);
            mazeDb.CreateMazeDb(maze);
            MazePrinter mazePrint = new MazePrinter(maze);
            mazePrint.PrintAndPlay();
            Console.ReadKey(true);
            Console.ReadLine();


           
        }
    }
}
