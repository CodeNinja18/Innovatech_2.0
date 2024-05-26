using app_ds501.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app_ds501.Controllers
{
    public class InscripcionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscripcionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var inscripciones = _context.Inscripcion
                .Include(i => i.Cliente)
                .Include(i => i.Servicio)
                .Include(i => i.Promocion)
                .Include(i => i.Metodo)
                .ToList();

            return View(inscripciones);
        }
    }
}
