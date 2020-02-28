using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fr.Brocelia.MazeGen.DataLayer;

namespace MazeWeb.Controllers
{
    public class MazesListController : Controller
    {
        private MazeEntities db = new MazeEntities();

        // GET: MazesList
        public ActionResult Index()
        {
            return View(db.Maze.ToList());
        }
    }
}
