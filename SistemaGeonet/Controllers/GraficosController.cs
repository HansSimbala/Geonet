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
    public class GraficosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GraficosController(ApplicationDbContext context)
        {
            _context = context;
        }




        // GET: Graficos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComprasxAtender()
        {
            return View();
        }


        public IActionResult Bar()
        {
            Random rnd = new Random();
            //list of department  
            var lstModel = new List<Graficos>();
            lstModel.Add(new Graficos
            {
                DimensionOne = "Technology",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new Graficos
            {
                DimensionOne = "Sales",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new Graficos
            {
                DimensionOne = "Marketing",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new Graficos
            {
                DimensionOne = "Human Resource",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new Graficos
            {
                DimensionOne = "Research and Development",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new Graficos
            {
                DimensionOne = "Acconting",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new Graficos
            {
                DimensionOne = "Support",
                Quantity = rnd.Next(10)
            });
            lstModel.Add(new Graficos
            {
                DimensionOne = "Logistics",
                Quantity = rnd.Next(10)
            });
            return View(lstModel);
        }



        public async Task<ActionResult> ComprasPorAtender()
        {
            var date =  await _context.OrdenCompra.Select(j => j.fecha).Distinct().ToListAsync();
            var success = _context.OrdenCompra
                .Where(j => j.estado == "Atendida")
                .GroupBy(a => a.fecha)
                .Select(a => new {
                    d = a.Key,
                    Count = a.Count()
                });
            var countSuccess = success.Select(a => a.Count).ToArray();

         
            var exception = _context.OrdenCompra
                .Where(j => j.estado == "Por Atender")
                .GroupBy(a => a.fecha)
                .Select(a => new {
                    d = a.Key,
                    Count = a.Count()
                });
            var countException = exception.Select(a => a.Count).ToArray();

            return new JsonResult(new { myDate = date, mySuccess = countSuccess, myException = countException });
        }



        public async Task<ActionResult> ComprasPorAtender2()
        {
            var date = await _context.OrdenCompra.Select(j => j.fecha).Distinct().ToListAsync();
            var success = _context.OrdenCompra
                .Where(j => j.estado == "Atendida")
                .GroupBy(a => a.fecha)
                .Select(a => new {
                    d = a.Key,
                    Count = a.Sum(b=>b.total)
                });
            var countSuccess = success.Select(a => a.Count).ToArray();


            var exception = _context.OrdenCompra
                .Where(j => j.estado == "Por Atender")
                .GroupBy(a => a.fecha)
                .Select(a => new {
                    d = a.Key,
                    Count = a.Sum(b => b.total)
                });
            var countException = exception.Select(a => a.Count).ToArray();

            return new JsonResult(new { myDate = date, mySuccess = countSuccess, myException = countException });
        }

        // GET: Graficos/Details/5


        // GET: Graficos/Create


        // POST: Graficos/Create

        // GET: Graficos/Edit/5

        // POST: Graficos/Edit/5


        // GET: Graficos/Delete/5

        // POST: Graficos/Delete/5



    }
}