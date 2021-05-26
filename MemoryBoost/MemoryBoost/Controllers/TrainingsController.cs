using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MemoryBoost.Data;
using MemoryBoost.Models;
using MemoryBoost.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MemoryBoost.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public TrainingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trainings.Include(t => t.Player);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trainings/Details/5
        [Authorize]
        public async Task<IActionResult> Details()
        {
            var user = await _userManager.GetUserAsync(this.HttpContext.User);
            var id = user.Id;

            if (id == null)
            {
                return NotFound();
            }

            var trainings = await _context.Trainings
                .Include(t => t.Games)
                .ThenInclude(g => g.Cards)
                .Include(t => t.Player)
                .FirstOrDefaultAsync(m => m.PlayerId == id);

            if (trainings == null)
            {
                return RedirectToAction("Create");
            }
            else
            {
 //если несколько тренировок то выбор иначе нет и если после только создания попадаем
              return RedirectToAction("Index");

            }
        }
        public async Task<IActionResult> Start(Guid trainingId)
        {
            var user = await _userManager.GetUserAsync(this.HttpContext.User);

            if (user.Id == null)
            {
                return NotFound();
            }

            if (trainingId == null)
            {
                return NotFound();
            }
            var training = await _context.Trainings
                .Include(t => t.Games)
                .ThenInclude(g => g.Cards)
                .Include(t => t.Player)
                .FirstOrDefaultAsync(m => m.Id == trainingId);

            if (training == null)
            {
                return NotFound();
            }

            Int32? numOfGamesInTraining = training.NumOfLevelOneGame + training.NumOfLevelTwoGame + training.NumOfLevelThreeGame;
            List<Game> JustCreatedGames = (List<Game>)training.Games.OrderByDescending(x => x.Created).ToList();

            foreach (var item in JustCreatedGames.Take((int)numOfGamesInTraining))
            {
                if (item.NumInQueue == 1)
                {
                    return RedirectToAction("Details", "Games", new { id = item.Id });
                }
            }

            return RedirectToAction("Index"); /////////////////

        }
        public async Task<IActionResult> ChooseTraining(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
                .Include(t => t.Games)
                .ThenInclude(g => g.Cards)
                .Include(t => t.Player)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (training == null)
            {
                return NotFound();
            }
            else
            {
                return RedirectToAction("Create", "Games", new { trainingId = training.Id });
                /*foreach (var item in training.Games)
                {
                    if (item.NumInQueue == 1)
                    {
                        return RedirectToAction("Details", "Games", new { id = item.Id });
                    }
                }*/
            }
            return NotFound();
        }
        // GET: Trainings/Create
        public IActionResult Create()
        {
            return View(new TrainingCreateViewModel());
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingCreateViewModel model)
        {
            if (model.NumOfLevelOneGame + model.NumOfLevelTwoGame + model.NumOfLevelThreeGame > 20 || model.NumOfLevelOneGame + model.NumOfLevelTwoGame + model.NumOfLevelThreeGame < 1)
            {
                ModelState.AddModelError("NumOfLevelThreeGame", "The number of games in the training must be from 1 to 20");
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(this.HttpContext.User);
                var training = new Training
                {
                    Name = model.Name,
                    Player = user,
                    Created = DateTime.UtcNow,
                    NumOfLevelOneGame = model.NumOfLevelOneGame,
                    NumOfLevelTwoGame = model.NumOfLevelTwoGame,
                    NumOfLevelThreeGame = model.NumOfLevelThreeGame,
                    Games = new List<Game>()
                };
                _context.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PersonalArea");
            }
            
            return View(model);
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
                .SingleOrDefaultAsync(m => m.Id == id);

            if (training == null)
            {
                return NotFound();
            }
            var model = new TrainingEditViewModel()
            {
                Name = training.Name,
                NumOfLevelOneGame = training.NumOfLevelOneGame,
                NumOfLevelTwoGame = training.NumOfLevelTwoGame,
                NumOfLevelThreeGame = training.NumOfLevelThreeGame
            };
            return View(model);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TrainingEditViewModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
               .SingleOrDefaultAsync(m => m.Id == id);

            if (training == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                training.Name = model.Name;
                training.NumOfLevelOneGame = model.NumOfLevelOneGame;
                training.NumOfLevelTwoGame = model.NumOfLevelTwoGame;
                training.NumOfLevelThreeGame = model.NumOfLevelThreeGame;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PersonalArea");
            }

            return View(model);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
                .Include(t => t.Games)
                .ThenInclude(g => g.Cards)
                .Include(t => t.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
                .Include(t => t.Games)
                .ThenInclude(g => g.Cards)
                .Include(t => t.Player)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (training == null)
            {
                return NotFound();
            }

            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PersonalArea");
        }

        public async Task<IActionResult> Results(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var training = await _context.Trainings
                .Include(t => t.Games)
                .ThenInclude(g => g.Level)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }
    }
}
