using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDVTT.Data;
using DnDVTT.Models;

public class CharacterController : Controller
{
    private readonly VTTContext _context;

    public CharacterController(VTTContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Character character)
    {
        if (ModelState.IsValid)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = character.Id });
        }
        return View(character);
    }

    public async Task<IActionResult> Details(int id)
    {
        var character = await _context.Characters
            .Include(c => c.InventoryItems)
            .Include(c => c.Spells)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (character == null) 
            return NotFound();
        
        return View(character);
    }
    public async Task<IActionResult> Index()
    {
        var characters = await _context.Characters.ToListAsync();
        return View(characters);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character == null) return NotFound();
        return View(character);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Character character)
    {
        if (!ModelState.IsValid) return View(character);

        _context.Update(character);
        await _context.SaveChangesAsync();
        return RedirectToAction("Details", new { id = character.Id });
    }

}
