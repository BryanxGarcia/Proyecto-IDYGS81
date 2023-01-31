using Microsoft.AspNetCore.Mvc;
using Proyecto_IDYGS81.Context;

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
            return View();
        }
    }
}
