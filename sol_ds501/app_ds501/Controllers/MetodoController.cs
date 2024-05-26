using app_ds501.Data;
using app_ds501.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace app_ds501.Controllers
{
    public class MetodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MetodoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public JsonResult Listar()
        {
            String cad_sql = "exec sp_listar_metodo";
            List<Metodo> arr_metodo = _context.Metodo.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = arr_metodo });
        }

        [HttpGet]
        public JsonResult Consultar(String codigo_metodo)
        {
            String cad_sql = "exec sp_consultar_metodo @codigo_metodo";
            Metodo metodo = new Metodo();

            metodo = _context.Metodo.FromSqlRaw(cad_sql, new SqlParameter("@codigo_metodo", codigo_metodo)).ToList().FirstOrDefault();

            return Json(metodo);
        }


        [HttpPost]
        public IActionResult Grabar([FromBody] Metodo metodo)
        {
            bool rpta = true;

            try
            {
                Metodo tmp_metodo = null;
                tmp_metodo = (from per in _context.Metodo
                                where per.codigo_metodo == metodo.codigo_metodo
                                select per).FirstOrDefault();

                if (tmp_metodo == null)
                {
                    _context.Metodo.Add(metodo);
                    _context.SaveChanges();
                }
                else
                {
                    tmp_metodo.nombre = metodo.nombre;
                    tmp_metodo.descripcion = metodo.descripcion;

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                rpta = false;
            }

            return Json(new { resultado = rpta });
        }

        public JsonResult Borrar(String codigo_metodo)
        {
            bool rpta = true;
            try
            {
                Metodo metodo = new Metodo();
                metodo = (from per in _context.Metodo
                            where per.codigo_metodo == codigo_metodo
                            select per).FirstOrDefault();
                _context.Metodo.Remove(metodo);
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
