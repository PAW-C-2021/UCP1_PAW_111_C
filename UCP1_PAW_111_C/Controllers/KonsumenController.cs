using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_111_C.Models;

namespace UCP1_PAW_111_C.Controllers
{
    public class KonsumenController : Controller
    {
        private readonly TokoBukuContext _context;

        public KonsumenController(TokoBukuContext context)
        {
            _context = context;
        }

        // GET: Konsumen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Konsumen.ToListAsync());
        }

        // GET: Konsumen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konsuman = await _context.Konsumen
                .FirstOrDefaultAsync(m => m.IdKonsumen == id);
            if (konsuman == null)
            {
                return NotFound();
            }

            return View(konsuman);
        }

        // GET: Konsumen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Konsumen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKonsumen,Nama,NoTelpon,UserName,Password")] Konsuman konsuman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konsuman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konsuman);
        }

        // GET: Konsumen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konsuman = await _context.Konsumen.FindAsync(id);
            if (konsuman == null)
            {
                return NotFound();
            }
            return View(konsuman);
        }

        // POST: Konsumen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKonsumen,Nama,NoTelpon,UserName,Password")] Konsuman konsuman)
        {
            if (id != konsuman.IdKonsumen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konsuman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonsumanExists(konsuman.IdKonsumen))
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
            return View(konsuman);
        }

        // GET: Konsumen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konsuman = await _context.Konsumen
                .FirstOrDefaultAsync(m => m.IdKonsumen == id);
            if (konsuman == null)
            {
                return NotFound();
            }

            return View(konsuman);
        }

        // POST: Konsumen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var konsuman = await _context.Konsumen.FindAsync(id);
            _context.Konsumen.Remove(konsuman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KonsumanExists(int id)
        {
            return _context.Konsumen.Any(e => e.IdKonsumen == id);
        }
    }
}
