using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDVTT.Data;
using DnDVTT.Models;
using System.Threading.Tasks;

namespace DnDVTT.Controllers
{
    public class InventoryItemsController : Controller
    {
        private readonly VTTContext _context;

        public InventoryItemsController(VTTContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Add(int characterId, string name, string description, int quantity)
        {
            var item = new InventoryItem
            {
                CharacterID = characterId,
                Name = name,
                Description = description,
                Quantity = quantity
            };

            _context.InventoryItem.Add(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Character", new { id = characterId });
        }

        [HttpPost]
public async Task<IActionResult> Edit(InventoryItem item)
{
    _context.Update(item);
    await _context.SaveChangesAsync();
    return RedirectToAction("Details", "Character", new { id = item.CharacterID });
}


        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var item = await _context.InventoryItem.FindAsync(id);
            if (item == null) return NotFound();

            int characterId = item.CharacterID;
            _context.InventoryItem.Remove(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Character", new { id = characterId });
        }
    }
}