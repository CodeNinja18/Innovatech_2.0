using app_ds501.Data;
using app_ds501.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace app_ds501.Controllers
{
    public class PromocionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PromocionController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {
            String cad_sql = "exec sp_listar_promocion";
            List<Promocion> arr_promocion = _context.Promocion.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = arr_promocion });
        }

        [HttpGet]
        public JsonResult Consultar(String codigo_promocion)
        {
            String cad_sql = "exec sp_consultar_promocion @codigo_promocion";
            Promocion promocion = new Promocion();

            promocion = _context.Promocion.FromSqlRaw(cad_sql, new SqlParameter("@codigo_promocion", codigo_promocion)).ToList().FirstOrDefault();

            return Json(promocion);
        }


        [HttpPost]
        public IActionResult Grabar([FromBody] Promocion promocion)
        {
            bool rpta = true;

            try
            {
                Promocion tmp_promocion = null;
                tmp_promocion = (from per in _context.Promocion
                                where per.codigo_promocion == promocion.codigo_promocion
                                select per).FirstOrDefault();

                if (tmp_promocion == null)
                {
                    _context.Promocion.Add(promocion);
                    _context.SaveChanges();
                }
                else
                {
                    tmp_promocion.nombre = promocion.nombre;
                    tmp_promocion.descripcion = promocion.descripcion;

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                rpta = false;
            }

            return Json(new { resultado = rpta });
        }

        public JsonResult Borrar(String codigo_promocion)
        {
            bool rpta = true;
            try
            {
                Promocion promocion = new Promocion();
                promocion = (from per in _context.Promocion
                            where per.codigo_promocion == codigo_promocion
                            select per).FirstOrDefault();
                _context.Promocion.Remove(promocion);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                rpta = false;
            }
            return Json(new { resultado = rpta });
        }
    }
}
