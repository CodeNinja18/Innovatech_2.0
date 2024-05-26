using app_ds501.Data;
using app_ds501.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace app_ds501.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usuario/Index
        public IActionResult Index()
        {
            // Verificar si el usuario ya ha iniciado sesión
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: Usuario/Index
        [HttpPost]
        public async Task<IActionResult> Index(Usuario model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Usuario
                    .FirstOrDefaultAsync(u => u.correo == model.correo && u.contra == model.contra);

                if (user != null)
                {
                    // Iniciar sesión del usuario
                    HttpContext.Session.SetString("UserEmail", user.correo);

                    return RedirectToAction("Index", "Home"); // Redirige a Home/Index
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos.");
                }
            }

            return View(model);
        }

        // POST: Usuario/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            // Cerrar sesión del usuario
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Usuario"); // Redirige a Usuario/Index
        }
    }

}
