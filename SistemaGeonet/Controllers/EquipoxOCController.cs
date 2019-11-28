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
    public class EquipoxOCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipoxOCController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EquipoxOC
        public async Task<IActionResult> MenuEquipoxOC()
        {
            var applicationDbContext = _context.EquipoxOC.Include(e => e.equipoxproveedor).Include(e => e.ordenCompra);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EquipoxOC/Details/5
        public async Task<IActionResult> DetalleEquipoxOC(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoxOC = await _context.EquipoxOC
                .Include(e => e.equipoxproveedor)
                .Include(e => e.ordenCompra)
                .SingleOrDefaultAsync(m => m.idEquipoxOC == id);
            if (equipoxOC == null)
            {
                return NotFound();
            }

            return View(equipoxOC);
        }

        // GET: EquipoxOC/Create
        public async Task<IActionResult> RegistrarEquipoxOC(int id)
        {
            var t_compra = await _context.OrdenCompra.SingleOrDefaultAsync(m => m.idOrdenCompra == id);
            var tproveedor = t_compra.idProveedor;

            //ViewData["idEquipo"] = new SelectList(_context.Equipo, "idEquipo", "nombre");

            List<EquipoxProveedor> listProductos = _context.Set<EquipoxProveedor>().Where(p=>p.idProveedor==tproveedor).Include(o => o.proveedor).Include(o => o.equipo).ToList();
            ViewData["listaProductos"] = listProductos;

            return View();
        }

        // POST: EquipoxOC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarEquipoxOC(int id , EquipoxOC equipoxOC)
        {
            var t_compra = await _context.OrdenCompra.SingleOrDefaultAsync(m => m.idOrdenCompra == id);
            var tproveedor = t_compra.idProveedor;
           
            EquipoxOC equipoxoc = new EquipoxOC
            {
                idEquipoxProveedor = equipoxOC.idEquipoxProveedor,
                idOrdenCompra = id,
                cantidad = equipoxOC.cantidad,
                precioUnit = equipoxOC.precioUnit,
                precioTotal=equipoxOC.cantidad*equipoxOC.precioUnit               
              };

          
         
            if (ModelState.IsValid)
            {
                _context.EquipoxOC.Add(equipoxoc);
                t_compra.subtotal =t_compra.subtotal+(equipoxOC.cantidad * equipoxOC.precioUnit);
                t_compra.igv =0.18m* t_compra.subtotal;
                t_compra.total = t_compra.subtotal + t_compra.igv;
                _context.OrdenCompra.Update(t_compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(RegistrarEquipoxOC));
            }

           
            List<EquipoxProveedor> listProductos = _context.Set<EquipoxProveedor>().Where(p => p.idProveedor == tproveedor).Include(o => o.proveedor).Include(o => o.equipo).ToList();
            ViewData["listaProductos"] = listProductos;
            return View(equipoxOC);
        }

        // GET: EquipoxOC/Edit/5
        public async Task<IActionResult> EditarEquipoxOC(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoxOC = await _context.EquipoxOC.SingleOrDefaultAsync(m => m.idEquipoxOC == id);
            if (equipoxOC == null)
            {
                return NotFound();
            }
            ViewData["idEquipo"] = new SelectList(_context.Equipo, "idEquipo", "codigo", equipoxOC.idEquipoxProveedor);
            ViewData["idOrdenCompra"] = new SelectList(_context.OrdenCompra, "idOrdenCompra", "idOrdenCompra", equipoxOC.idOrdenCompra);
            return View(equipoxOC);
        }

        // POST: EquipoxOC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarEquipoxOC(int id, [Bind("idEquipoxOC,idEquipo,idOrdenCompra,cantidad")] EquipoxOC equipoxOC)
        {
            if (id != equipoxOC.idEquipoxOC)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoxOC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoxOCExists(equipoxOC.idEquipoxOC))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MenuEquipoxOC));
            }
            ViewData["idEquipo"] = new SelectList(_context.EquipoxProveedor, "idEquipoxProveedor", "codigo", equipoxOC.idEquipoxProveedor);
            ViewData["idOrdenCompra"] = new SelectList(_context.OrdenCompra, "idOrdenCompra", "idOrdenCompra", equipoxOC.idOrdenCompra);
            return View(equipoxOC);
        }

        // GET: EquipoxOC/Delete/5
        public async Task<IActionResult> EliminarEquipoxOC(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoxOC = await _context.EquipoxOC
                .Include(e => e.equipoxproveedor)
                .Include(e => e.ordenCompra)
                .SingleOrDefaultAsync(m => m.idEquipoxOC == id);
            if (equipoxOC == null)
            {
                return NotFound();
            }

            return View(equipoxOC);
        }

        // POST: EquipoxOC/Delete/5
        [HttpPost, ActionName("EliminarEquipoxOC")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var equipoxOC = await _context.EquipoxOC.SingleOrDefaultAsync(m => m.idEquipoxOC == id);
            _context.EquipoxOC.Remove(equipoxOC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MenuEquipoxOC));
        }

        private bool EquipoxOCExists(int id)
        {
            return _context.EquipoxOC.Any(e => e.idEquipoxOC == id);
        }
    }
}
