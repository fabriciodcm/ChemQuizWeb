using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChemQuizWeb.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ChemQuizWeb.Core.Interfaces.Services;

namespace ChemQuizWeb.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly IGameService _service;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public GamesController(IGameService service, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _service = service;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            return View(await _service.FindByUser(_userManager.GetUserId(this.User)));
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _service.FindByUser(id.Value, _userManager.GetUserId(this.User));
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryService.FindAll(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GameId,GameName,GameDescription,CategoryId,AuthorId")] Game game)
        {
            game.AuthorId = _userManager.GetUserId(this.User);
            if (ModelState.IsValid)
            {
                _service.Create(game);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.FindAll(), "CategoryId", "CategoryName", game.CategoryId);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _service.FindByUser(id.Value, _userManager.GetUserId(this.User));
            if (game == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.FindAll(), "CategoryId", "CategoryName", game.CategoryId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("GameId,GameName,GameDescription,CategoryId,AuthorId")] Game game)
        {
            if (id != game.GameId)
                return NotFound();

            var isGameAuthor = await _service.FindByUser(id, game.AuthorId);
            if (isGameAuthor == null || isGameAuthor.AuthorId != _userManager.GetUserId(this.User))
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(game);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.Exists(game.GameId))
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
            ViewData["CategoryId"] = new SelectList(_categoryService.FindAll(), "CategoryId", "CategoryName", game.CategoryId);
            return View(await _service.FindByUser(id, _userManager.GetUserId(this.User)));
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _service.FindByUser(id.Value, _userManager.GetUserId(this.User));
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
