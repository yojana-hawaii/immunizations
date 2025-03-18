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
    public class LocationController : Controller
    {
        private readonly TenantContext _context;

        public LocationController(TenantContext context)
        {
            _context = context;
        }

        // GET: Location
        public async Task<IActionResult> Index()
        {
            return View(await _context.VaccineLocations.ToListAsync());
        }

        // GET: Location/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineLocation = await _context.VaccineLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineLocation == null)
            {
                return NotFound();
            }

            return View(vaccineLocation);
        }

        // GET: Location/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LocationName,SubLocation,ComputedSubLocationForUniqueness")] VaccineLocation vaccineLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccineLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccineLocation);
        }

        // GET: Location/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineLocation = await _context.VaccineLocations.FindAsync(id);
            if (vaccineLocation == null)
            {
                return NotFound();
            }
            return View(vaccineLocation);
        }

        // POST: Location/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LocationName,SubLocation,ComputedSubLocationForUniqueness")] VaccineLocation vaccineLocation)
        {
            if (id != vaccineLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccineLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccineLocationExists(vaccineLocation.Id))
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
            return View(vaccineLocation);
        }

        // GET: Location/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineLocation = await _context.VaccineLocations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineLocation == null)
            {
                return NotFound();
            }

            return View(vaccineLocation);
        }

        // POST: Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccineLocation = await _context.VaccineLocations.FindAsync(id);
            if (vaccineLocation != null)
            {
                _context.VaccineLocations.Remove(vaccineLocation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccineLocationExists(int id)
        {
            return _context.VaccineLocations.Any(e => e.Id == id);
        }
    }
}
