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
    public class PerifericosController : Controller
    {
        private readonly FiapDbContext _context;

        public PerifericosController(FiapDbContext context)
        {
            _context = context;
        }

        // GET: Perifericos
        public async Task<IActionResult> Index()
        {
            var fiapDbContext = _context.Periferico.Include(p => p.Computador);
            return View(await fiapDbContext.ToListAsync());
        }

        // GET: Perifericos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periferico = await _context.Periferico
                .Include(p => p.Computador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periferico == null)
            {
                return NotFound();
            }

            return View(periferico);
        }

        // GET: Perifericos/Create
        public IActionResult Create()
        {
            ViewData["ComputadorId"] = new SelectList(_context.Computador, "Id", "Nome");
            return View();
        }

        // POST: Perifericos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Marca,ComputadorId")] Periferico periferico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periferico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComputadorId"] = new SelectList(_context.Computador, "Id", "Nome", periferico.ComputadorId);
            return View(periferico);
        }

        // GET: Perifericos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periferico = await _context.Periferico.FindAsync(id);
            if (periferico == null)
            {
                return NotFound();
            }
            ViewData["ComputadorId"] = new SelectList(_context.Computador, "Id", "Nome", periferico.ComputadorId);
            return View(periferico);
        }

        // POST: Perifericos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Marca,ComputadorId")] Periferico periferico)
        {
            if (id != periferico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periferico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerifericoExists(periferico.Id))
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
            ViewData["ComputadorId"] = new SelectList(_context.Computador, "Id", "Nome", periferico.ComputadorId);
            return View(periferico);
        }

        // GET: Perifericos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periferico = await _context.Periferico
                .Include(p => p.Computador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (periferico == null)
            {
                return NotFound();
            }

            return View(periferico);
        }

        // POST: Perifericos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var periferico = await _context.Periferico.FindAsync(id);
            if (periferico != null)
            {
                _context.Periferico.Remove(periferico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerifericoExists(int id)
        {
            return _context.Periferico.Any(e => e.Id == id);
        }
    }
}
