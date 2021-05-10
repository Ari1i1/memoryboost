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
    public class CardGamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRandomNumbersService _randomNumbersService;
        public CardGamesController(ApplicationDbContext context, IRandomNumbersService randomNumbersService)
        {
            _context = context;
            _randomNumbersService = randomNumbersService;
        }

        // GET: CardGames
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CardGames.Include(c => c.Card).Include(c => c.Game);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CardGames/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardGame = await _context.CardGames
                .Include(c => c.Card)
                .Include(c => c.Game)
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (cardGame == null)
            {
                return NotFound();
            }

            return View(cardGame);
        }

        // GET: CardGames/Create
        public async Task<IActionResult> Create(Guid gameId, Guid trainingId)
        {
            /* if (gameId == null || trainingId == null)
             {
                 return NotFound();
             }*/

            var game = await _context.Games
                .Include(g => g.Cards)
                .SingleOrDefaultAsync(x => x.Id == gameId);

            var training = await _context.Trainings
                .Include(g => g.Games)
                .SingleOrDefaultAsync(x => x.Id == trainingId);

            /*if (game == null)
            {
                return NotFound();
            }*/
            if (game != null)
            {
                var randForCard = _randomNumbersService.GetRandomNumber();
                var cards = await _context.Cards
                    .ToListAsync();
                var cardList = new List<Card>();
                foreach (var item in cards)
                {
                    if (item.RandNum == randForCard)
                    {
                        cardList.Add(item);
                    }
                }
                if (ModelState.IsValid)
                {
                    foreach (var item in cardList)
                    {
                        var cardGame = new CardGame
                        {
                            Game = game,
                            Card = item
                        };
                        _context.Add(cardGame);
                    }
                    await _context.SaveChangesAsync();
                    return this.RedirectToAction("Details", "Games", new { id = game.Id });
                }
            }
            else
            {
                foreach (var g in training.Games)
                {
                    var randForCard = _randomNumbersService.GetRandomNumber();
                    var cards = await _context.Cards
                        .ToListAsync();
                    var cardList = new List<Card>();
                    foreach (var item in cards)
                    {
                        if (item.RandNum == randForCard)
                        {
                            cardList.Add(item);
                        }
                    }
                    if (ModelState.IsValid)
                    {
                        foreach (var item in cardList)
                        {
                            var cardGame = new CardGame
                            {
                                Game = g,
                                Card = item
                            };
                            _context.Add(cardGame);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                return this.RedirectToAction("Details", "Trainings", new { id = training.Id });
            }
            return View();///////
        }


        // GET: CardGames/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardGame = await _context.CardGames.FindAsync(id);
            if (cardGame == null)
            {
                return NotFound();
            }
            ViewData["CardId"] = new SelectList(_context.Cards, "Id", "FileName", cardGame.CardId);
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", cardGame.GameId);
            return View(cardGame);
        }

        // POST: CardGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CardId,GameId")] CardGame cardGame)
        {
            if (id != cardGame.CardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardGameExists(cardGame.CardId))
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
            ViewData["CardId"] = new SelectList(_context.Cards, "Id", "FileName", cardGame.CardId);
            ViewData["GameId"] = new SelectList(_context.Games, "Id", "Id", cardGame.GameId);
            return View(cardGame);
        }

        // GET: CardGames/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardGame = await _context.CardGames
                .Include(c => c.Card)
                .Include(c => c.Game)
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (cardGame == null)
            {
                return NotFound();
            }

            return View(cardGame);
        }

        // POST: CardGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cardGame = await _context.CardGames.FindAsync(id);
            _context.CardGames.Remove(cardGame);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardGameExists(Guid id)
        {
            return _context.CardGames.Any(e => e.CardId == id);
        }
    }
}
