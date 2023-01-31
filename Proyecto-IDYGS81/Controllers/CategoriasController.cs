using Microsoft.AspNetCore.Mvc;
using Proyecto_IDYGS81.Context;

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
            return View();
        }
    }
}
