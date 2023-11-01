using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Home_Central.Data;
using Home_Central.Data.Entities;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Authorization;


namespace Home_Central.Controllers;

[Authorize]
public class WoningVerbruikController : Controller
{
    private readonly WoningDbContext _context;

    public WoningVerbruikController(WoningDbContext context)
    {
        _context = context;
    }

    // GET: WoningVerbruikModels
    public async Task<IActionResult> Index()
    {
          return _context.WoningVerbruik != null ? 
                      View(await _context.WoningVerbruik.ToListAsync()) :
                      Problem("Entity set 'WoningDbContext.WoningVerbruik'  is null.");
    }

    // GET: WoningVerbruikModels/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.WoningVerbruik == null)
        {
            return NotFound();
        }

        var woningVerbruikModel = await _context.WoningVerbruik
            .FirstOrDefaultAsync(m => m.Id == id);
        if (woningVerbruikModel == null)
        {
            return NotFound();
        }

        return View(woningVerbruikModel);
    }

    // GET: WoningVerbruikModels/Create
    public IActionResult Create()
    {
        WoningVerbruikModel wvm = new WoningVerbruikModel();
        wvm.datum = DateTime.Now;
        return View(wvm);
    }

    // POST: WoningVerbruikModels/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,datum,GasStand,DagTeller,NachtTeller,Zon")] WoningVerbruikModel woningVerbruikModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(woningVerbruikModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(woningVerbruikModel);
    }

    // GET: WoningVerbruikModels/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.WoningVerbruik == null)
        {
            return NotFound();
        }

        var woningVerbruikModel = await _context.WoningVerbruik.FindAsync(id);
        if (woningVerbruikModel == null)
        {
            return NotFound();
        }
        return View(woningVerbruikModel);
    }

    // POST: WoningVerbruikModels/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,datum,GasStand,DagTeller,NachtTeller,Zon")] WoningVerbruikModel woningVerbruikModel)
    {
        if (id != woningVerbruikModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(woningVerbruikModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WoningVerbruikModelExists(woningVerbruikModel.Id))
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
        return View(woningVerbruikModel);
    }

    // GET: WoningVerbruikModels/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.WoningVerbruik == null)
        {
            return NotFound();
        }

        var woningVerbruikModel = await _context.WoningVerbruik
            .FirstOrDefaultAsync(m => m.Id == id);
        if (woningVerbruikModel == null)
        {
            return NotFound();
        }

        return View(woningVerbruikModel);
    }

    // POST: WoningVerbruikModels/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.WoningVerbruik == null)
        {
            return Problem("Entity set 'WoningDbContext.WoningVerbruik'  is null.");
        }
        var woningVerbruikModel = await _context.WoningVerbruik.FindAsync(id);
        if (woningVerbruikModel != null)
        {
            _context.WoningVerbruik.Remove(woningVerbruikModel);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool WoningVerbruikModelExists(int id)
    {
      return (_context.WoningVerbruik?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
