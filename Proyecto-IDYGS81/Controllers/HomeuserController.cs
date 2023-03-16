using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_IDYGS81.Context;
using System.Linq;

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
            var res = _context.Productos.ToList();
            return View(res);
        }

        // GET: HomeuserController/Details/5

        // GET: HomeuserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeuserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
