using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BettingWebApp.Data;
using BettingWebApp.Models;

namespace BettingWebApp.Controllers
{
    public class MatchOddsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public MatchOddsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MatchOdds
        public async Task<IActionResult> Index(int? matchId)
        {

            ViewBag.matchID = matchId;
            return View(await _context.MatchOdd.Where(i => i.MatchID == matchId).ToListAsync());
        }

        // GET: MatchOdds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchOdd = await _context.MatchOdd
                .FirstOrDefaultAsync(m => m.ID == id);
            if (matchOdd == null)
            {
                return NotFound();
            }

            return View(matchOdd);
        }

        // GET: MatchOdds/Create
        public IActionResult Create(int? matchId)
        {
            ViewData["MatchID"] = matchId;
            return View();
        }


        // POST: MatchOdds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MatchID,Specifier,Odd")] MatchOdd matchOdd)
        {
            if (ModelState.IsValid)
            {

                _context.Add(matchOdd);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Select", "Matches", new { id = matchOdd.MatchID });
            }
            return View(matchOdd);
        }

        // GET: MatchOdds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchOdd = await _context.MatchOdd.FindAsync(id);
            if (matchOdd == null)
            {
                return NotFound();
            }
            return View(matchOdd);
        }

        // POST: MatchOdds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MatchID,Specifier,Odd")] MatchOdd matchOdd)
        {
            if (id != matchOdd.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matchOdd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchOddExists(matchOdd.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Select", "Matches", new { id = matchOdd.MatchID });
            }
            return View(matchOdd);
        }

        // GET: MatchOdds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matchOdd = await _context.MatchOdd
                .FirstOrDefaultAsync(m => m.ID == id);
            if (matchOdd == null)
            {
                return NotFound();
            }

            return View(matchOdd);
        }

        // POST: MatchOdds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matchOdd = await _context.MatchOdd.FindAsync(id);
            _context.MatchOdd.Remove(matchOdd);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Select", "Matches", new { id = matchOdd.MatchID });
        }

        private bool MatchOddExists(int id)
        {
            return _context.MatchOdd.Any(e => e.ID == id);
        }
    }
}
