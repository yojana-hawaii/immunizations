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
    public class ProgramController : Controller
    {
        private readonly TenantContext _context;

        public ProgramController(TenantContext context)
        {
            _context = context;
        }

        // GET: Program
        public async Task<IActionResult> Index()
        {
            return View(await _context.VaccinePrograms.ToListAsync());
        }

        // GET: Program/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineProgram = await _context.VaccinePrograms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineProgram == null)
            {
                return NotFound();
            }

            return View(vaccineProgram);
        }

        // GET: Program/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Program/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VaccineProgramName,VaccineProgramDescription")] VaccineProgram vaccineProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccineProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccineProgram);
        }

        // GET: Program/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineProgram = await _context.VaccinePrograms.FindAsync(id);
            if (vaccineProgram == null)
            {
                return NotFound();
            }
            return View(vaccineProgram);
        }

        // POST: Program/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VaccineProgramName,VaccineProgramDescription")] VaccineProgram vaccineProgram)
        {
            if (id != vaccineProgram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccineProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccineProgramExists(vaccineProgram.Id))
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
            return View(vaccineProgram);
        }

        // GET: Program/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineProgram = await _context.VaccinePrograms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccineProgram == null)
            {
                return NotFound();
            }

            return View(vaccineProgram);
        }

        // POST: Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccineProgram = await _context.VaccinePrograms.FindAsync(id);
            if (vaccineProgram != null)
            {
                _context.VaccinePrograms.Remove(vaccineProgram);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccineProgramExists(int id)
        {
            return _context.VaccinePrograms.Any(e => e.Id == id);
        }
    }
}
