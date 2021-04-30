using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MemoryBoost.Data;
using MemoryBoost.Models;

namespace MemoryBoost.Controllers
{
    public class GameLevelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameLevelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameLevels
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameLevels.ToListAsync());
        }
    }     
}
