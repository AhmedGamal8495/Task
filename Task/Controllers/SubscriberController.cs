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
    public class SubscriberController : Controller
    {
        private readonly NwcContext _context;

        public SubscriberController(NwcContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.NwcSubscriberFiles != null ? 
                          View(await _context.NwcSubscriberFiles.Include(S=>S.NwcSubscriptionFiles).ToListAsync()) :
                          Problem("Entity set 'NwcContext.NwcSubscriberFiles'  is null.");
        }

        
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NwcSubscriberFiles == null)
            {
                return NotFound();
            }

            var nwcSubscriberFile = await _context.NwcSubscriberFiles
                .FirstOrDefaultAsync(m => m.NwcSubscriberFileId == id);
            if (nwcSubscriberFile == null)
            {
                return NotFound();
            }

            return View(nwcSubscriberFile);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NwcSubscriberFileId,NwcSubscriberFileName,NwcSubscriberFileCity,NwcSubscriberFileArea,NwcSubscriberFileMobile,NwcSubscriberFileReasons")] NwcSubscriberFile nwcSubscriberFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nwcSubscriberFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nwcSubscriberFile);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NwcSubscriberFiles == null)
            {
                return NotFound();
            }

            var nwcSubscriberFile = await _context.NwcSubscriberFiles.FindAsync(id);
            if (nwcSubscriberFile == null)
            {
                return NotFound();
            }
            return View(nwcSubscriberFile);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NwcSubscriberFileId,NwcSubscriberFileName,NwcSubscriberFileCity,NwcSubscriberFileArea,NwcSubscriberFileMobile,NwcSubscriberFileReasons")] NwcSubscriberFile nwcSubscriberFile)
        {
            if (id != nwcSubscriberFile.NwcSubscriberFileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nwcSubscriberFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NwcSubscriberFileExists(nwcSubscriberFile.NwcSubscriberFileId))
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
            return View(nwcSubscriberFile);
        }

        // GET: Subscriber/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NwcSubscriberFiles == null)
            {
                return NotFound();
            }

            var nwcSubscriberFile = await _context.NwcSubscriberFiles
                .FirstOrDefaultAsync(m => m.NwcSubscriberFileId == id);
            if (nwcSubscriberFile == null)
            {
                return NotFound();
            }

            return View(nwcSubscriberFile);
        }

        // POST: Subscriber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NwcSubscriberFiles == null)
            {
                return Problem("Entity set 'NwcContext.NwcSubscriberFiles'  is null.");
            }
            var nwcSubscriberFile = await _context.NwcSubscriberFiles.FindAsync(id);
            if (nwcSubscriberFile != null)
            {
                _context.NwcSubscriberFiles.Remove(nwcSubscriberFile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NwcSubscriberFileExists(string id)
        {
          return (_context.NwcSubscriberFiles?.Any(e => e.NwcSubscriberFileId == id)).GetValueOrDefault();
        }
    }
}
