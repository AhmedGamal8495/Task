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
    public class InvoicesController : Controller
    {
        private readonly NwcContext _context;

        public InvoicesController(NwcContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var nwcContext = _context.NwcInvoices.Include(n => n.NwcInvoicesRrealEstateTypesNavigation).Include(n => n.NwcInvoicesSubscriberNoNavigation).Include(n => n.NwcInvoicesSubscriptionNoNavigation);
            return View(await nwcContext.ToListAsync());
        }

        
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NwcInvoices == null)
            {
                return NotFound();
            }

            var nwcInvoice = await _context.NwcInvoices
                .Include(n => n.NwcInvoicesRrealEstateTypesNavigation)
                .Include(n => n.NwcInvoicesSubscriberNoNavigation)
                .Include(n => n.NwcInvoicesSubscriptionNoNavigation)
                .FirstOrDefaultAsync(m => m.NwcInvoicesNo == id);
            if (nwcInvoice == null)
            {
                return NotFound();
            }

            return View(nwcInvoice);
        }

        
        public IActionResult Create()
        {
            ViewData["NwcInvoicesRrealEstateTypes"] = new SelectList(_context.NwcRrealEstateTypes, "NwcRrealEstateTypesCode", "NwcRrealEstateTypesCode");
            ViewData["NwcInvoicesSubscriberNo"] = new SelectList(_context.NwcSubscriberFiles, "NwcSubscriberFileId", "NwcSubscriberFileId");
            ViewData["NwcInvoicesSubscriptionNo"] = new SelectList(_context.NwcSubscriptionFiles, "NwcSubscriptionFileNo", "NwcSubscriptionFileNo");
            
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NwcInvoicesNo,NwcInvoicesYear,NwcInvoicesRrealEstateTypes,NwcInvoicesSubscriptionNo,NwcInvoicesSubscriberNo,NwcInvoicesDate,NwcInvoicesFrom,NwcInvoicesTo,NwcInvoicesPreviousConsumptionAmount,NwcInvoicesCurrentConsumptionAmount,NwcInvoicesAmountConsumption,NwcInvoicesServiceFee,NwcInvoicesTaxRate,NwcInvoicesIsThereSanitation,NwcInvoicesConsumptionValue,NwcInvoicesWastewaterConsumptionValue,NwcInvoicesTotalInvoice,NwcInvoicesTaxValue,NwcInvoicesTotalBill,NwcInvoicesTotalReasons")] NwcInvoice nwcInvoice)
        {

            nwcInvoice.NwcInvoicesTo = DateTime.Now;
            nwcInvoice.NwcInvoicesYear = DateTime.Now.ToString("yyy");

            //nwcInvoice.NwcInvoicesPreviousConsumptionAmount = await _context.NwcSubscriptionFiles.FindAsync(nwcInvoice.NwcInvoicesSubscriptionNoNavigation.NwcSubscriptionFileLastReadingMeter);
            //nwcInvoice.NwcInvoicesAmountConsumption = nwcInvoice.NwcInvoicesCurrentConsumptionAmount - nwcInvoice.NwcInvoicesPreviousConsumptionAmount;
            //nwcInvoice.NwcInvoicesSubscriberNo = nwcInvoice.NwcInvoicesSubscriptionNoNavigation.NwcSubscriptionFileSubscriberCode.ToString();

            if (nwcInvoice.NwcInvoicesAmountConsumption < 16)
            {
                nwcInvoice.NwcInvoicesTotalInvoice = nwcInvoice.NwcInvoicesAmountConsumption * nwcInvoice.NwcInvoicesSubscriptionNoNavigation.NwcSubscriptionFileUnitNo * (decimal)0.1;
                if (nwcInvoice.NwcInvoicesIsThereSanitation == true)
                {
                    nwcInvoice.NwcInvoicesTotalBill = nwcInvoice.NwcInvoicesTotalInvoice + (nwcInvoice.NwcInvoicesTotalInvoice / 2);
                }
                else
                {
                    nwcInvoice.NwcInvoicesTotalBill = nwcInvoice.NwcInvoicesTotalInvoice;
                }
            }
            if (nwcInvoice.NwcInvoicesAmountConsumption > 16 && nwcInvoice.NwcInvoicesAmountConsumption <= 30)
            {
                nwcInvoice.NwcInvoicesTotalInvoice = nwcInvoice.NwcInvoicesAmountConsumption * nwcInvoice.NwcInvoicesSubscriptionNoNavigation.NwcSubscriptionFileUnitNo * (decimal)1.0;
                if (nwcInvoice.NwcInvoicesIsThereSanitation == true)
                {
                    nwcInvoice.NwcInvoicesTotalBill = nwcInvoice.NwcInvoicesTotalInvoice + (decimal)0.5;
                }
                else
                {
                    nwcInvoice.NwcInvoicesTotalBill = nwcInvoice.NwcInvoicesTotalInvoice;
                }
            }
            if (nwcInvoice.NwcInvoicesAmountConsumption > 31 && nwcInvoice.NwcInvoicesAmountConsumption <= 45)
            {
                nwcInvoice.NwcInvoicesTotalInvoice = nwcInvoice.NwcInvoicesAmountConsumption * nwcInvoice.NwcInvoicesSubscriptionNoNavigation.NwcSubscriptionFileUnitNo * (decimal)3.0;
                if (nwcInvoice.NwcInvoicesIsThereSanitation == true)
                {
                    nwcInvoice.NwcInvoicesTotalBill = nwcInvoice.NwcInvoicesTotalInvoice + (decimal)1.5;
                }
                else
                {
                    nwcInvoice.NwcInvoicesTotalBill = nwcInvoice.NwcInvoicesTotalInvoice;
                }
            }
            if (nwcInvoice.NwcInvoicesAmountConsumption > 46 && nwcInvoice.NwcInvoicesAmountConsumption <= 60)
            {
                nwcInvoice.NwcInvoicesTotalInvoice = nwcInvoice.NwcInvoicesAmountConsumption * nwcInvoice.NwcInvoicesSubscriptionNoNavigation.NwcSubscriptionFileUnitNo * (decimal)4.0;
                if (nwcInvoice.NwcInvoicesIsThereSanitation == true)
                {
                    nwcInvoice.NwcInvoicesTotalBill = nwcInvoice.NwcInvoicesTotalInvoice + (decimal)2.0;
                }
                else
                {
                    nwcInvoice.NwcInvoicesTotalBill = nwcInvoice.NwcInvoicesTotalInvoice;
                }
            }
            if (nwcInvoice.NwcInvoicesAmountConsumption > 60)
            {
                nwcInvoice.NwcInvoicesTotalInvoice = nwcInvoice.NwcInvoicesAmountConsumption * nwcInvoice.NwcInvoicesSubscriptionNoNavigation.NwcSubscriptionFileUnitNo * (decimal)6.0;
                if (nwcInvoice.NwcInvoicesIsThereSanitation == true)
                {
                    nwcInvoice.NwcInvoicesTotalBill = nwcInvoice.NwcInvoicesTotalInvoice + (decimal)3.0;
                }
                else
                {
                    nwcInvoice.NwcInvoicesTotalBill = nwcInvoice.NwcInvoicesTotalInvoice;
                }
            }







            if (ModelState.IsValid)
            {
                _context.Add(nwcInvoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NwcInvoicesRrealEstateTypes"] = new SelectList(_context.NwcRrealEstateTypes, "NwcRrealEstateTypesCode", "NwcRrealEstateTypesCode", nwcInvoice.NwcInvoicesRrealEstateTypes);
            ViewData["NwcInvoicesSubscriberNo"] = new SelectList(_context.NwcSubscriberFiles, "NwcSubscriberFileId", "NwcSubscriberFileId", nwcInvoice.NwcInvoicesSubscriberNo);
            ViewData["NwcInvoicesSubscriptionNo"] = new SelectList(_context.NwcSubscriptionFiles, "NwcSubscriptionFileNo", "NwcSubscriptionFileNo", nwcInvoice.NwcInvoicesSubscriptionNo);
            return View(nwcInvoice);
        }

        
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NwcInvoices == null)
            {
                return NotFound();
            }

            var nwcInvoice = await _context.NwcInvoices.FindAsync(id);
            if (nwcInvoice == null)
            {
                return NotFound();
            }
            ViewData["NwcInvoicesRrealEstateTypes"] = new SelectList(_context.NwcRrealEstateTypes, "NwcRrealEstateTypesCode", "NwcRrealEstateTypesCode", nwcInvoice.NwcInvoicesRrealEstateTypes);
            ViewData["NwcInvoicesSubscriberNo"] = new SelectList(_context.NwcSubscriberFiles, "NwcSubscriberFileId", "NwcSubscriberFileId", nwcInvoice.NwcInvoicesSubscriberNo);
            ViewData["NwcInvoicesSubscriptionNo"] = new SelectList(_context.NwcSubscriptionFiles, "NwcSubscriptionFileNo", "NwcSubscriptionFileNo", nwcInvoice.NwcInvoicesSubscriptionNo);
            return View(nwcInvoice);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NwcInvoicesNo,NwcInvoicesYear,NwcInvoicesRrealEstateTypes,NwcInvoicesSubscriptionNo,NwcInvoicesSubscriberNo,NwcInvoicesDate,NwcInvoicesFrom,NwcInvoicesTo,NwcInvoicesPreviousConsumptionAmount,NwcInvoicesCurrentConsumptionAmount,NwcInvoicesAmountConsumption,NwcInvoicesServiceFee,NwcInvoicesTaxRate,NwcInvoicesIsThereSanitation,NwcInvoicesConsumptionValue,NwcInvoicesWastewaterConsumptionValue,NwcInvoicesTotalInvoice,NwcInvoicesTaxValue,NwcInvoicesTotalBill,NwcInvoicesTotalReasons")] NwcInvoice nwcInvoice)
        {
            if (id != nwcInvoice.NwcInvoicesNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nwcInvoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NwcInvoiceExists(nwcInvoice.NwcInvoicesNo))
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
            ViewData["NwcInvoicesRrealEstateTypes"] = new SelectList(_context.NwcRrealEstateTypes, "NwcRrealEstateTypesCode", "NwcRrealEstateTypesCode", nwcInvoice.NwcInvoicesRrealEstateTypes);
            ViewData["NwcInvoicesSubscriberNo"] = new SelectList(_context.NwcSubscriberFiles, "NwcSubscriberFileId", "NwcSubscriberFileId", nwcInvoice.NwcInvoicesSubscriberNo);
            ViewData["NwcInvoicesSubscriptionNo"] = new SelectList(_context.NwcSubscriptionFiles, "NwcSubscriptionFileNo", "NwcSubscriptionFileNo", nwcInvoice.NwcInvoicesSubscriptionNo);
            return View(nwcInvoice);
        }

        
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NwcInvoices == null)
            {
                return NotFound();
            }

            var nwcInvoice = await _context.NwcInvoices
                .Include(n => n.NwcInvoicesRrealEstateTypesNavigation)
                .Include(n => n.NwcInvoicesSubscriberNoNavigation)
                .Include(n => n.NwcInvoicesSubscriptionNoNavigation)
                .FirstOrDefaultAsync(m => m.NwcInvoicesNo == id);
            if (nwcInvoice == null)
            {
                return NotFound();
            }

            return View(nwcInvoice);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NwcInvoices == null)
            {
                return Problem("Entity set 'NwcContext.NwcInvoices'  is null.");
            }
            var nwcInvoice = await _context.NwcInvoices.FindAsync(id);
            if (nwcInvoice != null)
            {
                _context.NwcInvoices.Remove(nwcInvoice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NwcInvoiceExists(string id)
        {
          return (_context.NwcInvoices?.Any(e => e.NwcInvoicesNo == id)).GetValueOrDefault();
        }
    }
}
