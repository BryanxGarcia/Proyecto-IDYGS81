using Microsoft.AspNetCore.Mvc;
using Proyecto_IDYGS81.Context;
using Proyecto_IDYGS81.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Proyecto_IDYGS81.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var res = _context.Productos.ToList();

            return View(res);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Productos request)
        {
            try
            {
                Productos producto = new Productos();
                producto.NombreProducto = request.NombreProducto;
                producto.Descripcion = request.Descripcion;
                producto.Inventario = request.Inventario;
                producto.PrecioVenta =   request.PrecioVenta;
                producto.FKCategoria = request.FKCategoria; 
                producto.Imagen = request.Imagen;
                _context.Productos.Add(producto);
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
                var producto = _context.Productos.Find(id);
                return View(producto);

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Productos request)
        {
            try
            {
                Productos producto = new Productos();
                producto.NombreProducto = request.NombreProducto;
                producto.Descripcion = request.Descripcion;
                producto.Inventario = request.Inventario;
                producto.PrecioVenta = request.PrecioVenta;
                producto.FKCategoria = request.FKCategoria;
                producto.Imagen = request.Imagen;
                _context.Productos.Update(producto);
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
                var producto = _context.Productos.Find(id);
                return View(producto);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id, Productos request)
        {
            try
            {
                Productos producto = new Productos();
                producto = _context.Productos.Find(id);
                _context.Productos.Remove(producto);
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