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
    public class OrdenPedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenPedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdenPedido
        public async Task<IActionResult> MenuOrdenPedido()
        {
            return View(await _context.OrdenPedido.ToListAsync());
        }

        // GET: OrdenPedido/Details/5
        public async Task<IActionResult> DetalleOrdenPedido(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenPedido = await _context.OrdenPedido
                .SingleOrDefaultAsync(m => m.IdOrdenPedido == id);
            if (ordenPedido == null)
            {
                return NotFound();
            }

            return View(ordenPedido);
        }


      





        public async Task<IActionResult> AtenderOrdenPedido(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenPedido = await _context.OrdenPedido
                 .SingleOrDefaultAsync(m => m.IdOrdenPedido == id);
            if (ordenPedido == null)
            {
                return NotFound();
            }


            List<DetallePedido> listaDetallePedido = _context.Set<DetallePedido>().Where(p => p.idOrdenPedido == id).Include(s => s.inventario).ThenInclude(x => x.Equipo).ToList();
            ViewData["listaDetallePedido"] = listaDetallePedido;



            List<Item> itemxpedido = _context.Set<Item>().Where(u=>u.IdOrdenPedido==id).Include(s => s.Inventario).ThenInclude(x => x.Equipo).ToList();
            ViewData["itemxop"] = itemxpedido;


            return View(ordenPedido);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AtenderOrdenPedido(int id, OrdenPedido ordenpedido)
        {


            var ordenPedido = await _context.OrdenPedido

    .SingleOrDefaultAsync(m => m.IdOrdenPedido == id);


            ordenPedido.estado = "Atendida";
            _context.OrdenPedido.Update(ordenPedido);
            await _context.SaveChangesAsync();




            List<DetallePedido> listaDetallePedido = _context.Set<DetallePedido>().Where(p => p.idOrdenPedido == id).Include(s => s.inventario).ThenInclude(x => x.Equipo).ToList();
            ViewData["listaDetallePedido"] = listaDetallePedido;



            List<Item> itemxpedido = _context.Set<Item>().Where(o=>o.IdOrdenPedido==id).Include(s => s.Inventario).ThenInclude(x => x.Equipo).ToList();
            ViewData["itemxop"] = itemxpedido;


            return RedirectToAction("MenuOrdenPedido", "OrdenPedido");
        }








        // GET: OrdenPedido/Create
        public IActionResult RegistrarOrdenPedido()
        {
            return View();
        }

        // POST: OrdenPedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarOrdenPedido([Bind("IdOrdenPedido,,fechapedido,comentario,usuario,estado")] OrdenPedido ordenPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(RegistrarOrdenPedido));
            }
            return View(ordenPedido);
        }

        // GET: OrdenPedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenPedido = await _context.OrdenPedido.SingleOrDefaultAsync(m => m.IdOrdenPedido == id);
            if (ordenPedido == null)
            {
                return NotFound();
            }
            return View(ordenPedido);
        }

        // POST: OrdenPedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrdenPedido,fechapedido,comentario,estado,usuario")] OrdenPedido ordenPedido)
        {
            if (id != ordenPedido.IdOrdenPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenPedidoExists(ordenPedido.IdOrdenPedido))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MenuOrdenPedido));
            }
            return View(ordenPedido);
        }

        // GET: OrdenPedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenPedido = await _context.OrdenPedido
                .SingleOrDefaultAsync(m => m.IdOrdenPedido == id);
            if (ordenPedido == null)
            {
                return NotFound();
            }

            return View(ordenPedido);
        }

        // POST: OrdenPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenPedido = await _context.OrdenPedido.SingleOrDefaultAsync(m => m.IdOrdenPedido == id);
            _context.OrdenPedido.Remove(ordenPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MenuOrdenPedido));
        }

        private bool OrdenPedidoExists(int id)
        {
            return _context.OrdenPedido.Any(e => e.IdOrdenPedido == id);
        }
    }
}
