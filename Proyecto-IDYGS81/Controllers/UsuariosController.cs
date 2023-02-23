using Microsoft.AspNetCore.Mvc;
using Proyecto_IDYGS81.Context;
using Proyecto_IDYGS81.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Proyecto_IDYGS81.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var res = _context.Usuarios.ToList();

            return View(res);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Usuarios request)
        {
            try
            {
                Usuarios res = new Usuarios();
                res.Nombre = request.Nombre;
                res.Apellido = request.Apellido;
                res.Telefono = request.Telefono;
                res.Correo = request.Correo;
                res.Direccion = request.Direccion;
                res.Password = request.Password;
                res.FKRol = request.FKRol;
                _context.Usuarios.Add(res);
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
                var res = _context.Usuarios.Find(id);
                return View(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Usuarios request)
        {
            try
            {
                Usuarios res = new Usuarios();
                res.Nombre = request.Nombre;
                res.Apellido = request.Apellido;
                res.Telefono = request.Telefono;
                res.Correo = request.Correo;
                res.Direccion = request.Direccion;
                res.Password = request.Password;
                res.FKRol = request.FKRol;
                _context.Usuarios.Update(res);
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
                var res = _context.Usuarios.Find(id);
                return View(res);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id, Usuarios request)
        {
            try
            {
                Usuarios res = new Usuarios();
                res = _context.Usuarios.Find(id);
                _context.Usuarios.Remove(res);
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