using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MemoryBoost.Data;
using MemoryBoost.Models;
using MemoryBoost.Services;

namespace MemoryBoost.Controllers
{
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRandomNumbersService _randomNumbersService;

        public CardsController(ApplicationDbContext context, IRandomNumbersService randomNumbersService)
        {
            _context = context;
            _randomNumbersService = randomNumbersService;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.ToListAsync());
        }

        // GET: Cards/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Cards/Create
        public async Task<IActionResult> Create(Guid? gameId)
        {
            if (gameId == null)
            {
                return NotFound();
            }
            var game = await this._context.Games
                .Include(g => g.Level)
                .SingleOrDefaultAsync(x => x.Id == gameId);

            if (game == null)
            {
                return this.NotFound();
            }
            var rand = new Random();
            for (int i = 0; i < game.Level.CardsNumber; i++)
            {
                var card = new Card
                {
                    GameId = gameId,
                    Check = _randomNumbersService.GetRandomNumber()
                    //тут картинки будут прикрепляться к карточке
                };
                _context.Add(card);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Games", new { id = game.Id });
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Card card)
        {
            if (ModelState.IsValid)
            {
                card.Id = Guid.NewGuid();
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] Card card)
        {
            if (id != card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var card = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(Guid id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }

        public async Task<IActionResult> FlipCard(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Cards
                .Include(c => c.Game)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            if (card.Game.NumberOfFlippedCards == 0)
            {
                card.Game.NumberOfFlippedCards = 1;
                await _context.SaveChangesAsync();
            }
            if (card.Game.NumberOfFlippedCards == 1)
            {
                card.Game.FirstFlippedCardId = card.Id;
                card.Game.NumberOfFlippedCards += 1;
                await _context.SaveChangesAsync();
                var game = await _context.Games
                    .Include(g => g.Level)
                    .Include(g => g.Player)
                    .Include(g => g.Cards)
                    .FirstOrDefaultAsync(m => m.Id == card.Game.Id);

                return RedirectToAction("Details", "Games", game);
            }
            else
            {
                var firstCard = await _context.Cards
                .Include(c => c.Game)
                .FirstOrDefaultAsync(m => m.Id == card.Game.FirstFlippedCardId);

                if (firstCard.Check == card.Check)
                {
                    card.Game.Score += 5;
                }
                else
                {
                    card.Game.Score -= 2;
                }
                card.Game.NumberOfFlippedCards = 0;
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Games", new { id = card.Game.Id });
            }

            
        }
    }
}
