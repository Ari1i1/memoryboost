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
using Microsoft.AspNetCore.Authorization;

namespace MemoryBoost.Controllers
{
    [Authorize]
    public class CardGamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRandomNumbersService _randomNumbersService;
        public CardGamesController(ApplicationDbContext context, IRandomNumbersService randomNumbersService)
        {
            _context = context;
            _randomNumbersService = randomNumbersService;
        }

        // GET: CardGames/Create
        [AllowAnonymous]
        public async Task<IActionResult> Create(Guid gameId, Guid trainingId)
        {
            var game = await _context.Games
                .Include(g => g.Cards)
                .SingleOrDefaultAsync(x => x.Id == gameId);

            var training = await _context.Trainings
                .Include(g => g.Games)
                .SingleOrDefaultAsync(x => x.Id == trainingId);

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
                    return this.RedirectToAction("Display", "Games", new { id = game.Id });
                }
            }
            else
            {
                Int32? numOfGamesInTraining = training.NumOfLevelOneGame + training.NumOfLevelTwoGame + training.NumOfLevelThreeGame;
                List<Game> JustCreatedGames = (List<Game>)training.Games.OrderByDescending(x => x.Created).ToList();
                    
                foreach (var g in JustCreatedGames.Take((int)numOfGamesInTraining))
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
                return this.RedirectToAction("Start", "Trainings", new { trainingId = training.Id });
            }
            return View();///////
        }
        
    }
}
