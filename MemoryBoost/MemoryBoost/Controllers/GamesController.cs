using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MemoryBoost.Data;
using MemoryBoost.Models;
using System.Collections.ObjectModel;
using MemoryBoost.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MemoryBoost.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRandomNumbersService _randomNumbersService;
        public GamesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IRandomNumbersService randomNumbersService)
        {
            _context = context;
            _userManager = userManager;
            _randomNumbersService = randomNumbersService;
        }

        // GET: Games
        public async Task<IActionResult> Index(Guid id)
        {

            var applicationDbContext = await _context.Games
                .Include(g => g.Level)
                .Include(g => g.Player)
                .Include(g => g.Cards)
                .Where(g => g.Id == id).ToListAsync();
  
            return View(applicationDbContext);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.Level)
                .Include(g => g.Player)
                .Include(g => g.Cards)
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            var cardList = new List<Card>();
            var busyPlacements = new List<Boolean>();
            for (int i = 0; i < game.Level.CardsNumber; i++)
            {
                busyPlacements.Add(false);
                cardList.Add(null);
            }
            var randPlacement = -1;
            var count = 0;

            foreach (var item in game.Cards)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (count < game.Level.CardsNumber)
                    {
                        randPlacement = _randomNumbersService.GetRandomPlace(game.Level.CardsNumber);
                        while (busyPlacements[randPlacement])
                        {
                            randPlacement = _randomNumbersService.GetRandomPlace(game.Level.CardsNumber);
                        }
                    }
                    else
                        break;
                    busyPlacements[randPlacement] = true;
                    cardList[randPlacement] = item;
                    count++;
                }
            }

            game.Cards = cardList;
            return View(game);
        }

        // GET: Games/Create
        [AllowAnonymous]
        public async Task<IActionResult> Create(Int32 levelId)
        {
            var level = await this._context.GameLevels
                .SingleOrDefaultAsync(x => x.Id == levelId);

            if (level == null)
            {
                return this.NotFound();
            }

            var randForCard = _randomNumbersService.GetRandomNumber();
            var cards = await _context.Cards.ToListAsync(); //?????????????
            var cardList = new List<Card>();
            foreach (var item in cards)
            {
                if (item.RandNum == randForCard)
                {
                    cardList.Add(item);
                }
            }
            var game = new Game
            {
                Created = DateTime.UtcNow,
                LevelId = levelId,
                Score = 0,
                Cards = cardList
            };

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(this.HttpContext.User);
                game.Player = user;
            }

            _context.Add(game);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = game.Id });
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.Level)
                .Include(g => g.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var game = await _context.Games.FindAsync(id);
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(Guid id)
        {
            return _context.Games.Any(e => e.Id == id);
        }


        [HttpPost]
        public async Task<IActionResult> Results(String id, String score, String timer)
        {
            bool success = Int32.TryParse(score, out Int32 s);
            if (id == null)
            {
                return NotFound();
            }
            var game = await _context.Games
                .Include(g => g.Level)
                .Include(g => g.Player)
                .FirstOrDefaultAsync(m => m.Id.ToString() == id);

            if (game == null)
            {
                return NotFound();
            }
            if (success)
            {
                game.Score = s;
            }
            else
            {
                game.Score = 0;
            }
            game.Time = timer;
            await _context.SaveChangesAsync();
            return View(game);
        }
    }
}
