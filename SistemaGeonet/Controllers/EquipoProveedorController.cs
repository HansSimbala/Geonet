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
    public class EquipoProveedorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipoProveedorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EquipoxProveedors
        public async Task<IActionResult> MenuEquipoProveedor()
        {
            var applicationDbContext = _context.EquipoxProveedor.Include(e => e.equipo).Include(e => e.proveedor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EquipoxProveedors/Details/5
        public async Task<IActionResult> DetalleEquipoProveedor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoxProveedor = await _context.EquipoxProveedor
                .Include(e => e.equipo)
                .Include(e => e.proveedor)
                .SingleOrDefaultAsync(m => m.idEquipoxProveedor == id);
            if (equipoxProveedor == null)
            {
                return NotFound();
            }

            return View(equipoxProveedor);
        }

        // GET: EquipoxProveedors/Create
        public IActionResult RegistrarEquipoProveedor(int id)
        {
            
            ViewData["idEquipo"] = new SelectList(_context.Equipo, "idEquipo", "nombre");
            
            return View();
        }

        // POST: EquipoxProveedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarEquipoProveedor(int id ,[Bind("idEquipoxProveedor,idEquipo,idProveedor,precio,unidad_medida,factor_conversion,codigo_proveedor")] EquipoxProveedor equipoxProveedor)
        {
            equipoxProveedor.idProveedor = id;
            if (ModelState.IsValid)
            {
                _context.Add(equipoxProveedor);
                await _context.SaveChangesAsync();

                return RedirectToAction("DetalleProveedor", "Proveedor", new {id=id});
            }
            ViewData["idEquipo"] = new SelectList(_context.Equipo, "idEquipo", "nombre", equipoxProveedor.idEquipo);
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "direccion", equipoxProveedor.idProveedor);
            return View(equipoxProveedor);
        }

        // GET: EquipoxProveedors/Edit/5
        public async Task<IActionResult> EditarEquipoProveedor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoxProveedor = await _context.EquipoxProveedor.SingleOrDefaultAsync(m => m.idEquipoxProveedor == id);
            if (equipoxProveedor == null)
            {
                return NotFound();
            }
            ViewData["idEquipo"] = new SelectList(_context.Equipo, "idEquipo", "codigo", equipoxProveedor.idEquipo);
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "direccion", equipoxProveedor.idProveedor);
            return View(equipoxProveedor);
        }

        // POST: EquipoxProveedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarEquipoProveedor(int id, [Bind("idEquipoxProveedor,idEquipo,idProveedor,precio,unidad_medida,factor_conversion,codigo_proveedor")] EquipoxProveedor equipoxProveedor)
        {
            if (id != equipoxProveedor.idEquipoxProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoxProveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoxProveedorExists(equipoxProveedor.idEquipoxProveedor))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MenuEquipoProveedor));
            }
            ViewData["idEquipo"] = new SelectList(_context.Equipo, "idEquipo", "codigo", equipoxProveedor.idEquipo);
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "direccion", equipoxProveedor.idProveedor);
            return View(equipoxProveedor);
        }

        // GET: EquipoxProveedors/Delete/5
        public async Task<IActionResult> EliminarEquipoProveedor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoxProveedor = await _context.EquipoxProveedor
                .Include(e => e.equipo)
                .Include(e => e.proveedor)
                .SingleOrDefaultAsync(m => m.idEquipoxProveedor == id);
            if (equipoxProveedor == null)
            {
                return NotFound();
            }

            return View(equipoxProveedor);
        }

        // POST: EquipoxProveedors/Delete/5
        [HttpPost, ActionName("EliminarEquipoProveedor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var equipoxProveedor = await _context.EquipoxProveedor.SingleOrDefaultAsync(m => m.idEquipoxProveedor == id);
            _context.EquipoxProveedor.Remove(equipoxProveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EquipoxProveedor));
        }

        private bool EquipoxProveedorExists(int id)
        {
            return _context.EquipoxProveedor.Any(e => e.idEquipoxProveedor == id);
        }
    }
}
