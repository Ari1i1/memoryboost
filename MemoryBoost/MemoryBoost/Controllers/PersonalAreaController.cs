using MemoryBoost.Data;
using MemoryBoost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Controllers
{
    [Authorize]
    public class PersonalAreaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public PersonalAreaController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        // GET: PersonalAreaController
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(this.HttpContext.User);
            var games = await _context.Games
                .Include(g => g.Level)
                .Include(g => g.Player)
                .Where(g => g.PlayerId == user.Id)
                .ToListAsync();

            return View(games);
        }

        // GET: PersonalAreaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonalAreaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalAreaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonalAreaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonalAreaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonalAreaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonalAreaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
