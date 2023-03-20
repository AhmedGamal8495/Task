using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Controllers
{
    public class RrealEstateController : Controller
    {
        private readonly NwcContext _context;

        public RrealEstateController(NwcContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.NwcRrealEstateTypes != null ? 
                          View(await _context.NwcRrealEstateTypes.ToListAsync()) :
                          Problem("Entity set 'NwcContext.NwcRrealEstateTypes'  is null.");
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NwcRrealEstateTypesCode,NwcRrealEstateTypesName,NwcRrealEstateTypesReasons")] NwcRrealEstateType nwcRrealEstateType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nwcRrealEstateType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nwcRrealEstateType);
        }


        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NwcRrealEstateTypes == null)
            {
                return NotFound();
            }

            var nwcRrealEstateType = await _context.NwcRrealEstateTypes.FindAsync(id);
            if (nwcRrealEstateType == null)
            {
                return NotFound();
            }
            return View(nwcRrealEstateType);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NwcRrealEstateTypesCode,NwcRrealEstateTypesName,NwcRrealEstateTypesReasons")] NwcRrealEstateType nwcRrealEstateType)
        {
            if (id != nwcRrealEstateType.NwcRrealEstateTypesCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nwcRrealEstateType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NwcRrealEstateTypeExists(nwcRrealEstateType.NwcRrealEstateTypesCode))
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
            return View(nwcRrealEstateType);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NwcRrealEstateTypes == null)
            {
                return NotFound();
            }

            var nwcRrealEstateType = await _context.NwcRrealEstateTypes
                .FirstOrDefaultAsync(m => m.NwcRrealEstateTypesCode == id);
            if (nwcRrealEstateType == null)
            {
                return NotFound();
            }

            return View(nwcRrealEstateType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NwcRrealEstateTypes == null)
            {
                return Problem("Entity set 'NwcContext.NwcRrealEstateTypes'  is null.");
            }
            var nwcRrealEstateType = await _context.NwcRrealEstateTypes.FindAsync(id);
            if (nwcRrealEstateType != null)
            {
                _context.NwcRrealEstateTypes.Remove(nwcRrealEstateType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NwcRrealEstateTypeExists(string id)
        {
          return (_context.NwcRrealEstateTypes?.Any(e => e.NwcRrealEstateTypesCode == id)).GetValueOrDefault();
        }
    }
}
