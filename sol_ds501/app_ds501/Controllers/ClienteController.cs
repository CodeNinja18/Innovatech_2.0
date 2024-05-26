using app_ds501.Data;
using app_ds501.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace app_ds501.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Listar()
        {
            String cad_sql = "exec sp_listar_cliente";
            List<Cliente> arr_cliente = _context.Cliente.FromSqlRaw(cad_sql).ToList();
            return Json(new { data = arr_cliente });
        }

        [HttpGet]
        public JsonResult Consultar(String codigo_cliente)
        {
            String cad_sql = "exec sp_consultar_cliente @codigo_cliente";
            Cliente cliente = new Cliente();

            cliente = _context.Cliente.FromSqlRaw(cad_sql, new SqlParameter("@codigo_cliente", codigo_cliente)).ToList().FirstOrDefault();

            return Json(cliente);
        }

        [HttpPost]
        public IActionResult Grabar([FromBody] Cliente cliente)
        {
            bool rpta = true;

            try
            {
                Cliente tmp_cliente = null;
                tmp_cliente = (from per in _context.Cliente
                                where per.codigo_cliente == cliente.codigo_cliente
                                select per).FirstOrDefault();

                if (tmp_cliente == null)
                {
                    _context.Cliente.Add(cliente);
                    _context.SaveChanges();
                }
                else
                {
                    tmp_cliente.identificacion = cliente.identificacion;
                    tmp_cliente.nombre = cliente.nombre;
                    tmp_cliente.telefono = cliente.telefono;

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                rpta = false;
            }

            return Json(new { resultado = rpta });
        }

        public JsonResult Borrar(String codigo_cliente)
        {
            bool rpta = true;
            try
            {
                Cliente cliente = new Cliente();
                cliente = (from per in _context.Cliente
                            where per.codigo_cliente == codigo_cliente
                            select per).FirstOrDefault();
                _context.Cliente.Remove(cliente);
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
