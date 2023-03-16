using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_IDYGS81.Models;
using System.Threading.Tasks;
using System;
using Proyecto_IDYGS81.Context;
using System.Linq;
using System.Xml.Linq;

namespace Proyecto_IDYGS81.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult LoginUser(string email, string Pass)
        {
            try
            {
                var response = _context.Usuarios.Include(z => z.Roles).FirstOrDefault(x => x.Correo == email && x.Password == Pass);

                if (response != null)
                {
                    if (response.Roles.Nombre == "Admin")
                    {
                        return RedirectToAction("Index", "Productos");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Homeuser");
                    }
                }
                else
                {
                    ViewBag.Message = String.Format("Error");
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearUser(Usuarios user)
        {
            try
            {
                Usuarios res = new Usuarios();
                res.Nombre = user.Nombre;
                res.Apellido = user.Apellido;
                res.Correo = user.Correo;
                res.Password = user.Password;
                res.FKRol = 1002;
                res.IsDeleted = false;
                res.RowVersion = DateTime.Now;
                var respuesta = _context.Usuarios.Add(res);
                await _context.SaveChangesAsync();
                if (respuesta != null)
                {
                    ViewBag.Message = String.Format("Yes");

                    return View("Index");
                }
                else
                {
                    ViewBag.Title = String.Format("No");
                    return View("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Surgio un error " + ex.Message);
            }

        }

    }
}
