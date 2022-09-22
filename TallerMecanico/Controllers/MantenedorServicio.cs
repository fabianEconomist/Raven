using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Datos;
using TallerMecanico.Models;

namespace TallerMecanico.Controllers
{
    public class MantenedorServicio : Controller
    {
        ServicioDatos _ServicioDatos = new ServicioDatos();
        public IActionResult Listar()
        {
            //listar contactos
            var oLista = _ServicioDatos.Listar();

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ServicioModelo oPersona)
        {
            //validacion de campos
            if (!ModelState.IsValid)
                return View();

            //recibe un objeto y guarda en la base de datos
            var respuesta = _ServicioDatos.Guardar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int IdServicio)
        {
            //devuelve la vista
            var oPersona = _ServicioDatos.Obtener(IdServicio);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Editar(ServicioModelo oPersona)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ServicioDatos.Editar(oPersona);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdServicio)
        {

            var oPersona = _ServicioDatos.Obtener(IdServicio);
            return View(oPersona);
        }

        [HttpPost]
        public IActionResult Eliminar(ServicioModelo oPersona)
        {
            var respuesta = _ServicioDatos.Eliminar(oPersona.IdServicio);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
