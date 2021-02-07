using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogPAUPLatestYT.Data;
using BlogPAUPLatestYT.Models;

namespace BlogPAUPLatestYT.Controllers
{
    public class SmjeroviFaksasController : Controller
    {
        private readonly AppDBContext _context;

        public SmjeroviFaksasController(AppDBContext context)
        {
            _context = context;
        }

        // GET: SmjeroviFaksas
        public async Task<IActionResult> Index()
        {
            return View(await _context.SmjeroviFaksas.ToListAsync());
        }

        // GET: SmjeroviFaksas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjeroviFaksa = await _context.SmjeroviFaksas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smjeroviFaksa == null)
            {
                return NotFound();
            }

            return View(smjeroviFaksa);
        }

        // GET: SmjeroviFaksas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SmjeroviFaksas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NazivSmjera")] SmjeroviFaksa smjeroviFaksa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smjeroviFaksa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(smjeroviFaksa);
        }

        // GET: SmjeroviFaksas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjeroviFaksa = await _context.SmjeroviFaksas.FindAsync(id);
            if (smjeroviFaksa == null)
            {
                return NotFound();
            }
            return View(smjeroviFaksa);
        }

        // POST: SmjeroviFaksas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NazivSmjera")] SmjeroviFaksa smjeroviFaksa)
        {
            if (id != smjeroviFaksa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smjeroviFaksa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmjeroviFaksaExists(smjeroviFaksa.Id))
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
            return View(smjeroviFaksa);
        }

        // GET: SmjeroviFaksas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smjeroviFaksa = await _context.SmjeroviFaksas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smjeroviFaksa == null)
            {
                return NotFound();
            }

            return View(smjeroviFaksa);
        }

        // POST: SmjeroviFaksas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var smjeroviFaksa = await _context.SmjeroviFaksas.FindAsync(id);
            _context.SmjeroviFaksas.Remove(smjeroviFaksa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmjeroviFaksaExists(int id)
        {
            return _context.SmjeroviFaksas.Any(e => e.Id == id);
        }
    }
}
