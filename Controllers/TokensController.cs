using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDVTT.Data;
using DnDVTT.Models;

namespace DnDVTT.Controllers
{
    public class TokensController : Controller
    {
        private readonly VTTContext _context;

        public TokensController(VTTContext context)
        {
            _context = context;
        }

        // GET: Tokens
        public async Task<IActionResult> Index()
        {
            var vTTContext = _context.Tokens.Include(t => t.BattleMap);
            return View(await vTTContext.ToListAsync());
        }

        // GET: Tokens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var token = await _context.Tokens
                .Include(t => t.BattleMap)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (token == null)
            {
                return NotFound();
            }

            return View(token);
        }

        // GET: Tokens/Create
        public IActionResult Create()
        {
            ViewData["BattleMapId"] = new SelectList(_context.BattleMaps, "Id", "Id");
            return View();
        }

        // POST: Tokens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IconUrl,X,Y,BattleMapId")] Token token)
        {
            if (ModelState.IsValid)
            {
                _context.Add(token);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BattleMapId"] = new SelectList(_context.BattleMaps, "Id", "Id", token.BattleMapId);
            return View(token);
        }

        // GET: Tokens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var token = await _context.Tokens.FindAsync(id);
            if (token == null)
            {
                return NotFound();
            }
            ViewData["BattleMapId"] = new SelectList(_context.BattleMaps, "Id", "Id", token.BattleMapId);
            return View(token);
        }

        // POST: Tokens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IconUrl,X,Y,BattleMapId")] Token token)
        {
            if (id != token.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(token);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TokenExists(token.Id))
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
            ViewData["BattleMapId"] = new SelectList(_context.BattleMaps, "Id", "Id", token.BattleMapId);
            return View(token);
        }

        // GET: Tokens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var token = await _context.Tokens
                .Include(t => t.BattleMap)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (token == null)
            {
                return NotFound();
            }

            return View(token);
        }

        // POST: Tokens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var token = await _context.Tokens.FindAsync(id);
            if (token != null)
            {
                _context.Tokens.Remove(token);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TokenExists(int id)
        {
            return _context.Tokens.Any(e => e.Id == id);
        }
    }
}
