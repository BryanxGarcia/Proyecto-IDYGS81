using Proyecto_IDYGS81.Context;
using Proyecto_IDYGS81.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Proyecto_IDYGS81.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var res = _context.Categorias.ToList();

            return View(res);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Categoria request)
        {
            try
            {
                Categoria cat = new Categoria();
                cat.NombreCat = request.NombreCat;
                cat.Descripcion = request.Descripcion;
                _context.Categorias.Add(cat);
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
                var cat = _context.Categorias.Find(id);
                return View(cat);
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Editar(int id, Categoria request)
        {
            try
            {
                Categoria cat = new Categoria();
                cat.NombreCat = request.NombreCat;
                cat.Descripcion = request.Descripcion;
                _context.Categorias.Update(cat);
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
                var cat = _context.Categorias.Find(id);
                return View(cat);

            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id, Categoria request)
        {
            try
            {
                Categoria cat = new Categoria();
                cat = _context.Categorias.Find(id);
                _context.Categorias.Remove(cat);
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
