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
    public class OrdenCompraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenCompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdenCompra
        public async Task<IActionResult> MenuOrdenCompra()
        {
            var applicationDbContext = _context.OrdenCompra.Include(o => o.proveedor);

            List<EquipoxOC> listaEquipoxOC = _context.Set<EquipoxOC>().Include(s => s.equipoxproveedor).ThenInclude(x=>x.equipo).ToList();
            ViewData["listaEquipoxOC"] = listaEquipoxOC;




            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrdenCompra/Details/5
        public async Task<IActionResult> DetalleOrdenCompra(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompra
                .Include(o => o.proveedor)
                .SingleOrDefaultAsync(m => m.idOrdenCompra == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }


            List<EquipoxOC> listaEquipoxOC = _context.Set<EquipoxOC>().Where(p => p.idOrdenCompra == id).Include(s => s.equipoxproveedor).ThenInclude(x=>x.equipo).ToList();
            ViewData["listaEquipoxOC"] = listaEquipoxOC;



            List<Item> itemxoc = _context.Set<Item>().Where(x =>x.IdOrdenCompra == id).Include(s => s.Inventario).ThenInclude(x => x.Equipo).ToList();
            ViewData["itemxoc"] = itemxoc;


            return View(ordenCompra);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DetalleOrdenCompra(int id ,OrdenCompra ordencompra)
        {
        

            var ordenCompra = await _context.OrdenCompra
 
    .SingleOrDefaultAsync(m => m.idOrdenCompra == id);


            ordenCompra.estado = "Por atender";
            _context.OrdenCompra.Update(ordenCompra);
            await _context.SaveChangesAsync();

       

            List<EquipoxOC> listaEquipoxOC = _context.Set<EquipoxOC>().Where(p => p.idOrdenCompra == id).Include(s => s.equipoxproveedor).ThenInclude(x => x.equipo).ToList();
            ViewData["listaEquipoxOC"] = listaEquipoxOC;


            return RedirectToAction("MenuOrdenCompra", "OrdenCompra");
        }



        public async Task<IActionResult> AtenderOrdenCompra(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompra
                .Include(o => o.proveedor)
                .SingleOrDefaultAsync(m => m.idOrdenCompra == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }


            List<EquipoxOC> listaEquipoxOC = _context.Set<EquipoxOC>().Where(p => p.idOrdenCompra == id).Include(s => s.equipoxproveedor).ThenInclude(x => x.equipo).ToList();
            ViewData["listaEquipoxOC"] = listaEquipoxOC;



            List<Item> itemxoc = _context.Set<Item>().Where(x => x.IdOrdenCompra == id).Include(s => s.Inventario).ThenInclude(x => x.Equipo).ToList();
            ViewData["itemxoc"] = itemxoc;


            return View(ordenCompra);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AtenderOrdenCompra(int id, OrdenCompra ordencompra)
        {


            var ordenCompra = await _context.OrdenCompra

    .SingleOrDefaultAsync(m => m.idOrdenCompra == id);


            ordenCompra.estado = "Atendida";
            _context.OrdenCompra.Update(ordenCompra);
            await _context.SaveChangesAsync();



            List<EquipoxOC> listaEquipoxOC = _context.Set<EquipoxOC>().Where(p => p.idOrdenCompra == id).Include(s => s.equipoxproveedor).ThenInclude(x => x.equipo).ToList();
            ViewData["listaEquipoxOC"] = listaEquipoxOC;


            return RedirectToAction("MenuOrdenCompra", "OrdenCompra");
        }










        // GET: OrdenCompra/Create
        public IActionResult RegistrarOrdenCompra()
        {
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "nombre_empresa");
            return View();
        }

        // POST: OrdenCompra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarOrdenCompra([Bind("idOrdenCompra,fecha,idProveedor,subtotal,igv,total,estado,codigo")] OrdenCompra ordenCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenCompra);
                await _context.SaveChangesAsync();
                int idx = ordenCompra.idOrdenCompra;
                return RedirectToAction("DetalleOrdenCompra", "OrdenCompra", new { @id = idx });
            }
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "nombre_empresa", ordenCompra.idProveedor);
            return View(ordenCompra);
        }

        // GET: OrdenCompra/Edit/5
        public async Task<IActionResult> EditarOrdenCompra(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompra.SingleOrDefaultAsync(m => m.idOrdenCompra == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "nombre_empresa", ordenCompra.idProveedor);
            return View(ordenCompra);
        }

        // POST: OrdenCompra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarOrdenCompra(int id, [Bind("idOrdenCompra,fecha,idProveedor,subtotal,igv,total,estado,codigo")] OrdenCompra ordenCompra)
        {
            if (id != ordenCompra.idOrdenCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenCompraExists(ordenCompra.idOrdenCompra))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MenuOrdenCompra));
            }
            ViewData["idProveedor"] = new SelectList(_context.Proveedor, "idProveedor", "nombre_empresa", ordenCompra.idProveedor);
            return View(ordenCompra);
        }

        // GET: OrdenCompra/Delete/5
        public async Task<IActionResult> EliminarOrdenCompra(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenCompra = await _context.OrdenCompra
                .Include(o => o.proveedor)
                .SingleOrDefaultAsync(m => m.idOrdenCompra == id);
            if (ordenCompra == null)
            {
                return NotFound();
            }

            return View(ordenCompra);
        }

        // POST: OrdenCompra/Delete/5
        [HttpPost, ActionName("EliminarOrdenCompra")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var ordenCompra = await _context.OrdenCompra.SingleOrDefaultAsync(m => m.idOrdenCompra == id);
            _context.OrdenCompra.Remove(ordenCompra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MenuOrdenCompra));
        }

        private bool OrdenCompraExists(int id)
        {
            return _context.OrdenCompra.Any(e => e.idOrdenCompra == id);
        }
    }
}
