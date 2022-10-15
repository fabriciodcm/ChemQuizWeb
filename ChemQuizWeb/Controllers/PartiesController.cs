using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChemQuizWeb.Core.Entities;
using ChemQuizWeb.Models;
using Microsoft.AspNetCore.Authorization;
using ChemQuizWeb.Core.Entities;

namespace ChemQuizWeb.Controllers
{
    [Authorize]
    public class PartiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Party.ToListAsync());
        }

        // GET: Parties/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Party
                .Include(x => x.Games)
                .ThenInclude(z => z.Category)
                .Include(x => x.Games)
                .ThenInclude(z => z.Author)
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.PartyId == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // GET: Parties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartyId,PartyName,PartyDescription")] Party party)
        {
            if (ModelState.IsValid)
            {
                _context.Add(party);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(party);
        }

        // GET: Parties/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Party.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }
            return View(party);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("PartyId,PartyName,PartyDescription")] Party party)
        {
            if (id != party.PartyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(party);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyExists(party.PartyId))
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
            return View(party);
        }

        // GET: Parties/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Party
                .FirstOrDefaultAsync(m => m.PartyId == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var party = await _context.Party.FindAsync(id);
            _context.Party.Remove(party);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddGame(long? Id)
        {
            if (Id.HasValue && PartyExists(Id.Value))
            {
                ViewBag.PartyId = Id;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGame(long GameId, long PartyId)
        {
            if (PartyExists(PartyId) && !GameExists(PartyId, GameId))
            {
                var party = await _context.Party.FindAsync(PartyId);
                var game = await _context.Game.FindAsync(GameId);
                party.Games.Add(game);
                _context.Update(party);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(long id, long gameId)
        {
            return _context.Party.Any(e => e.PartyId == id && e.Games.Any(g => g.GameId == gameId));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGame(long Id, long gameId)
        {
            if (GameExists(Id,gameId))
            {
                var party = await _context.Party.FindAsync(Id);
                var game = await _context.Game.Include(x => x.Author)
                    .Include(x => x.Category)
                    .FirstOrDefaultAsync(x => x.GameId == gameId);
                var partyGame = new PartyGameViewModel(party, game);
                return View(partyGame);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteGameConfirmed(long GameId, long PartyId)
        {
            if (PartyExists(PartyId) && GameExists(PartyId, GameId))
            {
                var party = await _context.Party
                    .Include(x => x.Games)
                    .FirstOrDefaultAsync(x => x.PartyId == PartyId);
                var game = await _context.Game.FindAsync(GameId);
                party.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddMember(long? Id)
        {
            if (Id.HasValue &&  PartyExists(Id.Value))
            {
                ViewBag.PartyId = Id;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMember(string email, long PartyId)
        {
            var user = await _context.AppUser.FirstOrDefaultAsync(x => x.Email == email);

            if (user != null && PartyExists(PartyId) && !UserExists(PartyId, user.Id))
            {
                var party = await _context.Party.FindAsync(PartyId);
                
                party.Users.Add(user);
                _context.Update(party);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(long id, string userId)
        {
            return _context.Party.Any(e => e.PartyId == id && e.Users.Any(g => g.Id == userId));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMember(long Id, string userId)
        {
            if (UserExists(Id, userId))
            {
                var party = await _context.Party.FindAsync(Id);
                var user = await _context.AppUser.FindAsync(userId);
                var partyMember = new PartyMemberViewModel(party, user);
                return View(partyMember);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMemberConfirmed(string UserId, long PartyId)
        {
            if (PartyExists(PartyId) && UserExists(PartyId, UserId))
            {
                var party = await _context.Party
                    .Include(x => x.Users)
                    .FirstOrDefaultAsync(x => x.PartyId == PartyId);
                var user = await _context.AppUser.FindAsync(UserId);
                party.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PartyExists(long id)
        {
            return _context.Party.Any(e => e.PartyId == id);
        }
    }
}
