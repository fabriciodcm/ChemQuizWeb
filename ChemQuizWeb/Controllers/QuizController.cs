using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuizWeb.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public QuizController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Levels/Create
        [Route("Create/{levelid}")]
        public IActionResult Create(long levelid)
        {
            if (!IsAuthor(levelid))
                return BadRequest();

            ViewBag.LevelId = levelid;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Post")]
        public async Task<IActionResult> Post([Bind("Question,Answer1,Answer2,Answer3,Answer4,CorrectAnswer,Points,LevelId")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                if (!IsAuthor(quiz.LevelId))
                    return BadRequest();

                _context.Add(quiz);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Levels", new { id = quiz.LevelId });
            }
            ViewBag.GameId = quiz.LevelId;
            return View(quiz);
        }

        // GET: Levels/Edit/5
        [HttpGet]
        [Route("Edit/{id}/{levelid}")]
        public async Task<IActionResult> Edit(long id, long levelid)
        {
            if (!QuizExists(id, levelid))
            {
                return NotFound();
            }

            var quiz = await _context.Quiz.FindAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Put/{id}")]
        public async Task<IActionResult> Edit(long id, [Bind("QuizId,Question,Answer1,Answer2,Answer3,Answer4,CorrectAnswer,Points,LevelId")] Quiz quiz)
        {
            if (id != quiz.QuizId || !QuizExists(quiz.QuizId, quiz.LevelId))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(quiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction("Details", "Levels", new { id = quiz.LevelId });
            }

            return View(quiz);
        }

        [HttpGet]
        [Route("Delete/{id}/{levelid}")]
        public async Task<IActionResult> Delete(long id, long levelid)
        {
            if (!QuizExists(id, levelid))
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                .Include(x => x.Level)
                .FirstOrDefaultAsync(m => m.QuizId == id);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Levels/Delete/5
        [HttpPost, ActionName("Del")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([Bind("QuizId,LevelId")] Quiz quiz)
        {
            if (!QuizExists(quiz.QuizId, quiz.LevelId))
            {
                return NotFound();
            }

            quiz = await _context.Quiz.FindAsync(quiz.QuizId);
            _context.Quiz.Remove(quiz);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Levels", new { id = quiz.LevelId });
        }

        // GET: Levels/Details/5
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(long id, long levelid)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _context.Quiz
                .Include(l => l.Level)
                .Include(l => l.Level.Game)
                .FirstOrDefaultAsync(m => m.QuizId == id
                && m.LevelId == levelid
                && m.Level.Game.AuthorId == _userManager.GetUserId(this.User));
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        private bool QuizExists(long id, long levelid)
        {
            return _context.Quiz
                .Include(e => e.Level)
                .Include(e => e.Level.Game)
                .Any(e => e.QuizId == id
                && e.LevelId == levelid
                && e.Level.Game.AuthorId == _userManager.GetUserId(this.User));
        }

        private bool IsAuthor(long levelid)
        {
            return _context.Level
                .Include(e => e.Game)
                .Any(e => e.LevelId == levelid
                && e.Game.AuthorId == _userManager.GetUserId(this.User));
        }
    }
}
