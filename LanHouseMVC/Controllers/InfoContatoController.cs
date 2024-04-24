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
    public class InfoContatoController : Controller
    {
        private readonly FiapDbContext _context;

        public InfoContatoController(FiapDbContext context)
        {
            _context = context;
        }

        // GET: InfoContato
        public async Task<IActionResult> Index()
        {
            var fiapDbContext = _context.InfoContato.Include(i => i.Cliente);
            return View(await fiapDbContext.ToListAsync());
        }

        // GET: InfoContato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoContato = await _context.InfoContato
                .Include(i => i.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infoContato == null)
            {
                return NotFound();
            }

            return View(infoContato);
        }

        // GET: InfoContato/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome");
            return View();
        }

        // POST: InfoContato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Telefone,Email,ClienteId")] InfoContato infoContato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoContato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", infoContato.ClienteId);
            return View(infoContato);
        }

        // GET: InfoContato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoContato = await _context.InfoContato.FindAsync(id);
            if (infoContato == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", infoContato.ClienteId);
            return View(infoContato);
        }

        // POST: InfoContato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Telefone,Email,ClienteId")] InfoContato infoContato)
        {
            if (id != infoContato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoContato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoContatoExists(infoContato.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", infoContato.ClienteId);
            return View(infoContato);
        }

        // GET: InfoContato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoContato = await _context.InfoContato
                .Include(i => i.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infoContato == null)
            {
                return NotFound();
            }

            return View(infoContato);
        }

        // POST: InfoContato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoContato = await _context.InfoContato.FindAsync(id);
            if (infoContato != null)
            {
                _context.InfoContato.Remove(infoContato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoContatoExists(int id)
        {
            return _context.InfoContato.Any(e => e.Id == id);
        }
    }
}
