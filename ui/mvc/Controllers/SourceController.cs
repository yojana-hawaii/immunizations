using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Tenant;
using Infrastructure.AppContext.Tenant;

namespace mvc.Controllers
{
    public class SourceController : Controller
    {
        private readonly TenantContext _context;

        public SourceController(TenantContext context)
        {
            _context = context;
        }

        // GET: Source
        public async Task<IActionResult> Index()
        {
            return View(await _context.VaccineSources.ToListAsync());
        }

        // GET: Source/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineSource = await _context.VaccineSources
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineSource == null)
            {
                return NotFound();
            }

            return View(vaccineSource);
        }

        // GET: Source/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Source/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VaccineSourceName,VaccineSourceDescription")] VaccineSource vaccineSource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccineSource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccineSource);
        }

        // GET: Source/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineSource = await _context.VaccineSources.FindAsync(id);
            if (vaccineSource == null)
            {
                return NotFound();
            }
            return View(vaccineSource);
        }

        // POST: Source/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VaccineSourceName,VaccineSourceDescription")] VaccineSource vaccineSource)
        {
            if (id != vaccineSource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccineSource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccineSourceExists(vaccineSource.Id))
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
            return View(vaccineSource);
        }

        // GET: Source/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineSource = await _context.VaccineSources
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineSource == null)
            {
                return NotFound();
            }

            return View(vaccineSource);
        }

        // POST: Source/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccineSource = await _context.VaccineSources.FindAsync(id);
            if (vaccineSource != null)
            {
                _context.VaccineSources.Remove(vaccineSource);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccineSourceExists(int id)
        {
            return _context.VaccineSources.Any(e => e.Id == id);
        }
    }
}
