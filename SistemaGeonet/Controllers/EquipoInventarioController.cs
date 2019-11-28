using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaGeonet.Data;
using SistemaGeonet.Models;

namespace SistemaGeonet.Controllers
{
    public class EquipoInventarioController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public EquipoInventarioController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: EquipoInventario
        public ActionResult Index()
        {
            return View();
        }

        // GET: EquipoInventario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquipoInventario/Create
        public ActionResult RegistrarInventario()
        {

            ViewData["idCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "nombre");
            return View();


        }

        // POST: EquipoInventario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarInventario(EquipoInventario equipoInventario)
        {
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
                _context.Inventario.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction("MenuInventario", "Inventario");
            }
            ViewData["idCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "nombre", equipoInventario.idCategoria);
            return View(equipoInventario);

        }

        // GET: EquipoInventario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquipoInventario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipoInventario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquipoInventario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        

    }
}