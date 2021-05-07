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
using MemoryBoost.Models.ViewModels;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace MemoryBoost.Controllers
{
    public class CardsController : Controller
    {
        private static readonly HashSet<String> AllowedExtensions = new HashSet<String> { ".jpg", ".jpeg", ".png" };
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IRandomNumbersService _randomNumbersService;

        public CardsController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, IRandomNumbersService randomNumbersService)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _randomNumbersService = randomNumbersService;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.ToListAsync());
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            return View(new CardCreateViewModel());
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CardCreateViewModel model)
        {
            var fileName = Path.GetFileName(ContentDispositionHeaderValue.Parse(model.FilePath.ContentDisposition).FileName.Value.Trim('"'));
            var fileExt = Path.GetExtension(fileName);

            if (!AllowedExtensions.Contains(fileExt))
            {
                this.ModelState.AddModelError(nameof(model.FilePath), "This file type is prohibited");
            }
            if (ModelState.IsValid)
            {
                var card = new Card
                {
                    FileName = model.FileName,
                    RandNum = _randomNumbersService.GetRandomNumber()
                };
                var picPath = Path.Combine(_hostingEnvironment.WebRootPath, "pics", card.Id.ToString("N") + fileExt);
                card.FilePath = $"/pics/{card.Id:N}{fileExt}";
                using (var fileStream = new FileStream(picPath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read))
                {
                    await model.FilePath.CopyToAsync(fileStream);
                }
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FilePath,FileName")] Card card)
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
    }
}
