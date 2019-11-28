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
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Item.Include(i => i.Inventario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Inventario)
                .SingleOrDefaultAsync(m => m.IdItem == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Item/Create
        public IActionResult RegistrarItem()
        {
            ViewData["idInventario"] = new SelectList(_context.Inventario, "idInventario", "nombre");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarItem(Item item)
        {
            Item items = new Item
            {
                IdOrdenCompra = item.IdOrdenCompra,
                IdInventario = item.IdInventario,
                Nroserie = item.Nroserie,
                detalle = item.detalle,
                estado = item.estado,
                fechaEntrada = DateTime.Today
            


            };

            var inventariox = await _context.Inventario
                     .SingleOrDefaultAsync(m => m.idInventario == item.IdInventario);


            if (ModelState.IsValid)
            {
                _context.Item.Add(items);
                inventariox.cantidadReal = inventariox.cantidadReal + 1;
                _context.Inventario.Update(inventariox);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(RegistrarItem));
            }
            ViewData["idInventario"] = new SelectList(_context.Inventario, "idInventario", "nombre", item.IdInventario);
            return View(item);
        }

          public JsonResult getNroserie(int idInventario)
        {
            List<Item> itemlist = new List<Item>();
            itemlist = (from item in _context.Item
                             where item.IdInventario == idInventario
                        where item.estado=="Activo"
                             select item).ToList();
            itemlist.Insert(0, new Item { Nroserie= "Seleccione un Item" });
            return Json(new SelectList(itemlist, "Nroserie" ,"Nroserie"));
        }


        public  IActionResult SacarItem(int? id)
        {
            List<Inventario> inventariolist = new List<Inventario>();
            inventariolist = (from inventario in _context.Inventario
                         
                         select inventario).ToList();

            inventariolist.Insert(0, new Inventario { idInventario = 0, nombre = "Seleccione un equipo" });

            ViewBag.IdInventario = inventariolist;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SacarItem(Item item)
        {

            var itemx = await _context.Item
                     .SingleOrDefaultAsync(m => m.Nroserie == item.Nroserie);
            var inventariox = await _context.Inventario
                     .SingleOrDefaultAsync(m => m.idInventario == item.IdInventario);
            
            

            if (ModelState.IsValid)
            {
                itemx.detalle = item.detalle;
                itemx.estado = item.estado;
                itemx.IdOrdenPedido = item.IdOrdenPedido;
                itemx.fechaSalida = DateTime.Today;
                _context.Item.Update(itemx);
                inventariox.cantidadReal = inventariox.cantidadReal - 1;
                _context.Inventario.Update(inventariox);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SacarItem));
            }
            ViewData["IdInventario"] = new SelectList(_context.Inventario, "IdInventario", "nombre", item.IdInventario);
            return View(item);
        }









        // GET: Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.SingleOrDefaultAsync(m => m.IdItem == id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["IdInventario"] = new SelectList(_context.Inventario, "idInventario", "IdInventario", item.IdInventario);
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdItem,idInventario,Nroserie,detalle,estado")] Item item)
        {
            if (id != item.IdItem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdItem))
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
            ViewData["IdInventario"] = new SelectList(_context.Inventario, "IdInventario", "IdInventario", item.IdInventario);
            return View(item);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Inventario)
                .SingleOrDefaultAsync(m => m.IdItem == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.SingleOrDefaultAsync(m => m.IdItem == id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.IdItem == id);
        }
    }
}
