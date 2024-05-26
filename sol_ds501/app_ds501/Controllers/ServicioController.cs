using app_ds501.Data;
using app_ds501.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace app_ds501.Controllers
{
    public class ServicioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicioController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //IEnumerable<Servicio> ListarServicio = _context.Servicio;
            return View();
        }

        public JsonResult Listar()
        {
            String cad_sql = "exec sp_listar_servicio";
            List<Servicio> arr_servicio = _context.Servicio.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = arr_servicio });
        }

        [HttpGet]
        public JsonResult Consultar(String codigo_servicio)
        {
            String cad_sql = "exec sp_consultar_servicio @codigo_servicio";
            Servicio servicio = new Servicio();

            servicio = _context.Servicio.FromSqlRaw(cad_sql, new SqlParameter("@codigo_servicio", codigo_servicio)).ToList().FirstOrDefault();

            return Json(servicio);
        }


        [HttpPost]
        public IActionResult Grabar([FromBody] Servicio servicio)
        {
            bool rpta = true;

            try
            {
                Servicio tmp_servicio = null;
                tmp_servicio = (from per in _context.Servicio
                                where per.codigo_servicio == servicio.codigo_servicio
                                select per).FirstOrDefault();

                if (tmp_servicio == null)
                {
                    _context.Servicio.Add(servicio);
                    _context.SaveChanges();
                }
                else
                {
                    tmp_servicio.nombre = servicio.nombre;
                    tmp_servicio.descripcion = servicio.descripcion;

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                rpta = false;
            }

            return Json(new { resultado = rpta });
        }

        public JsonResult Borrar(String codigo_servicio)
        {
            bool rpta = true;
            try
            {
                Servicio servicio = new Servicio();
                servicio = (from per in _context.Servicio
                            where per.codigo_servicio == codigo_servicio
                            select per).FirstOrDefault();
                _context.Servicio.Remove(servicio);
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
