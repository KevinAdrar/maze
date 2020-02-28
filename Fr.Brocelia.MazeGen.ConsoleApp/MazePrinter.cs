using Fr.Brocelia.MazeGen.BusinessLayer;
using System;
using DL = Fr.Brocelia.MazeGen.DataLayer;//


namespace Fr.Brocelia.MazeGen.ConsoleApp
{
    class MazePrinter
    {
        public DL.MazeEntities mazeEntities { get; }//
        public Maze MazeInformations { get; set; }
        public MazePrinter(Maze infos)
        {
            MazeInformations = infos;
        }
        public void PrintAndPlay()
        {
            bool[,] explored = new bool[MazeInformations.Length, MazeInformations.Width];

            int x = 0;
            int y = MazeInformations.Entree;

            for (int i = 0; i < MazeInformations.Length; i++)
            {
                for (int j = 0; j < MazeInformations.Width; j++)
                {
                    explored[i, j] = true;
                }
            }

            while (true)
            {
                MazeInformations.Map[x, y] = MapType.CurrentPos;

                for (int i = 0; i < MazeInformations.Length; i++)
                {
                    for (int j = 0; j < MazeInformations.Width; j++)
                    {
                        if ((i >= x - 1 && i <= x + 1) && (j >= y - 1 && j <= y + 1))
                        {
                            explored[i, j] = true;
                        }
                        if (explored[i, j])
                        {
                            Console.Write((char)MazeInformations.Map[i, j]);
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine("");
                }

                MazeInformations.Map[x, y] = MapType.Free;

                if (x == MazeInformations.Length - 1 && y == MazeInformations.Sortie) break;

                InputArrow arrow = MazeInput.GetArrow();

                if (x > 0 && arrow == InputArrow.Up && MazeInformations.Map[x - 1, y] == MapType.Free) x--;
                if (arrow == InputArrow.Down && MazeInformations.Map[x + 1, y] == MapType.Free) x++;
                if (arrow == InputArrow.Left && MazeInformations.Map[x, y - 1] == MapType.Free) y--;
                if (arrow == InputArrow.Right && MazeInformations.Map[x, y + 1] == MapType.Free) y++;

                Console.Clear();
            }
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Well Play !");
        }
    }
}
