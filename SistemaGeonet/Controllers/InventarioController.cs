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
    public class InventarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Inventarios
        public async Task<IActionResult> MenuInventario()
        {
            var applicationDbContext = _context.Inventario.Include(i => i.Equipo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Inventarios/Details/5
        public async Task<IActionResult> DetalleInventario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .Include(i => i.Equipo)
                .SingleOrDefaultAsync(m => m.idInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: Inventarios/Create
        public IActionResult RegistrarInventario()
        {
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "idEquipo", "nombre");
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarInventario([Bind("IdInventario,IdEquipo,titulo,fecha_entrada,fecha_salida,cantidadReal,cantidadVirtual,foto1,foto2,foto3,foto4,descripcion")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MenuInventario));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "idEquipo", "nombre", inventario.idEquipo);
            return View(inventario);
        }

      

        // GET: EquipoInventario/Create
        public ActionResult RegistrarEquipoInventario()
        {

            ViewData["idCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "nombre");
            return View();


        }



        // POST: EquipoInventario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarEquipoInventario(EquipoInventario equipoInventario)
        {

            if (CodigoExists(equipoInventario.codigo))
            {
                ModelState.AddModelError(string.Empty, "El código ingresado ya se encuentra registrado.");
                ViewData["codVal"] = "is-invalid";
            }
            if (NombreExists(equipoInventario.nombre) && MarcaExists(equipoInventario.marca))
            {
                ModelState.AddModelError(string.Empty, "Los datos del equipo ingresado ya se encuentran registrados.");
                ViewData["nomVal"] = "is-invalid";
                ViewData["marVal"] = "is-invalid";
            }
            if (SKUExists(equipoInventario.SKU))
            {
                ModelState.AddModelError(string.Empty, "El SKU ingresado ya existe, intente otro por favor.");
                ViewData["skuVal"] = "is-invalid";
            }
            if (equipoInventario.cantidadMaxima < equipoInventario.cantidadMinima)
            {
                ModelState.AddModelError(string.Empty, "El inventario máximo es incorrecto.");
                ViewData["maxVal"] = "is-invalid";
            }
            if (equipoInventario.cantidadMinima > equipoInventario.cantidadMaxima)
            {
                ModelState.AddModelError(string.Empty, "El inventario mínimo es incorrecto.");
                ViewData["minVal"] = "is-invalid";
            }
            if (equipoInventario.cantidadReal < equipoInventario.cantidadMinima || !(equipoInventario.cantidadReal <= equipoInventario.cantidadMaxima))
            {
                ModelState.AddModelError(string.Empty, "La cantidad está fuera de los rangos permitidos.");
                ViewData["cantVal"] = "is-invalid";
            }
            if (equipoInventario.precioUnit <= 0)
            {
                ModelState.AddModelError(string.Empty, "El precio unitario no puede ser negativo.");
                ViewData["precioVal"] = "is-invalid";
            }
            if (ModelState.IsValid)
            {
                Equipo equipo = new Equipo
                {
                    nombre = equipoInventario.nombre,
                    marca = equipoInventario.marca,
                    idCategoria = equipoInventario.idCategoria,
                    codigo = equipoInventario.codigo,
                    descripcion = equipoInventario.descripcion,
                    imagen = equipoInventario.imagen


                };
                Inventario inventario = new Inventario
                {
                    fechaEntrada = equipoInventario.fechaEntrada,
                    SKU = equipoInventario.SKU,
                    cantidadReal = equipoInventario.cantidadReal,
                    cantidadMaxima = equipoInventario.cantidadMaxima,
                    cantidadMinima = equipoInventario.cantidadMinima,
                    precioUnit = equipoInventario.precioUnit
                };
                _context.Equipo.Add(equipo);
                inventario.idEquipo = equipo.idEquipo;
                inventario.nombre = equipo.nombre;
                inventario.marca = equipo.marca;
                _context.Inventario.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction("MenuInventario", "Inventario");
            }
            ViewData["idCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "nombre", equipoInventario.idCategoria);
            return View(equipoInventario);

        }

        // GET: Inventarios/Edit/5
        public async Task<IActionResult> EditarInventario(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario.SingleOrDefaultAsync(m => m.idInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "idEquipo", "nombre", inventario.idEquipo);
            return View(inventario);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarInventario(int id, [Bind("idInventario,idEquipo,nombre,marca,SKU,fechaEntrada,cantidadMinima,cantidadReal,cantidadMaxima,precioUnit")] Inventario inventario)
        {
            if (id != inventario.idInventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.idInventario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MenuInventario));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "idEquipo", "nombre", inventario.idEquipo);
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventario
                .Include(i => i.Equipo)
                .SingleOrDefaultAsync(m => m.idInventario == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventario = await _context.Inventario.SingleOrDefaultAsync(m => m.idInventario == id);
            _context.Inventario.Remove(inventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MenuInventario));
        }

        private bool InventarioExists(int id)
        {
            return _context.Inventario.Any(e => e.idInventario == id);
        }
        private bool CodigoExists(string codigo)
        {
            return _context.Equipo.Any(e => e.codigo == codigo);
        }
        private bool NombreExists(string nombre)
        {
            return (_context.Equipo.Any(e => e.nombre == nombre) || _context.Inventario.Any(e => e.nombre == nombre));
        }
        private bool MarcaExists(string marca)
        {
            return (_context.Equipo.Any(e => e.marca == marca) || _context.Inventario.Any(e => e.marca == marca));
        }
        private bool SKUExists(string sku)
        {
            return _context.Inventario.Any(e => e.SKU == sku);
        }
    }
}
