using FootballTeams.Database;
using FootballTeams.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FootballTeams.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public Task<IActionResult> Index()
        {
            IEnumerable<Player> playerList = _db.Players.Include(t => t.NameTeam);

            return Task.FromResult<IActionResult>(View(playerList));
        }


        [HttpGet]
        public Task<IActionResult> Create()
        {
            ViewData["TeamId"] = new SelectList(_db.TeamNames, "Id", "Name");

            return Task.FromResult<IActionResult>(View());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Player player)
        {
            _db.Players.Add(player);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var playerFromDb = _db.Players.Find(id);

            if (playerFromDb == null)
            {
                return NotFound();
            }

            ViewData["TeamId"] = new SelectList(_db.TeamNames, "Id", "Name");

            return View(playerFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (!ModelState.IsValid || _db.TeamNames.Where(x => x.Name == player.NameTeam.Name).Count() > 0)
            {
                _db.TeamNames.Add(player.NameTeam);
                _db.SaveChanges();
                ViewBag.Teams = new SelectList(_db.TeamNames, "Id", "Name");

                return View(player);
            }

            _db.Players.Update(player);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}