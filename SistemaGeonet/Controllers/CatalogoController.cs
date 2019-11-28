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
    public class CatalogoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Catalogo
        public async Task<IActionResult> MenuCatalogo()
        {
            return View(await _context.Catalogo.Include(u=>u.inventario).ThenInclude(u=>u.Equipo).ToListAsync());
        }

        // GET: Catalogo/Details/5
        public async Task<IActionResult> DetalleCatalogo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo
                .SingleOrDefaultAsync(m => m.idCatalogo == id);
            if (catalogo == null)
            {
                return NotFound();
            }

            List<Reseña> listareseña = _context.Set<Reseña>().Include(s => s.catalogo).ToList();
            ViewData["listareseña"] = listareseña;



            return View(catalogo);
        }

        // GET: Catalogo/Create
        public IActionResult RegistrarCatalogo()
        {
            ViewData["idInventario"] = new SelectList(_context.Inventario, "idInventario", "nombre");
            return View();
        }

        // POST: Catalogo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarCatalogo([Bind("idCatalogo,idInventario,cantidadVirtual,titulo,descripcion,foto1,foto2,foto3,foto4")] Catalogo catalogo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MenuCatalogo));
            }
            ViewData["idInventario"] = new SelectList(_context.Inventario, "idInventario", "nombre", catalogo.idInventario);
            return View(catalogo);

            
        }

        // GET: Catalogo/Edit/5
        public async Task<IActionResult> EditarCatalogo(int? id)
        {
            ViewData["idInventario"] = new SelectList(_context.Inventario, "IdInventario", "nombre");
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo.SingleOrDefaultAsync(m => m.idCatalogo == id);
            if (catalogo == null)
            {
                return NotFound();
            }
            return View(catalogo);
        }

        // POST: Catalogo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCatalogo(int id, [Bind("idCatalogo,idInventario,cantidadVirtual,titulo,descripcion,foto1,foto2,foto3,foto4")] Catalogo catalogo)
        {
            ViewData["idInventario"] = new SelectList(_context.Inventario, "IdInventario", "nombre", catalogo.idInventario);
            if (id != catalogo.idCatalogo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoExists(catalogo.idCatalogo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MenuCatalogo));
            }
            return View(catalogo);
        }

        // GET: Catalogo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogo
                .SingleOrDefaultAsync(m => m.idCatalogo == id);
            if (catalogo == null)
            {
                return NotFound();
            }

            return View(catalogo);
        }

        // POST: Catalogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogo = await _context.Catalogo.SingleOrDefaultAsync(m => m.idCatalogo == id);
            _context.Catalogo.Remove(catalogo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MenuCatalogo));
        }

        private bool CatalogoExists(int id)
        {
            return _context.Catalogo.Any(e => e.idCatalogo == id);
        }
    }
}
