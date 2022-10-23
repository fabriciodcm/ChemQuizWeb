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
using ChemQuizWeb.Infrastructure.Persistence.Context;

namespace ChemQuizWeb.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class LevelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public LevelsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Levels
        [Route("Index/{gameid}")]
        public async Task<IActionResult> Index(long gameid)
        {
            return RedirectToAction("Details", "Games", new { id = gameid });
        }

        // GET: Levels/Details/5
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var level = await _context.Level
                .Include(l => l.Game)
                .Include(l => l.Quizes)
                .FirstOrDefaultAsync(m => m.LevelId == id
                && m.Game.AuthorId == _userManager.GetUserId(this.User));
            if (level == null)
            {
                return NotFound();
            }

            return View(level);
        }

        // GET: Levels/Create
        [Route("Create/{gameid}")]
        public IActionResult Create(long gameid)
        {
            ViewBag.GameId = gameid;
            return View();
        }

        // POST: Levels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Post")]
        public async Task<IActionResult> Post([Bind("LevelDescription,LevelLesson,GameId")] Level level)
        {
            if (ModelState.IsValid)
            {
                var game = _context.Game.Include(x => x.Levels)
                    .First(x =>
                    x.GameId == level.GameId &&
                    x.AuthorId == _userManager.GetUserId(this.User)
                );
                level.LevelNumber = Convert.ToInt16(game.Levels.Count() + 1);
                _context.Add(level);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Games", new { id = level.GameId });
            }
            ViewBag.GameId = level.GameId;
            return View(level);
        }

        // GET: Levels/Edit/5
        [HttpGet]
        [Route("Edit/{id}/{gameid}")]
        public async Task<IActionResult> Edit(long id, long gameid)
        {
            if (!LevelExists(id, gameid))
            {
                return NotFound();
            }

            var level = await _context.Level.FindAsync(id);
            if (level == null)
            {
                return NotFound();
            }
            ViewBag.GameId = level.GameId;
            return View(level);
        }

        // POST: Levels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Put/{id}")]
        public async Task<IActionResult> Edit(long id, [Bind("LevelId,LevelDescription,LevelLesson,GameId")] Level level)
        {
            if (id != level.LevelId || !LevelExists(level.LevelId, level.GameId))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(level);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction("Details","Games",new { id = level.GameId});
            }
            ViewBag.GameId = level.GameId;
            return View(level);
        }

        // GET: Levels/Delete/5
        [HttpGet]
        [Route("Delete/{id}/{gameid}")]
        public async Task<IActionResult> Delete(long id, long gameid)
        {
            if (!LevelExists(id,gameid))
            {
                return NotFound();
            }

            var level = await _context.Level
                .Include(l => l.Game)
                .FirstOrDefaultAsync(m => m.LevelId == id);
            if (level == null)
            {
                return NotFound();
            }

            return View(level);
        }

        // POST: Levels/Delete/5
        [HttpPost, ActionName("Del")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([Bind("LevelId,GameId")] Level level)
        {
            if (!LevelExists(level.LevelId, level.GameId))
            {
                return NotFound();
            }

            level = await _context.Level.FindAsync(level.LevelId);
            _context.Level.Remove(level);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Games", new { id = level.GameId });
        }

        private bool LevelExists(long id, long gameid)
        {
            return _context.Level.Include(e => e.Game)
                .Any(e => e.LevelId == id
                && e.GameId == gameid
                && e.Game.AuthorId == _userManager.GetUserId(this.User));
        }
    }
}
