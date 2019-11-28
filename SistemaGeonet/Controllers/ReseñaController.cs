using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGeonet.Data;
using SistemaGeonet.Models;

namespace SistemaGeonet.Controllers
{
    public class ReseñaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReseñaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reseña
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reseña.Include(r => r.catalogo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reseña/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseña
                .Include(r => r.catalogo)
                .SingleOrDefaultAsync(m => m.idReseña == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return View(reseña);
        }

        // GET: Reseña/Create
        public IActionResult Create()
        {
            ViewData["idInventario"] = new SelectList(_context.Inventario, "IdCatalogo", "IdInventario");
            return View();
        }

        // POST: Reseña/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idReseña,idCatalogo,comentario,calificacion,usuario")] Reseña reseña)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reseña);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCatalogo"] = new SelectList(_context.Catalogo, "IdCatalogo", "IdInventario", reseña.idCatalogo);
            return View(reseña);
        }

        // GET: Reseña/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseña.SingleOrDefaultAsync(m => m.idReseña == id);
            if (reseña == null)
            {
                return NotFound();
            }
            ViewData["idInventario"] = new SelectList(_context.Inventario, "IdCatalogo", "IdInventario", reseña.idCatalogo);
            return View(reseña);
        }

        // POST: Reseña/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idReseña,idCatalogo,comentario,calificacion,usuario")] Reseña reseña)
        {
            if (id != reseña.idReseña)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reseña);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReseñaExists(reseña.idReseña))
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
            ViewData["idInventario"] = new SelectList(_context.Inventario, "IdCatalogo", "IdInventario", reseña.idCatalogo);
            return View(reseña);
        }

        // GET: Reseña/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.Reseña
                .Include(r => r.catalogo)
                .SingleOrDefaultAsync(m => m.idReseña == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return View(reseña);
        }

        // POST: Reseña/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reseña = await _context.Reseña.SingleOrDefaultAsync(m => m.idReseña == id);
            _context.Reseña.Remove(reseña);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReseñaExists(int id)
        {
            return _context.Reseña.Any(e => e.idReseña == id);
        }
    }
}
