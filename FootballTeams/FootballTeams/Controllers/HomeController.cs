using FootballTeams.Database;
using FootballTeams.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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
            if (player.NameTeam.Name == null)
            {
                Player newPlayer = new Player()
                {
                    Id = player.Id,
                    Name = player.Name,
                    Surname = player.Surname,
                    Gender = player.Gender,
                    DateBirth = player.DateBirth,
                    TeamId = player.TeamId,
                    Country = player.Country
                };

                _db.Players.Add(newPlayer);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                _db.Players.Add(player);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(player);
        }

        [HttpGet]
        public Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return Task.FromResult<IActionResult>(NotFound());
            }

            var playerFromDb = _db.Players.Find(id);

            if (playerFromDb == null)
            {
                return Task.FromResult<IActionResult>(NotFound());
            }

            ViewData["TeamId"] = new SelectList(_db.TeamNames, "Id", "Name");

            return Task.FromResult<IActionResult>(View(playerFromDb));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Player player)
        {
            if (player.NameTeam.Name == null)
            {
                Player newPlayer = new Player()
                {
                    Id = player.Id,
                    Name = player.Name,
                    Surname = player.Surname,
                    Gender = player.Gender,
                    DateBirth = player.DateBirth,
                    TeamId = player.TeamId,
                    Country = player.Country
                };

                _db.Players.Add(newPlayer);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                _db.Players.Add(player);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(player);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}