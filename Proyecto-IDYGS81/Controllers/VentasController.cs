using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_IDYGS81.Context;
using Proyecto_IDYGS81.Models;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore;

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
            if (User.Identity.IsAuthenticated)
            {
                var res = _context.Ventas.Include(x => x.Usuario).Include(x => x.Producto).ToList();

                return View(res);

            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
           
        }
        [HttpGet]
        public IActionResult Crear()
        {
            if (User.Identity.IsAuthenticated)
            {

                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearVenta(int Id)
        {
            var correo = User.Identity.Name;

            var usuario = (from c in _context.Usuarios
                          where c.Correo == correo
                          select c.FKRol);
            var producto = (from c in _context.Productos
                           where c.PkProducto == Id
                           select c.PrecioVenta);
            try
            {
                Venta venta = new Venta();
                venta.FKUsuario = usuario.First();
                venta.FechaVenta = DateTime.Now;
                venta.FKProducto = Id;
                venta.Precio = producto.First();
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