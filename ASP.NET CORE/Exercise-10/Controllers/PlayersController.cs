using System.Linq;
using Exercise_10.Data;
using Exercise_10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exercise_10.Controllers
{
    public class PlayersController : Controller
    {
        public readonly PlayerDbContext _context;
        public PlayersController(PlayerDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Players = _context.Players
                .Include(p => p.Team)
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToList();

            ViewBag.Teams = _context.Teams
                .OrderBy(t => t.Name)
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Player playerToAdd)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Players = _context.Players
                    .Include(p => p.Team)
                    .OrderBy(p => p.LastName)
                    .ThenBy(p => p.FirstName);

                ViewBag.Teams = _context.Teams
                    .OrderBy(t => t.Name)
                    .ToList();

                return View("Index", playerToAdd);
            }

            ViewBag.Teams = _context.Teams
                    .OrderBy(t => t.Name)
                    .ToList();

            _context.Players.Add(playerToAdd);
            _context.SaveChanges();

            return RedirectToAction("Index"); //302
        }
    }
}
