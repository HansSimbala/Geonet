
using System.Collections.Generic;
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
    public class EquipoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;
        public EquipoController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: Equipoes


        public async Task<IActionResult> MenuEquipo()
        {


            var applicationDbContext = _context.Equipo.Include(e => e.categoria);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Equipoes/Details/5
        public async Task<IActionResult> DetalleEquipo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .Include(e => e.categoria)
                .SingleOrDefaultAsync(m => m.idEquipo == id);
            if (equipo == null)
            {
                return NotFound();
            }




            List<EquipoxProveedor> listaEquipoProveedores = _context.Set<EquipoxProveedor>().Where(p => p.idEquipo == id).Include(s => s.equipo).Include(s => s.proveedor).ToList();
            ViewData["listaEquipoProveedores"] = listaEquipoProveedores;


            return View(equipo);
        }

        // GET: Equipoes/Create
        public IActionResult RegistrarEquipo()
        {
            ViewData["idCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "nombre");
            return View();
        }

        // POST: Equipoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarEquipo([Bind("idEquipo,idCategoria,nombre,marca,codigo,descripcion,imagen")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(MenuEquipo));
            }
            ViewData["idCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "nombre", equipo.idCategoria);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public async Task<IActionResult> EditarEquipo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo.SingleOrDefaultAsync(m => m.idEquipo == id);
            if (equipo == null)
            {
                return NotFound();
            }
            ViewData["idCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "nombre", equipo.idCategoria);
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarEquipo(int id, [Bind("idEquipo,idCategoria,nombre,marca,codigo,descripcion,imagen")] Equipo equipo)
        {
            if (id != equipo.idEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.idEquipo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MenuEquipo));
            }
            ViewData["idCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "nombre", equipo.idCategoria);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public async Task<IActionResult> EliminarEquipo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .Include(e => e.categoria)
                .SingleOrDefaultAsync(m => m.idEquipo == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("EliminarEquipo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var equipo = await _context.Equipo.SingleOrDefaultAsync(m => m.idEquipo == id);
            _context.Equipo.Remove(equipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MenuEquipo));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipo.Any(e => e.idEquipo == id);
        }
        private bool CodigoExists(string codigo)
        {
            return _context.Equipo.Any(e => e.codigo == codigo);
        }
        private bool NombreExists(string nombre)
        {
            return _context.Equipo.Any(e => e.nombre == nombre);
        }
        private bool MarcaExists(string marca)
        {
            return _context.Equipo.Any(e => e.marca == marca);
        }
        
    }
}


