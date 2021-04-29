using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryBoost.Controllers
{
    public class GameMockupController : Controller
    {
        // GET: GameMockupController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GameMockupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GameMockupController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GameMockupController/Create
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

        // GET: GameMockupController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GameMockupController/Edit/5
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

        // GET: GameMockupController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GameMockupController/Delete/5
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
