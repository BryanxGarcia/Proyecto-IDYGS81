using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_IDYGS81.Context;
using Proyecto_IDYGS81.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_IDYGS81.Controllers
{
    public class HomeuserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeuserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var res = _context.Productos.ToList();
                return View(res);
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }

        }
        public ActionResult Compras()
        {
            if (User.Identity.IsAuthenticated)
            {
                var correo = User.Identity.Name;
                var usuario = (from c in _context.Usuarios
                               where c.Correo == correo
                               select c.FKRol).FirstOrDefault();

                var res = _context.Ventas.Where(x => x.FKUsuario == usuario).ToList();
                List<Productos> x = new List<Productos>();

                foreach (Venta element in res)
                {
                    var producto = (from c in _context.Productos
                                    where c.PkProducto == element.FKProducto
                                    select c).FirstOrDefault();
                    x.Add(producto);

                }
                return View(x);
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
        public ActionResult Perfil()
        {
            if (User.Identity.IsAuthenticated)
            {
                var correo = User.Identity.Name;
                var usuario = (from c in _context.Usuarios
                               where c.Correo == correo
                               select c).FirstOrDefault();

                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Usuarios request)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    Usuarios res = new Usuarios();

                    var correo = User.Identity.Name;
                    res = (from c in _context.Usuarios
                           where c.Correo == correo
                           select c).FirstOrDefault();
                    res.Nombre = request.Nombre;
                    res.Apellido = request.Apellido;
                    res.Telefono = request.Telefono;
                    res.Correo = request.Correo;
                    res.Direccion = request.Direccion;
                    res.Password = request.Password;
                    _context.Usuarios.Update(res);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    throw new Exception("Surgio un error " + ex.Message);
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }

        }
        [HttpGet]
        public IActionResult Crear(int id)
        {
            if (User.Identity.IsAuthenticated)
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
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");

        }


        [HttpPost]
        public async Task<IActionResult> Crear(int id, Productos request)
        {
            Productos producto = new Productos();
            producto = _context.Productos.Find(id);
            var correo = User.Identity.Name;
            var usuario = (from c in _context.Usuarios
                           where c.Correo == correo
                           select c.FKRol).FirstOrDefault();
            try
            {
                Venta venta = new Venta();
                venta.FKUsuario = usuario;
                venta.FechaVenta = DateTime.Now;
                venta.FKProducto = producto.PkProducto;
                venta.Precio = producto.PrecioVenta;
                venta.IsDeleted = false;
                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Homeuser");
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }


    }
}
