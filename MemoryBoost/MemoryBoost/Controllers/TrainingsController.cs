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
                foreach (var item in training.Games)
                {
                    if (item.NumInQueue == 1)
                    {
                        return RedirectToAction("Details", "Games", new { id = item.Id });
                    }
                }
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
                return RedirectToAction("Create", "Games", new { trainingId = training.Id });
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

            var training = await _context.Trainings.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.Users, "Id", "Id", training.PlayerId);
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PlayerId,Created,NumOfLevelOneGame,NumOfLevelTwoGame,NumOfLevelThreeGame")] Training training)
        {
            if (id != training.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(training);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingExists(training.Id))
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
            ViewData["PlayerId"] = new SelectList(_context.Users, "Id", "Id", training.PlayerId);
            return View(training);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
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
            var training = await _context.Trainings.FindAsync(id);
            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(Guid id)
        {
            return _context.Trainings.Any(e => e.Id == id);
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
