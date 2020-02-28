using DL = Fr.Brocelia.MazeGen.DataLayer;
using Fr.Brocelia.MazeGen.BusinessLayer;
using Fr.Brocelia.MazeGen.ConsoleApp;//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MazeWeb.Models;

namespace MazeWeb.Controllers
{
    public class MazeWebController : Controller
    {
        public MazeService MazeService { get; set; }
        public Maze MazeInformations { get; set; }//

        public MazeWebController()
        {
            MazeService = new MazeService();
        }
        
        // GET: MazeWeb
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Display(int Id)
        {


            DL.Maze maze = MazeService.LireMaze(Id);

            MazeDisplay mazeDisplay = new MazeDisplay();
            mazeDisplay.Id = maze.Id;
            mazeDisplay.Length = maze.Length;
            mazeDisplay.Width = maze.Width;
            mazeDisplay.Entree = maze.Entree;
            mazeDisplay.Sortie = maze.Sortie;

            List<DL.MazeTile> mazeTile = MazeService.LireMazeTile(Id);
            mazeDisplay.MazeTile = mazeTile;

            

            return View(mazeDisplay);
        }

        public ActionResult Generate()
        {
            Maze maze = MazeService.Generate(10, 20);
            DL.Maze mazeDb = MazeService.CreateMazeDb(maze);         
            return RedirectToAction("Display", new { id = mazeDb.Id });
        }
    }
}