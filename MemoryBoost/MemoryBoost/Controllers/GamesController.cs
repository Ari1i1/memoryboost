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

namespace MemoryBoost.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRandomNumbersService _randomNumbersService;
        public GamesController(ApplicationDbContext context, IRandomNumbersService randomNumbersService)
        {
            _context = context;
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
                /*.Where(g => g.Id == id)*/
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
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
            var cardCollecttion = new Collection<Card>();
            foreach (var item in cards)
            {
                if (item.RandNum == randForCard)
                {
                    cardCollecttion.Add(item);
                }
            }
            var game = new Game
                {
                    LevelId = levelId,
                    Score = 0,
                    Cards = cardCollecttion
                };
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

       
        public async Task<IActionResult> SaveResults(String id, Int32 score)
        {
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

            game.Score = score;
            await _context.SaveChangesAsync();
            return View(game);
        }
    }
}
