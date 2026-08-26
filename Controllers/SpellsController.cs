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
    public class SpellsController : Controller
    {
        private readonly VTTContext _context;

        public SpellsController(VTTContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(int characterId, string name, string description, int level)
        {
            var spell = new Spell
            {
                CharacterID = characterId,
                Name = name,
                Description = description,
                Level = level
            };
            
            _context.Spell.Add(spell);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Character", new { id = characterId });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Spell spell)
        {
            _context.Spell.Update(spell);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Character", new { id = spell.CharacterID });
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var spell = await _context.Spell.FindAsync(id);
            if (spell == null) return NotFound();

            int characterId = spell.CharacterID;
            _context.Spell.Remove(spell);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Character", new { id = characterId });
        }
    }
}