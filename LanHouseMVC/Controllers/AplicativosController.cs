using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanHouseMVC.Models;
using LanHouseMVC.Persistence;

namespace LanHouseMVC.Controllers
{
    public class AplicativosController : Controller
    {
        private readonly FiapDbContext _context;

        public AplicativosController(FiapDbContext context)
        {
            _context = context;
        }

        // GET: Aplicativos
        public async Task<IActionResult> Index()
        {
            var fiapDbContext = _context.Aplicativo.Include(a => a.Computador);
            return View(await fiapDbContext.ToListAsync());
        }

        // GET: Aplicativos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicativo = await _context.Aplicativo
                .Include(a => a.Computador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aplicativo == null)
            {
                return NotFound();
            }

            return View(aplicativo);
        }

        // GET: Aplicativos/Create
        public IActionResult Create()
        {
            ViewData["ComputadorId"] = new SelectList(_context.Computador, "Id", "Nome");
            return View();
        }

        // POST: Aplicativos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Nome,ComputadorId")] Aplicativo aplicativo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aplicativo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComputadorId"] = new SelectList(_context.Computador, "Id", "Nome", aplicativo.ComputadorId);
            return View(aplicativo);
        }

        // GET: Aplicativos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicativo = await _context.Aplicativo.FindAsync(id);
            if (aplicativo == null)
            {
                return NotFound();
            }
            ViewData["ComputadorId"] = new SelectList(_context.Computador, "Id", "Nome", aplicativo.ComputadorId);
            return View(aplicativo);
        }

        // POST: Aplicativos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Nome,ComputadorId")] Aplicativo aplicativo)
        {
            if (id != aplicativo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aplicativo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AplicativoExists(aplicativo.Id))
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
            ViewData["ComputadorId"] = new SelectList(_context.Computador, "Id", "Nome", aplicativo.ComputadorId);
            return View(aplicativo);
        }

        // GET: Aplicativos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplicativo = await _context.Aplicativo
                .Include(a => a.Computador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aplicativo == null)
            {
                return NotFound();
            }

            return View(aplicativo);
        }

        // POST: Aplicativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aplicativo = await _context.Aplicativo.FindAsync(id);
            if (aplicativo != null)
            {
                _context.Aplicativo.Remove(aplicativo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AplicativoExists(int id)
        {
            return _context.Aplicativo.Any(e => e.Id == id);
        }
    }
}
