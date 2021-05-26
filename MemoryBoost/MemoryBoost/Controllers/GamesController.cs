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
using MemoryBoost.Models.ViewModels;

namespace MemoryBoost.Controllers
{
    [Authorize]
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

        // GET: Games/Display/5
        [AllowAnonymous]
        public async Task<IActionResult> Display(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(g => g.Level)
                .Include(g => g.Player)
                .Include(g => g.Training)
                .ThenInclude(g => g.Games)
                .Include(g => g.Cards)
                .ThenInclude(g => g.Card)
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
                    cardList[randPlacement] = item.Card;
                    count++;
                }
            }

            var gameView = new GameViewModel
            {
                Id = game.Id,
                Level = game.Level,
                Score = game.Score,
                Time = game.Time,
                Cards = cardList,
                Training = game.Training,
                NumInQueue = game.NumInQueue
            };

            return View(gameView);
        }

        // GET: Games/Create
        [AllowAnonymous]
        public async Task<IActionResult> Create(Int32 levelId, Guid trainingId)
        {
            var level = await this._context.GameLevels
                .SingleOrDefaultAsync(x => x.Id == levelId);
            var training = await this._context.Trainings
                .Include(t => t.Games)
                .SingleOrDefaultAsync(x => x.Id == trainingId);

            if (level != null)
            {
                var game = new Game
                {
                    Created = DateTime.UtcNow,
                    LevelId = levelId,
                    Time = "00:00:00",
                    Score = 0,
                    Cards = new List<CardGame>()
                };

                if (User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.GetUserAsync(this.HttpContext.User);
                    game.Player = user;
                }

                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "CardGames", new { gameId = game.Id });
            }
            else //??????
            {
                var user = await _userManager.GetUserAsync(this.HttpContext.User);
                var numInQueue = 1;
                for (int i = 0; i < training.NumOfLevelOneGame; i++)
                {
                    var game = new Game
                    {
                        Created = DateTime.UtcNow,
                        Player = user,
                        LevelId = 1,
                        Score = 0,
                        Cards = new List<CardGame>(),
                        Training = training,
                        NumInQueue = numInQueue
                    };
                    numInQueue++;
                    training.Games.Add(game);
                    _context.Add(game);
                }
                for (int i = 0; i < training.NumOfLevelTwoGame; i++)
                {
                    var game = new Game
                    {
                        Created = DateTime.UtcNow,
                        Player = user,
                        LevelId = 2,
                        Score = 0,
                        Cards = new List<CardGame>(),
                        Training = training,
                        NumInQueue = numInQueue
                    };
                    numInQueue++;
                    training.Games.Add(game);
                    _context.Add(game);
                }
                for (int i = 0; i < training.NumOfLevelThreeGame; i++)
                {
                    var game = new Game
                    {
                        Created = DateTime.UtcNow,
                        Player = user,
                        LevelId = 3,
                        Score = 0,
                        Cards = new List<CardGame>(),
                        Training = training,
                        NumInQueue = numInQueue
                    };
                    numInQueue++;
                    training.Games.Add(game);
                    _context.Add(game);
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "CardGames", new { trainingId = training.Id });
            }
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
        public async Task<IActionResult> Results(String id, String score, String timer, String flag)
        {
            bool success = Int32.TryParse(score, out Int32 s);
            if (id == null)
            {
                return NotFound();
            }
            var game = await _context.Games
                .Include(g => g.Level)
                .Include(g => g.Player)
                .Include(g => g.Training)
                .ThenInclude(t => t.Games)
                .FirstOrDefaultAsync(m => m.Id.ToString() == id);

            if (game == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(this.HttpContext.User);
            if (user == null)
            {
                return View(game);
            }

            if (success)
            {
                game.Score = s;
            }
            else
            {
                game.Score = 0;
            }

            if (timer != null)
            {
                game.Time = timer;
            }

            await _context.SaveChangesAsync();
            if (game.Training != null)
            {
                Int32? numOfGamesInTraining = game.Training.NumOfLevelOneGame + game.Training.NumOfLevelTwoGame + game.Training.NumOfLevelThreeGame;
                List<Game> JustCreatedGames = (List<Game>)game.Training.Games.OrderByDescending(x => x.Created).ToList();

                if (game.NumInQueue == numOfGamesInTraining || flag == "UserStopped")
                {
                    return RedirectToAction("Results", "Trainings", new { id = game.Training.Id });
                }
                else
                {
                    foreach (var item in JustCreatedGames.Take((int)numOfGamesInTraining))
                    {
                        if (item.NumInQueue == (game.NumInQueue + 1))
                        {
                            return RedirectToAction("Display", "Games", new { id = item.Id });
                        }
                    }
                    return View(game);//////////
                }
            }
            else
            {
                return View(game);/////////////////
            }
        }
    }
}
