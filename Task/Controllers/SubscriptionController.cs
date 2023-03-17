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
    public class SubscriptionController : Controller
    {
        private readonly NwcContext _context;

        public SubscriptionController(NwcContext context)
        {
            _context = context;
        }

        // GET: Subscription
        public async Task<IActionResult> Index()
        {
            var nwcContext = _context.NwcSubscriptionFiles.Include(n => n.NwcSubscriptionFileRrealEstateTypesCodeNavigation).Include(n => n.NwcSubscriptionFileSubscriberCodeNavigation);
            return View(await nwcContext.ToListAsync());
        }

       
        // GET: Subscription/Create
        public IActionResult Create()
        {
            ViewData["NwcSubscriptionFileRrealEstateTypesCode"] = new SelectList(_context.NwcRrealEstateTypes, "NwcRrealEstateTypesCode", "NwcRrealEstateTypesCode");
            ViewData["NwcSubscriptionFileSubscriberCode"] = new SelectList(_context.NwcSubscriberFiles, "NwcSubscriberFileId", "NwcSubscriberFileId");
            return View();
        }

        // POST: Subscription/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NwcSubscriptionFileNo,NwcSubscriptionFileSubscriberCode,NwcSubscriptionFileRrealEstateTypesCode,NwcSubscriptionFileUnitNo,NwcSubscriptionFileIsThereSanitation,NwcSubscriptionFileLastReadingMeter,NwcSubscriptionFileReasons")] NwcSubscriptionFile nwcSubscriptionFile)
        {
            
                _context.Add(nwcSubscriptionFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
          
        }

        // GET: Subscription/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NwcSubscriptionFiles == null)
            {
                return NotFound();
            }

            var nwcSubscriptionFile = await _context.NwcSubscriptionFiles.FindAsync(id);
            if (nwcSubscriptionFile == null)
            {
                return NotFound();
            }
            ViewData["NwcSubscriptionFileRrealEstateTypesCode"] = new SelectList(_context.NwcRrealEstateTypes, "NwcRrealEstateTypesCode", "NwcRrealEstateTypesCode", nwcSubscriptionFile.NwcSubscriptionFileRrealEstateTypesCode);
            ViewData["NwcSubscriptionFileSubscriberCode"] = new SelectList(_context.NwcSubscriberFiles, "NwcSubscriberFileId", "NwcSubscriberFileId", nwcSubscriptionFile.NwcSubscriptionFileSubscriberCode);
            return View(nwcSubscriptionFile);
        }

        // POST: Subscription/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NwcSubscriptionFileNo,NwcSubscriptionFileSubscriberCode,NwcSubscriptionFileRrealEstateTypesCode,NwcSubscriptionFileUnitNo,NwcSubscriptionFileIsThereSanitation,NwcSubscriptionFileLastReadingMeter,NwcSubscriptionFileReasons")] NwcSubscriptionFile nwcSubscriptionFile)
        {
            if (id != nwcSubscriptionFile.NwcSubscriptionFileNo)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(nwcSubscriptionFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NwcSubscriptionFileExists(nwcSubscriptionFile.NwcSubscriptionFileNo))
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

        // GET: Subscription/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NwcSubscriptionFiles == null)
            {
                return NotFound();
            }

            var nwcSubscriptionFile = await _context.NwcSubscriptionFiles
                .Include(n => n.NwcSubscriptionFileRrealEstateTypesCodeNavigation)
                .Include(n => n.NwcSubscriptionFileSubscriberCodeNavigation)
                .FirstOrDefaultAsync(m => m.NwcSubscriptionFileNo == id);
            if (nwcSubscriptionFile == null)
            {
                return NotFound();
            }

            return View(nwcSubscriptionFile);
        }

        // POST: Subscription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NwcSubscriptionFiles == null)
            {
                return Problem("Entity set 'NwcContext.NwcSubscriptionFiles'  is null.");
            }
            var nwcSubscriptionFile = await _context.NwcSubscriptionFiles.FindAsync(id);
            if (nwcSubscriptionFile != null)
            {
                _context.NwcSubscriptionFiles.Remove(nwcSubscriptionFile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NwcSubscriptionFileExists(string id)
        {
          return (_context.NwcSubscriptionFiles?.Any(e => e.NwcSubscriptionFileNo == id)).GetValueOrDefault();
        }
    }
}
