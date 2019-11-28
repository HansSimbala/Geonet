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
    public class MovimientoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovimientoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movimientoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Movimiento.Include(m => m.equipo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Movimientoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimiento
                .Include(m => m.equipo)
                .SingleOrDefaultAsync(m => m.idMovimiento == id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        // GET: Movimientoes/Create
        public IActionResult Create()
        {
            ViewData["idEquipo"] = new SelectList(_context.Equipo, "idEquipo", "codigo");
            return View();
        }

        // POST: Movimientoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idMovimiento,idEquipo,tipo,cantidad,unidad_medida,fecha")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idEquipo"] = new SelectList(_context.Equipo, "idEquipo", "codigo", movimiento.idEquipo);
            return View(movimiento);
        }

        // GET: Movimientoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimiento.SingleOrDefaultAsync(m => m.idMovimiento == id);
            if (movimiento == null)
            {
                return NotFound();
            }
            ViewData["idEquipo"] = new SelectList(_context.Equipo, "idEquipo", "codigo", movimiento.idEquipo);
            return View(movimiento);
        }

        // POST: Movimientoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idMovimiento,idEquipo,tipo,cantidad,unidad_medida,fecha")] Movimiento movimiento)
        {
            if (id != movimiento.idMovimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoExists(movimiento.idMovimiento))
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
            ViewData["idEquipo"] = new SelectList(_context.Equipo, "idEquipo", "codigo", movimiento.idEquipo);
            return View(movimiento);
        }

        // GET: Movimientoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimiento
                .Include(m => m.equipo)
                .SingleOrDefaultAsync(m => m.idMovimiento == id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        // POST: Movimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimiento = await _context.Movimiento.SingleOrDefaultAsync(m => m.idMovimiento == id);
            _context.Movimiento.Remove(movimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoExists(int id)
        {
            return _context.Movimiento.Any(e => e.idMovimiento == id);
        }
    }
}
