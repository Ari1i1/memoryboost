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

namespace MemoryBoost.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Games
        public async Task<IActionResult> Index(Guid? id)
        {

            var applicationDbContext = await _context.Games
                .Include(g => g.Level)
                .Include(g => g.Player)
                .Include(g => g.Cards)
                .Where(g => g.Id == id).ToListAsync();
  
            return View(applicationDbContext);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(Guid? id)
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

                var game = new Game
                {
                    LevelId = levelId,
                    Score = 0,
                    Cards = new Collection<Card>()
                };
                _context.Add(game);
                await _context.SaveChangesAsync();
            return RedirectToAction("Create", "Cards", new { gameId = game.Id });
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

        
    }
}
