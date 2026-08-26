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
    public class BattleMapsController : Controller
    {
        private readonly VTTContext _context;

        public BattleMapsController(VTTContext context)
        {
            _context = context;
        }

        // GET: BattleMaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.BattleMaps.ToListAsync());
        }

        // GET: BattleMaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var battleMap = await _context.BattleMaps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (battleMap == null)
            {
                return NotFound();
            }

            return View(battleMap);
        }

        // GET: BattleMaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BattleMaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageUrl,Width,Height")] BattleMap battleMap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(battleMap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(battleMap);
        }

        // GET: BattleMaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var battleMap = await _context.BattleMaps.FindAsync(id);
            if (battleMap == null)
            {
                return NotFound();
            }
            return View(battleMap);
        }

        // POST: BattleMaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageUrl,Width,Height")] BattleMap battleMap)
        {
            if (id != battleMap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(battleMap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BattleMapExists(battleMap.Id))
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
            return View(battleMap);
        }

        // GET: BattleMaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var battleMap = await _context.BattleMaps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (battleMap == null)
            {
                return NotFound();
            }

            return View(battleMap);
        }

        // POST: BattleMaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var battleMap = await _context.BattleMaps.FindAsync(id);
            if (battleMap != null)
            {
                _context.BattleMaps.Remove(battleMap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BattleMapExists(int id)
        {
            return _context.BattleMaps.Any(e => e.Id == id);
        }
    }
}
