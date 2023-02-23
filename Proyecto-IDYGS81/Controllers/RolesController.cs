using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_IDYGS81.Context;
using Proyecto_IDYGS81.Models;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Proyecto_IDYGS81.Controllers
{
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var res = _context.Roles.ToList();

            return View(res);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Rol request)
        {
            try
            {
                Rol rol = new Rol();
                rol.Nombre = request.Nombre;
                rol.Descripcion = request.Descripcion;
                _context.Roles.Add(rol);
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
                var rol = _context.Roles.Find(id);
                return View(rol);

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Rol request)
        {
            try
            {
                Rol rol = new Rol();
                rol.Nombre = request.Nombre;
                rol.Descripcion = request.Descripcion;
                _context.Roles.Update(rol);
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
                var rol = _context.Roles.Find(id);
                return View(rol);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id, Rol request)
        {
            try
            {
                Rol rol = new Rol();
                rol = _context.Roles.Find(id);
                _context.Roles.Remove(rol);
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