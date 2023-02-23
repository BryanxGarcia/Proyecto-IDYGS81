using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_IDYGS81.Context;
using Proyecto_IDYGS81.Models;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Proyecto_IDYGS81.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var res = _context.Ventas.ToList();

            return View(res);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Venta request)
        {
            try
            {
                Venta venta = new Venta();
               venta.FKUsuario = request.FKUsuario;
                venta.FechaVenta = request.FechaVenta;
                venta.FKDetalleVenta = request.FKDetalleVenta;
                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            try
            {
                var venta = _context.Ventas.Find(id);
                return View(venta);

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Venta request)
        {
            try
            {
                Venta venta = new Venta();
                venta.FKUsuario = request.FKUsuario;
                venta.FechaVenta = request.FechaVenta;
                venta.FKDetalleVenta = request.FKDetalleVenta;
                _context.Ventas.Update(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var venta = _context.Ventas.Find(id);
                return View(venta);
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id, Venta request)
        {
            try
            {
                Venta venta = new Venta();
                venta = _context.Ventas.Find(id);
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }


    }
}