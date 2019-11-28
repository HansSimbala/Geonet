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
    public class DetallePedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallePedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetallePedido
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetallePedido.Include(d => d.inventario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetallePedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.inventario)
                .SingleOrDefaultAsync(m => m.idDetallePedido == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // GET: DetallePedido/Create
        public IActionResult Create()
        {
            ViewData["idInventario"] = new SelectList(_context.Inventario, "IdInventario", "IdInventario");
            return View();
        }

        // POST: DetallePedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idDetallePedido,idOrdenPedido,idInventario,cantidad")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idInventario"] = new SelectList(_context.Inventario, "IdInventario", "IdInventario", detallePedido.idInventario);
            return View(detallePedido);
        }

        // GET: DetallePedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido.SingleOrDefaultAsync(m => m.idDetallePedido == id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            ViewData["idInventario"] = new SelectList(_context.Inventario, "IdInventario", "IdInventario", detallePedido.idInventario);
            return View(detallePedido);
        }

        // POST: DetallePedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idDetallePedido,idOrdenPedido,idInventario,cantidad")] DetallePedido detallePedido)
        {
            if (id != detallePedido.idDetallePedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidoExists(detallePedido.idDetallePedido))
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
            ViewData["idInventario"] = new SelectList(_context.Inventario, "IdInventario", "IdInventario", detallePedido.idInventario);
            return View(detallePedido);
        }

        // GET: DetallePedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.inventario)
                .SingleOrDefaultAsync(m => m.idDetallePedido == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // POST: DetallePedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePedido = await _context.DetallePedido.SingleOrDefaultAsync(m => m.idDetallePedido == id);
            _context.DetallePedido.Remove(detallePedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedido.Any(e => e.idDetallePedido == id);
        }
    }
}
