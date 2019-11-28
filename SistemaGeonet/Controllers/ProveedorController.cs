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
    public class ProveedorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProveedorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proveedors
        public async Task<IActionResult> MenuProveedor()
        {
            return View(await _context.Proveedor.OrderByDescending(p=>p.idProveedor).ToListAsync());
        }

        

        // GET: Proveedors/Details/5
        public async Task<IActionResult> DetalleProveedor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor
                .SingleOrDefaultAsync(m => m.idProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }


            List<EquipoxProveedor> listaEquipoProveedor = _context.Set<EquipoxProveedor>().Where(p =>p.idProveedor==id).Include(s => s.equipo).ToList();
            ViewData["listaEquipoProveedor"] = listaEquipoProveedor;


            return View(proveedor);
        }

        // GET: Proveedors/Create
        public IActionResult RegistrarProveedor()
        {
            return View();
        }

        // POST: Proveedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarProveedor([Bind("idProveedor,nombreEmpresa,nombreContacto,tipoDocumentoIdentidad,nroDocumentoIdentidad,pais,direccion,telefono,email")] Proveedor proveedor)
        {
            if ((proveedor.tipoDocumentoIdentidad == "DNI" && proveedor.nroDocumentoIdentidad.Length != 8) || ((proveedor.tipoDocumentoIdentidad == "Carnet de Extranjería") && (proveedor.nroDocumentoIdentidad.Length != 9)))
            {
                ModelState.AddModelError(string.Empty, "El número de documento de identidad no concuerda con su tipo de documento");
                ViewData["docVal"] = "is-invalid";
            }
            if (CorreoExists(proveedor.email))
            {
                ModelState.AddModelError(string.Empty, "El número de teléfono ingresado ya está registrado.");
                ViewData["correoVal"] = "is-invalid";
            }
            if (DocExists(proveedor.nroDocumentoIdentidad))
            {
                ModelState.AddModelError(string.Empty, "El número de documento de identidad ingresado ya está registrado.");
                ViewData["docVal"] = "is-invalid";
            }
            if (TelExists(proveedor.telefono))
            {
                ModelState.AddModelError(string.Empty, "El número de teléfono ingresado ya está registrado.");
                ViewData["telVal"] = "is-invalid";
            }
            if (NombreExists(proveedor.nombreEmpresa) && ContactoExists(proveedor.nombreContacto))
            {
                ModelState.AddModelError(string.Empty, "Los datos del proveedor ingresados ya existen en nuestra base de datos.");
                ViewData["empresaVal"] = "is-invalid"; ViewData["contactoVal"] = "is-invalid";
            }
            if (proveedor.telefono.ToString().Length != 9)
            {
                ModelState.AddModelError(string.Empty, "El número de teléfono no cuenta con el formato correcto.");
                ViewData["telVal"] = "is-invalid";
            }
            if (ModelState.IsValid)
            {
                _context.Add(proveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MenuProveedor));
            }
            return View(proveedor);
        }

        // GET: Proveedors/Edit/5
        public async Task<IActionResult> EditarProveedor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor.SingleOrDefaultAsync(m => m.idProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarProveedor(int id, [Bind("idProveedor,nombreEmpresa,nombreContacto,tipoDocumentoIdentidad,nroDocumentoIdentidad,pais,direccion,telefono,email")] Proveedor proveedor)
        {
            if (id != proveedor.idProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.idProveedor))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MenuProveedor));
            }
            return View(proveedor);
        }

        // GET: Proveedors/Delete/5
        public async Task<IActionResult> EliminarProveedor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedor
                .SingleOrDefaultAsync(m => m.idProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // POST: Proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            var proveedor = await _context.Proveedor.SingleOrDefaultAsync(m => m.idProveedor == id);
            _context.Proveedor.Remove(proveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MenuProveedor));
        }

        private bool ProveedorExists(int id)
        {
            return _context.Proveedor.Any(e => e.idProveedor == id);
        }
        private bool NombreExists(string nom)
        {
            return _context.Proveedor.Any(e => e.nombreEmpresa == nom);
        }
        private bool ContactoExists(string nom)
        {
            return _context.Proveedor.Any(e => e.nombreContacto == nom);
        }
        private bool CorreoExists(string correo)
        {
            return _context.Proveedor.Any(e => e.email == correo);
        }
        private bool DocExists(string doc)
        {
            return _context.Proveedor.Any(e => e.nroDocumentoIdentidad == doc);
        }
        private bool TelExists(string tel)
        {
            return _context.Proveedor.Any(e => e.telefono == tel);
        }
    }
}
