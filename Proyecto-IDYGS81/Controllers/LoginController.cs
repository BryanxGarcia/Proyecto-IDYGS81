using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_IDYGS81.Models;
using System.Threading.Tasks;
using System;
using Proyecto_IDYGS81.Context;
using System.Linq;
using System.Xml.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Text;
using System.Security.Cryptography;

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
            var contras = Convertir(Pass);
            try
            {

                var response = _context.Usuarios.Include(z => z.Roles).FirstOrDefault(x => x.Correo == email && x.Password == contras);

                if (response != null)
                {
                    if (response.Roles.Nombre == "Admin")
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, email)
                        };
                        var identity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme
                            );
                        var principal = new ClaimsPrincipal(identity);
                        var props = new AuthenticationProperties();
                        HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                        return RedirectToAction("Index", "Productos");
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, email)
                        };
                        var identity = new ClaimsIdentity(
                            claims, CookieAuthenticationDefaults.AuthenticationScheme
                            );
                        var principal = new ClaimsPrincipal(identity);
                        var props = new AuthenticationProperties();
                        HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

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

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");

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
                res.Password = Convertir(user.Password);
                res.FKRol = 2;
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
        public static string Convertir(string texto)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));
                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
